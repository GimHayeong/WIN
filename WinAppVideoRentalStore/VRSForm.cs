using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppVideoRentalStore
{
    public partial class VRSForm : Form
    {
        public int SelectedMemberIndex { get; private set; }
        public int SelectedVideoIndex { get; private set; }

        public VRSForm()
        {
            InitializeComponent();
        }

        private void VRSForm_Load(object sender, EventArgs e)
        {
            tblMembershipTableAdt.Connection.ConnectionString = BLL.SampleData.GetConnectionString();
            tblVideoTableAdt.Connection.ConnectionString = BLL.SampleData.GetConnectionString();
            tblRentVideoTableAdt.Connection.ConnectionString = BLL.SampleData.GetConnectionString();
            tblCodeTableAdt.Connection.ConnectionString = BLL.SampleData.GetConnectionString();

            try
            {
                tblMembershipTableAdt.Fill(vrsDataSet.tblMembership);
                tblVideoTableAdt.Fill(vrsDataSet.tblVideo);
                tblRentVideoTableAdt.Fill(vrsDataSet.tblRentVideo);
                tblCodeTableAdt.Fill(vrsDataSet.tblCode);

                SetMemberListView();
                SetVideoListView();
                SetRendVideoListView();
            }
            catch (Exception)
            {
                MessageBox.Show("데이터를 가져오는 동안 문제가 발생했습니다. \r\n인터넷 연결확인후 실행하시거나 관리자 문의바랍니다.", "데이터연결안내");
                foreach(var ctr in this.Controls)
                {
                    GroupBox grp = ctr as GroupBox;
                    if (ctr != null)
                    {
                        foreach(var btn in grp.Controls)
                        {
                            if(btn is Button)
                            {
                                ((Button)btn).Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnNewMembership":
                        CreaterMember();
                        break;

                    case "btnEditMembership":
                        ModifyMember();
                        break;

                    case "btnWithdrawMembership":
                        RemoveMember();
                        break;

                    case "btnNewVideo":
                        CreateVideo();
                        break;

                    case "btnEditVideo":
                        ModifyVideo();
                        break;

                    case "btnDeleteVideo":
                        RemoveVideo();
                        break;

                    case "btnRend":
                        RendVideo();
                        break;

                    case "btnReturn":
                        ReturnVideo();
                        break;
                }
            }
        }



        private void RendVideo()
        {
            if (lbxMembership.SelectedItems == null || lbxMembership.SelectedItems.Count < 1 
                || lbxVideo.SelectedItems == null || lbxVideo.SelectedItems.Count < 1)
            {
                MessageBox.Show("대여할 회원과 비디오를 먼저 선택해 주십시오.", "비디오 대여안내");
                lbxVideo.Focus();
                return;
            }

            int idxMember = lbxMembership.SelectedItems[0].Index;
            int idxVideo = lbxVideo.SelectedItems[0].Index;

            int memberId = Convert.ToInt32(lbxMembership.Items[idxMember].Name);
            int videoId = Convert.ToInt32(lbxVideo.Items[idxVideo].Name);

            VRSDataSet.tblVideoRow rowVideo = vrsDataSet.tblVideo.FindById(videoId);
            VRSDataSet.tblMembershipRow rowMember = vrsDataSet.tblMembership.FindById(memberId);

            if(rowVideo == null || rowMember == null)
            {
                MessageBox.Show("회원정보와 비디오정보를 확인해 주십시오", "대여정보 확인안내");
                lbxVideo.Focus();
                return;
            }

            if (rowVideo.Stock - vrsDataSet.tblRentVideo.Count(o => o.VideoId == rowVideo.Id && !o.IsReturn) < 0)
            {
                MessageBox.Show("대여할 비디오가 없습니다.", "대여정보 확인안내");
                lbxVideo.Focus();
                return;
            }

            if (MessageBox.Show("대여하시겠습니까?", "대여확인안내") == DialogResult.OK)
            {
                VRSDataSet.tblRentVideoRow row = vrsDataSet.tblRentVideo.NewtblRentVideoRow();
                row.BeginEdit();
                row.MemberId = memberId;
                row.VideoId = videoId;
                row.RentDate = DateTime.Now;
                row.IsReturn = false;
                row.EndEdit();
                vrsDataSet.tblRentVideo.Rows.Add(row);

                //데이터소스에 반영
                this.Validate();
                this.tblRentVideoTableAdt.Update(row);

                SetMemberListView();
                SetVideoListView();
                SetRendVideoListView();
            }
        }

        private void ReturnVideo()
        {
            if (lbxRendVideo.SelectedItems == null || lbxRendVideo.SelectedItems.Count < 1)
            {
                MessageBox.Show("반환할 회원의 대여 비디오를 먼저 선택해 주십시오.", "비디오 반환안내");
                lbxVideo.Focus();
                return;
            }

            int idx = lbxRendVideo.SelectedItems[0].Index;
            int id = Convert.ToInt32(lbxRendVideo.Items[idx].Name);

            VRSDataSet.tblRentVideoRow row = vrsDataSet.tblRentVideo.FindById(id);

            if(row != null && MessageBox.Show("반환하시겠습니까?", "반환확인안내") == DialogResult.OK)
            {
                row.BeginEdit();
                row.ReturnDate = DateTime.Now;
                row.IsReturn = true;
                row.EndEdit();

                this.Validate();
                this.tblRentVideoTableAdt.Update(row);

                SetMemberListView();
                SetVideoListView();
                SetRendVideoListView();
            }
        }






        private void CreaterMember()
        {
            VRSMemberForm dlg = new VRSMemberForm();
            dlg.Text = "신규회원 등록";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                VRSDataSet.tblMembershipRow row = vrsDataSet.tblMembership.NewtblMembershipRow();
                SetMemberData(dlg.m_Member, ref row);

                vrsDataSet.tblMembership.Rows.Add(row);

                //데이터소스에 반영
                this.Validate();
                this.tblMembershipTableAdt.Update(row);

                SetMemberListView();
            }
        }

        private void ModifyMember()
        {
            if(lbxMembership.SelectedItems == null || lbxMembership.SelectedItems.Count < 1)
            {
                MessageBox.Show("수정할 회원을 먼저 선택해 주십시오.", "회원정보수정 안내");
                lbxMembership.Focus();
                return;
            }

            int idx = lbxMembership.SelectedItems[0].Index;

            VRSMemberForm dlg = new VRSMemberForm();
            dlg.Text = "회원 정보 수정";

            dlg.m_Member = lbxMembership.Items[idx].Tag as Membership;
            
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                int id = Convert.ToInt32(lbxMembership.Items[idx].Name);
                VRSDataSet.tblMembershipRow row = vrsDataSet.tblMembership.FindById(id);
                SetMemberData(dlg.m_Member, ref row);

                if(row.RowState == DataRowState.Modified)
                {
                    //데이터소스에 반영
                    this.Validate();
                    this.tblMembershipTableAdt.Update(row);

                    SetMemberListView();
                }
            }
        }

        private void RemoveMember()
        {
            if (lbxMembership.SelectedItems == null || lbxMembership.SelectedItems.Count < 1)
            {
                MessageBox.Show("삭제할 회원을 먼저 선택해 주십시오.", "회원정보삭제 안내");
                lbxMembership.Focus();
                return;
            }

            int idx = lbxMembership.SelectedItems[0].Index;
            int id = Convert.ToInt32(lbxMembership.Items[idx].Name);
            int rent = vrsDataSet.tblRentVideo.Count(o => o.MemberId == id);
            if(rent < 1)
            {
                if (MessageBox.Show("정말 삭제하시겠습니까?", "회원정보 삭제안내") == DialogResult.OK)
                {
                    VRSDataSet.tblMembershipRow row = vrsDataSet.tblMembership.FindById(id);
                    row.Delete();
                    this.tblMembershipTableAdt.Update(row);

                    SetMemberListView();
                }
            }else
            {
                MessageBox.Show("대여기록이 있는 회원분은 삭제할 수 없습니다.", "회원정보 삭제안내");
            }
        }

        private void SetMemberData(DAL.Membership dlgData, ref VRSDataSet.tblMembershipRow row)
        {
            if (row.IsNull("Name") || !row.Name.Equals(dlgData.Name)) row.Name = dlgData.Name;
            if (row.IsNull("Male") || !row.Male.Equals(dlgData.Male)) row.Male = dlgData.Male;
            if (row.IsNull("Birthday") || !row.Birthday.Equals(dlgData.Birthday)) row.Birthday = dlgData.Birthday;
            if (row.IsNull("ZipCode") || !row.Zipcode.Equals(dlgData.ZipCode)) row.Zipcode = dlgData.ZipCode;
            if (row.IsNull("Addr") || !row.Addr.Equals(dlgData.Addr)) row.Addr = dlgData.Addr;
            if (row.IsNull("Addr2") || !row.Addr2.Equals(dlgData.AddrDetail)) row.Addr2 = dlgData.AddrDetail;
            if (row.IsNull("Cellphone") || !row.Cellphone.Equals(dlgData.Cellphone)) row.Cellphone = dlgData.Cellphone;
            if (row.IsNull("GradeCode") || !row.GradeCode.Equals(dlgData.MGradeCode)) row.GradeCode = dlgData.MGradeCode;
            if (row.IsNull("Deposit") || !row.Deposit.Equals(dlgData.MDeposit)) row.Deposit = dlgData.MDeposit;
        }






        private void CreateVideo()
        {
            VRSVideoForm dlg = new VRSVideoForm();
            dlg.Text = "비디오정보 등록";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                VRSDataSet.tblVideoRow row = vrsDataSet.tblVideo.NewtblVideoRow();
                SetVideoData(dlg.m_Video, ref row);

                vrsDataSet.tblVideo.Rows.Add(row);

                //데이터소스에 반영
                this.Validate();
                this.tblVideoTableAdt.Update(row);

                SetVideoListView();
            }
        }

        private void ModifyVideo()
        {
            if (lbxVideo.SelectedItems == null || lbxVideo.SelectedItems.Count < 1)
            {
                MessageBox.Show("수정할 비디오를 먼저 선택해 주십시오.", "비디오정보 수정안내");
                lbxVideo.Focus();
                return;
            }

            int idx = lbxVideo.SelectedItems[0].Index;

            VRSVideoForm dlg = new VRSVideoForm();
            dlg.Text = "비디오정보 수정";

            dlg.m_Video = lbxVideo.Items[idx].Tag as Video;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int id = Convert.ToInt32(lbxVideo.Items[idx].Name);
                VRSDataSet.tblVideoRow row = vrsDataSet.tblVideo.FindById(id);
                SetVideoData(dlg.m_Video, ref row);

                if(row.RowState == DataRowState.Modified)
                {
                    //데이터소스에 반영
                    this.Validate();
                    this.tblVideoTableAdt.Update(row);

                    SetVideoListView();
                }
            }
        }

        private void RemoveVideo()
        {
            if (lbxVideo.SelectedItems == null || lbxVideo.SelectedItems.Count < 1)
            {
                MessageBox.Show("삭제할 비디오를 먼저 선택해 주십시오.", "비디오삭제 안내");
                lbxVideo.Focus();
                return;
            }

            int idx = lbxVideo.SelectedItems[0].Index;
            int id = Convert.ToInt32(lbxVideo.Items[idx].Name);
            int rent = vrsDataSet.tblRentVideo.Count(o => o.VideoId == id);
            if (rent < 1)
            {
                if (MessageBox.Show("정말 삭제하시겠습니까?", "비디오정보 삭제안내") == DialogResult.OK)
                {
                    VRSDataSet.tblVideoRow row = vrsDataSet.tblVideo.FindById(id);
                    row.Delete();
                    this.tblVideoTableAdt.Update(row);

                    SetVideoListView();
                }
            }
            else
            {
                MessageBox.Show("대여기록이 있는 비디오는 삭제할 수 없습니다.", "비디오정보 삭제안내");
            }
        }
        
        private void SetVideoData(DAL.Video dlgData, ref VRSDataSet.tblVideoRow row)
        {
            if (row.IsNull("Title") || !row.Title.Equals(dlgData.Title)) row.Title = dlgData.Title;
            if (row.IsNull("Stock") || !row.Stock.Equals(dlgData.Stock)) row.Stock = dlgData.Stock;
            if (row.IsNull("Producer") || !row.Producer.Equals(dlgData.Producer)) row.Producer = dlgData.Producer;
            if (row.IsNull("Director") || !row.Director.Equals(dlgData.Director)) row.Director = dlgData.Director;
            if (row.IsNull("Starring") || !row.Starring.Equals(dlgData.Starring)) row.Starring = dlgData.Starring;
            if (row.IsNull("ProductionYear") || !row.ProductionYear.Equals(dlgData.ProductionYear)) row.ProductionYear = dlgData.ProductionYear;
            if (row.IsNull("Description") || !row.Description.Equals(dlgData.Description)) row.Description = dlgData.Description;
            if (row.IsNull("VideoCode") || !row.VideoCode.Equals(dlgData.VideoType)) row.VideoCode = dlgData.VideoType;
        }






        private void SetMemberListView()
        {
            var qryMember = from m in vrsDataSet.tblMembership
                            join vc in vrsDataSet.tblCode on m.GradeCode equals vc.Code
                            select new { m.Id, mMember = new Membership(m.Name, m.Male, m.Birthday, m.Zipcode, m.Addr, m.Addr2, m.Cellphone, vc.Code, m.Deposit) };

            int no = 1;
            int rent = 0;
            lbxMembership.Items.Clear();
            foreach (var q in qryMember)
            {
                rent = vrsDataSet.tblRentVideo.Count(o => o.MemberId == q.Id && !o.IsReturn);
                lbxMembership.Items.Add(new ListViewItem(new string[] { no.ToString(), q.mMember.Name, q.mMember.MGradeCode.ToString(), q.mMember.MDeposit.ToString(), rent.ToString() }));
                lbxMembership.Items[no - 1].Tag = q.mMember;
                lbxMembership.Items[no - 1].Name = q.Id.ToString();
                no++;
            }
        }

        private void SetVideoListView()
        {
            var qryVideo = from v in vrsDataSet.tblVideo
                           join vc in vrsDataSet.tblCode on v.VideoCode equals vc.Code
                           select new { v.Id, VideoType = vc.CodeText, mVideo = new Video(v.Title, v.Stock, v.Producer, v.Director, v.Starring, v.ProductionYear, v.VideoCode, v.Description) };

            int no = 1;
            int rent = 0;
            lbxVideo.Items.Clear();
            foreach (var q in qryVideo)
            {
                rent = vrsDataSet.tblRentVideo.Count(o => o.VideoId == q.Id && !o.IsReturn);
                lbxVideo.Items.Add(new ListViewItem(new string[] { no.ToString(), q.mVideo.Title, q.VideoType, $"{rent}/{q.mVideo.Stock}" }));
                lbxVideo.Items[no - 1].Tag = q.mVideo;
                lbxVideo.Items[no - 1].Name = q.Id.ToString();
                no++;
            }
        }

        private void SetRendVideoListView()
        {
            var qryRendVideo = from r in vrsDataSet.tblRentVideo
                               join v in vrsDataSet.tblVideo on r.VideoId equals v.Id
                               join m in vrsDataSet.tblMembership on r.MemberId equals m.Id
                               select new { r.Id, RendVideo = new RendVideo(r.MemberId, r.VideoId, r.RentDate), v.Title, m.GradeCode, MemberName = m.Name, State = r.IsReturn ? "반환" : "대여" };

            int no = 1;
            lbxRendVideo.Items.Clear();
            foreach (var q in qryRendVideo)
            {
                lbxRendVideo.Items.Add(new ListViewItem(new string[] { no.ToString(), q.RendVideo.RentDate.ToShortDateString(), q.GradeCode.ToString(), q.Title, q.MemberName, q.State }));
                lbxRendVideo.Items[no - 1].Tag = q.RendVideo;
                lbxRendVideo.Items[no - 1].Name = q.Id.ToString();
                no++;
            }
        }

        
    }
}
