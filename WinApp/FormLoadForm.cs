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
    // 생성자 호출 ==> Load ==> Shown
    // FormClosing ==> FormClosed
    // Load 에서 Close 호출 가능
    // SuspendLayout() : Layout 이벤트가 발생하지 않도록 금지 (InitializeComponent 메서드)
    // ResumeLayout() : Layout 이벤트 발생 허가. (true: 보류중인 레이아웃 요청을 즉시 실행)

    public partial class FormLoadForm : Form
    {
        public bool IsConnected { get; private set; }
        public Rectangle Rect { get; private set; }
        public string SizeInfo { get; private set; }

        public FormLoadForm()
        {
            InitializeComponent();
        }

        private void FormLoadForm_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("연결하시겠습니까?", "질문", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                IsConnected = false;
                Text = "네트워크에 연결이 중단되었습니다.";

                Close();
            }
            else
            {
                IsConnected = true;
                Text = "네트워크에 연결되었습니다.";
            }
        }

        private void FormLoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("정말 종료하시겠습니까?", "질문", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void FormLoadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsConnected = false;
        }

        /// <summary>
        /// Layout 이벤트 : 폼이 최초 생성될 때(배치초기화), 폼의 크기나 차일드의 위치가 변경될 때, 차일드가 추가/제거될 때 발생.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">영향을 받는 차일드와 프로퍼티 정보</param>
        private void FormLoadForm_Layout(object sender, LayoutEventArgs e)
        {
            Rect = ClientRectangle;
            Rect.Inflate(-10, -10);
            SizeInfo = string.Format("폭 : {0}, 높이 : {1}", Rect.Width, Rect.Height);
            Invalidate();
        }

        private void FormLoadForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, Rect);
            e.Graphics.DrawString(SizeInfo, Font, Brushes.Black, 0, 0);
        }

        /// <summary>
        /// 폼의 상태가 활성화될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadForm_Activated(object sender, EventArgs e)
        {
            BackColor = Color.GreenYellow;
        }

        /// <summary>
        /// 폼의 상태가 비활성화될 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadForm_Deactivate(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
        }

        /// <summary>
        /// 폼이 최조로 보일떄 한번 발생
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoadForm_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("이 프로그램은 세어웨어입니다. 정식 등록후 사용해 주십시오.", "프로그램 사용안내");
        }
    }
}
