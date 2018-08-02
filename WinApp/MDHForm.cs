using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    // Object > Component > control > Form
    // 컴포넌트 : 프로그램의 가징 기본적이 부품이 되는 구성요소. 각 컴포넌트는 캡슐화에 의해 고유 기능을 제공하며 완벽한 재사용성을 구현. 자원을 명시적으로 해제할 수 있는 Dispose 메서드 제공
    //            ==> CBD(컴포넌트 조립식 개발법) : 컴포넌트들이 모여 완성된 프로그램을 이루는 개발방법.
    // 컨 트 롤 : 컴포넌트 중에 가시적으로 보이는 것. 사용자와 상호작용 수행. (타이머는 보이지 않으므로 컴포넌트이나 컨트롤은 아님)
    //    폼    : 컨테이너 기능을 추가한 특수한 컨트롤. (스크롤 기능과 차일드 포함기능)

    public partial class MDHForm : Form
    {
        Form childForm = null;
        public MDHForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);

            lstSystemInfo.KeyPress += new KeyPressEventHandler(OnKeyPress);

            Text = "부모윈도우";
            LocationChanged += Form_LocationChanged;
            //SetBounds(10, 10, 250, 250);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            childForm = new Form();
            childForm.Text = "자식윈도우";
            childForm.SetBounds(10, 10, 250, 250);

            childForm.Show();

            // LocationChanged 이벤트 호출하기 위해
            this.Left = 10;
        }

        private void Form_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                if (childForm.Visible)
                {
                    childForm.Left = this.Left;
                    childForm.Top = this.Top + this.Height;
                    this.Focus();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex} 예외발생");
            }
        }

        protected void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            lstSystemInfo.Items.Add(e.KeyChar);
            Invalidate();
        }

        private void MDHForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, 10, 10, 200, 200);
        }

        private void btnSystemInfo_Click(object sender, EventArgs e)
        {
            lstSystemInfo.Items.Add("BootMode: " + (SystemInformation.BootMode == BootMode.Normal ? "정상부팅" : "안전모드"));
            lstSystemInfo.Items.Add("Border3DSize: " + SystemInformation.Border3DSize.ToString());
            lstSystemInfo.Items.Add("CaptionHeight: " + SystemInformation.CaptionHeight.ToString());
            lstSystemInfo.Items.Add("ComputerName: " + SystemInformation.ComputerName.ToString());
            lstSystemInfo.Items.Add("DoubleClickSize: " + SystemInformation.DoubleClickSize.ToString());
            lstSystemInfo.Items.Add("DoubleClickTime: " + SystemInformation.DoubleClickTime.ToString());
            lstSystemInfo.Items.Add("DragFullWindows: " + SystemInformation.DragFullWindows.ToString());
            lstSystemInfo.Items.Add("DragSize: " + SystemInformation.DragSize.ToString());
            lstSystemInfo.Items.Add("IconSize: " + SystemInformation.IconSize.ToString());
            lstSystemInfo.Items.Add("KeyboardDelay: " + SystemInformation.KeyboardDelay.ToString());
            lstSystemInfo.Items.Add("KeyboardSpeed: " + SystemInformation.KeyboardSpeed.ToString());
            lstSystemInfo.Items.Add("UserName: " + SystemInformation.UserName.ToString());
            lstSystemInfo.Items.Add("WorkingArea: " + SystemInformation.WorkingArea.ToString());
        }

        
    }
}
