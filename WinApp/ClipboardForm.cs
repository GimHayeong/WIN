using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WinApp
{
    /// <summary>
    /// 클립보드 : 응용프로그램 간 또는 응용프로그램 내부에서 데이터를 교환하는 가장 기본적인 장치.
    ///            운영체제가 관리하는 일종의 임시데이터 저장소로 시스템 전체에 단 하나만 존재.
    /// Clipboard 클래스 : 클립보드를 관리하는 정적 메서드.
    ///   + SetText : 클립보드에 텍스트 저장    ==> SetText( string data [, TextDataFormat format] )
    ///   + GetText : 클립보드에서 텍스트 읽기  ==> GetText( [TextDataFormat format] )
    ///   + ContainsText : 클립보드에 텍스트가 존재하는지 여부 검사  ==> ContanisText( [TextDataFormat format] )
    /// </summary>
    public partial class ClipboardForm : Form
    {
        /// <summary>
        /// 드래그 시작할 최소 이동 거리를 구하기 위해 필요
        /// </summary>
        private Size m_DragSize = SystemInformation.DragSize;

        public ClipboardForm()
        {
            InitializeComponent();

            InitCopyAudioToClipboard();

            InitDragNDrop();
        }

        /// <summary>
        /// 오디오 파일을 클립보드로 복사하기 위한 오디오 파일 초기화
        /// </summary>
        private void InitCopyAudioToClipboard()
        {
            string strMediaFilePath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\capture.wav";
            FileStream stream = new FileStream(strMediaFilePath, FileMode.Open, FileAccess.Read);
            btnAudioSrc.Tag = stream;
        }

        /// <summary>
        /// Drag & Drop 기능을 위한 초기화
        ///   + Drop 대상 컨트롤의 AllowDrop 속성은 true 로 설정해야 한다.
        /// </summary>
        private void InitDragNDrop()
        {
            lbxSrc.Items.AddRange(new string[] { "박시승", "이춘수", "안정한", "이온재", "설기현", "홍맹보", "이영표", "박주엉", "이을옹", "김나일", "김병지", "이동걱", "유상칠", "차둘리" });
            lbxTgt.AllowDrop = true;
            lbxFileTgt.AllowDrop = true;
        }



        #region CLIPBOARD : Text
        private void btnSetToClipboard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if(String.IsNullOrWhiteSpace(txtSrc.Text)) { return; }
                switch (btn.Name)
                {
                    case "btnSetToClipboard":
                        Clipboard.SetText(txtSrc.Text);
                        break;

                    case "btnCutToClipboard":
                        Clipboard.SetText(txtSrc.Text);
                        txtSrc.Text = "";
                        break;
                }
            }
            
        }

        private void btnGetFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtTgt.Text = Clipboard.GetText();
            }
        }
        #endregion



        #region CLIPBOARD : Image

        private void btnSetImageToClipboard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                if (pbxSrc.Image == null) { return; }
                switch (btn.Name)
                {
                    case "btnSetImageToClipboard":
                        Clipboard.SetImage(pbxSrc.Image);
                        break;

                    case "btnCutImageToClipboard":
                        Clipboard.SetImage(pbxSrc.Image);
                        pbxSrc.Image = null;
                        break;
                }
            }
        }

        private void btnGetImageFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pbcTgt.Image = Clipboard.GetImage();
            }
        }

        #endregion



        #region CLIPBOARD : Audio

        private void btnSetAudioToClipboard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                FileStream stream = btnAudioSrc.Tag as FileStream;
                if (stream == null) { return; }
                switch (btn.Name)
                {
                    case "btnSetAudioToClipboard":
                        Clipboard.SetAudio(stream);
                        break;

                    case "btnCutAudioToClipboard":
                        Clipboard.SetAudio(stream);
                        btnAudioSrc.Tag = null;
                        btnAudioSrc.Click -= btnAudioSrc_Click;
                        break;
                }
            }
        }

        private void btnGetAudioStreamFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsAudio())
            {
                btnAudioTgt.Tag = Clipboard.GetAudioStream();
            }
        }

        private void btnAudioSrc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                Stream stream = btn.Tag as Stream;
                if(stream == null) { return; }
                stream.Seek(0, SeekOrigin.Begin);
                SoundPlayer player = new SoundPlayer(stream);
                switch (btn.Name)
                {
                    case "btnAudioSrc":
                        player.Play();
                        break;

                    case "btnAudioTgt":
                        player.Play();
                        break;
                }
            }
        }

        #endregion



        #region CLIPBOARD : FileDropList

        private void btnSetFilesToClipboard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (String.IsNullOrWhiteSpace(txtSrc.Text)) { return; }
                StringCollection files;
                switch (btn.Name)
                {
                    case "btnSetFilesToClipboard":
                        files = new StringCollection();
                        Clipboard.SetFileDropList(files);
                        break;

                    case "btnCutFilesToClipboard":
                        files = new StringCollection();
                        Clipboard.SetFileDropList(files);
                        //원본 초기화
                        break;
                }
            }
        }

        private void btnGetFilesFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsFileDropList())
            {
                //대상에 클립보드 붙여넣기 ==> Clipboard.GetFileDropList();
            }
        }

        #endregion



        #region CLIPBOARD : Object

        /// <summary>
        /// 임의 포맷의 데이터를 클립보드로 저장 (다른 프로그램으로 전송이 가능해야 하므로, 기본타입과 시리얼라이즈 가능한 객체타입만 허용)
        ///   + SetDataObject(데이터, 종료후데이터유지여부) : 
        ///                           true 이면 클립보드로 데이터를 넘겨 종료후에도 클립보드에 데이터 지속
        ///                           false 이면 지연된 그리기기법으로, 클립보드로 데이터를 보내지 않고 요청이 있을 때 데이터 전송하여 메모리와 복사시간 절약하지만 종료후에 데이터 사라짐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetObjectToClipboard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                switch (btn.Name)
                {
                    case "btnSetObjectToClipboard":
                        Clipboard.SetDataObject(txtObjSrc.Text, true);
                        break;

                    case "btnSetDataToClipboard":
                        DataObject data = new DataObject();
                        data.SetData(DataFormats.Text, txtObjSrc.Text);
                        string html = "<p>" + txtObjSrc.Text + "</p>";
                        data.SetData(DataFormats.Html, html);
                        Clipboard.SetDataObject(data, true);
                        break;

                    case "btnCutObjectToClipboard":
                        Clipboard.SetDataObject(txtObjSrc.Text, true);
                        txtObjSrc.Text = "";
                        break;

                }
            }
        }

        /// <summary>
        /// 클립보드의 특정타입의 객체를 가져와 붙여넣기
        ///   + GetDataObject() : 포맷 독립적인 클립보드에 저장된 데이터인 IDataObject를 반환 
        ///   + GetDataPresent(타입) : 특정타입이 클립보드에 있는지 조사
        ///   + GetData(타입) : 특정타입의 클립보드에 있는 데이터 가져오기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetObjectFromClipboard_Click(object sender, EventArgs e)
        {
            IDataObject clipboardData = Clipboard.GetDataObject();
            if (clipboardData.GetDataPresent(typeof(string)))
            {
                txtObjTgt.Text = (string)clipboardData.GetData(typeof(string));
            }
            if (clipboardData.GetDataPresent(DataFormats.Html))
            {
                txtObjHtmlTgt.Text = (string)clipboardData.GetData(DataFormats.Html);
            }
        }

        /// <summary>
        /// 클립보드의 데이터 타입 목록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFormats_Click(object sender, EventArgs e)
        {
            string[] formats = Clipboard.GetDataObject().GetFormats();

            lbxClipboardFormats.Items.Clear();
            foreach(string format in formats)
            {
                lbxClipboardFormats.Items.Add(format);
            }
        }

        #endregion



        #region DRAG & DROP

        // 드래그 대상 컨트롤은 드롭 받을 준비작업도 해제할 작업도 없으므로  DragEnter와 DragLeave 이벤트 필요하지 않음

        /// <summary>
        /// DRAG 시작
        ///   + DoDragDrop 메서드 : 드래그 과정 전체를 책임지며 드롭이 완전히 끝나거나 취소하기 전까지 리턴(DragDropEffects 값)하지 않음.
        ///   + DragDropEffects 리턴값 : 드롭된 곳에서 허용한 동작을 드롭되는 컨트롤로부터 얻음.
        ///   + 마우스 오른쪽 버튼으로 드래그를 시작할 수 있으므로 커서 좌표(e.X, e.Y)로부터 대상 항목을 구해야 함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxSrc_MouseDown(object sender, MouseEventArgs e)
        {
            DragDropEffects dragEffect;
            
            int selectedIndex = GetSelectedIndex(lbxSrc, e.X, e.Y);
            if (selectedIndex != ListBox.NoMatches)
            {
                string selectedItem = (string)lbxSrc.Items[selectedIndex];
                dragEffect = DoDragDrop(selectedItem, DragDropEffects.Copy | DragDropEffects.Move);
                if(dragEffect == DragDropEffects.Move)
                {
                    lbxSrc.Items.RemoveAt(selectedIndex);
                }
            }
        }

        /// <summary>
        /// 마우스 오른쪽 버튼으로 드래그를 시작할 수 있으므로 커서 좌표(e.X, e.Y)로부터 드래그 대상 항목의 인덱스를 구해 반환
        /// </summary>
        /// <param name="lbx">드래그 대상을 담은 부모 컨트롤</param>
        /// <param name="eX">마우스 버튼 다운 X좌표</param>
        /// <param name="eY">마우스 버튼 다운 Y좌표</param>
        /// <returns></returns>
        private int GetSelectedIndex(ListBox lbx, int eX, int eY)
        {
            return GetSelectedIndex(lbx, eX, eY, false);
        }

        /// <summary>
        /// 마우스 오른쪽 버튼으로 드래그를 시작할 수 있으므로 커서 좌표(e.X, e.Y)로부터 드래그 대상 항목의 인덱스를 구해 반환
        /// </summary>
        /// <param name="lbx">드래그 대상을 담은 부모 컨트롤</param>
        /// <param name="eX">마우스 버튼 다운 X좌표</param>
        /// <param name="eY">마우스 버튼 다운 Y좌표</param>
        /// <param name="isUseDragSize">
        ///   + true : 마우스 버튼을 누르고 어느 정도 이동후 드래그 동작 시작 ==> 좀 더 정확
        ///   + false : 마우스 버튼을 누르는 즉시 드래그 동작 시작
        /// </param>
        /// <returns></returns>
        private int GetSelectedIndex(ListBox lbx, int eX, int eY, bool isUseDragSize)
        {
            if (isUseDragSize)
            {
                return lbxSrc.IndexFromPoint(eX, eY);
            }
            else
            {
                return lbx.IndexFromPoint(new Point(eX - m_DragSize.Width / 2, eY - m_DragSize.Height / 2));
            }
        }

        /// <summary>
        /// 드래그 상태를 변경하고 싶을 때, 키 상태나 Esc 키 등의 상태를 보고 드래그 동작을 중간에 멈출 수 있다.
        ///   + ESC 키를 감지하고 있다가 ESC 키가 눌린 경우 DRAG 중단
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        ///   + e.Action : DragAction.Cancel 를 설정하면 드래그 즉시 중단
        /// </param>
        private void lbxSrc_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
            }
        }

        /// <summary>
        /// 드롭받을 컴트롤 위에서 마우스를 이동할 때
        ///   + 복사 또는 이동 중 DoDragDrop 에 허용되는 동작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        ///   + X, Y : 드래그 중의 화면 좌표. 작업영역 좌표로 변경하려면 PointToClint 메서드 사용
        ///   + Data : 드래그되고 있는 IDataObject 객체의 포맷을 판별하여 드롭을 받을 것인지 결정
        ///   + KeyState : 마우스 및 키보드 조합키의 상태 플래그. Left(1), Right(2), Shift(4), Ctrl(8), Middle(16), Alt(32).
        ///   + AllowedEffect : 드래그를 시작한 원본에서 허용한 동작 정보를 갖는 DragDropEffects
        ///   + Effect : 드롭할 때 허용할 동작을 설정하여 반환
        /// </param>
        private void lbxTgt_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                if((e.KeyState & 8) != 0)// Ctrl + 키
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        /// <summary>
        /// 드롭받을 컨트롤에서 마우스를 놓을 때
        ///   + DROP 동작 완료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxTgt_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                lbxTgt.Items.Add(e.Data.GetData(DataFormats.StringFormat));
            }
        }

        /// <summary>
        /// 객체가 드롭받을 컨트롤의 범위 안에 최초로 들어올 때마다, 드롭을 받기 위한 어떤 준비작업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxTgt_DragEnter(object sender, DragEventArgs e)
        {
            // 드롭을 받기 위한 어떤 준비가 필요한 경우, 여기에 ...
        }

        /// <summary>
        /// 객체가 컨트롤의 범위를 벗어났을 때마다, 드롭이 취소된 것으로 보고 DragEnter 이벤트에서 준비작업을 해제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxTgt_DragLeave(object sender, EventArgs e)
        {
            // 드롭을 받기 위해 했던 준비작업 해제할 경우, 여기에 ...
        }



        #endregion


        #region DRAG & DROP : Drop File From 탐색기

        private void lbxFileTgt_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void lbxFileTgt_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach(string file in files)
                {
                    lbxFileTgt.Items.Add(file);
                }
            }
        }

        #endregion
    }
}
