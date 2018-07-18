//#define ARRAY
//#define WHEEL
#define ENTERLEAVE
using System;
using System.Collections;
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
    // Paint 이벤트 : 인수로부터 전달된 Graphics 객체를 사용해 그리기
    // 그 외의 이벤트 : 임시적인 그리기를 할 때 컨트롤의 CreateGraphics 메서드를 호출해 그리기 객체 직접 생성 => 사용후 Dispose 호출

    public partial class MouseDownForm : Form
    {
#if ARRAY
        //public ArrayList arPos { get; set; }
        public List<Point> arPos { get; set; }
#elif WHEEL
        public int CurrentX { get; private set; }
#elif ENTERLEAVE
        public int HoverCount { get; private set; }
        public string MouseStatus { get; private set; }
#else
        public int ClickedCount { get; private set; }
#endif
        public MouseDownForm()
        {
            // 마우스 버튼이 눌러지는 시점과 위치를 프레임워크가 관리하도록 설정
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.StandardDoubleClick, true);


            InitializeComponent();
#if ARRAY
            //arPos = new ArrayList();
            arPos = new List<Point>();
            this.Paint += MouseDownForm_Paint;
#elif WHEEL
            this.MouseWheel += MouseDownForm_MouseWheel;
            this.Paint += MouseDownForm_Paint;
            CurrentX = 10000;
#elif ENTERLEAVE
            this.MouseEnter += MouseDownForm_MouseEnter;
            this.MouseHover += MouseDownForm_MouseHover;
            this.MouseLeave += MouseDownForm_MouseLeave;
            this.Paint += MouseDownForm_Paint;
            MouseStatus = "알수 없음";
#else
#endif
        }

        private void MouseDownForm_MouseLeave(object sender, EventArgs e)
        {
#if ENTERLEAVE
            MouseStatus = "컨트롤 밖으로 나감";
            Invalidate();
#endif
        }

        private void MouseDownForm_MouseHover(object sender, EventArgs e)
        {
#if ENTERLEAVE
            HoverCount++;
            Invalidate();
#endif
        }

        private void MouseDownForm_MouseEnter(object sender, EventArgs e)
        {
#if ENTERLEAVE
            MouseStatus = "컨트롤 안으로 들어옴";
            Invalidate();
#endif
        }

        private void MouseDownForm_MouseWheel(object sender, MouseEventArgs e)
        {
#if WHEEL
            CurrentX += e.Delta;//+/- 120
            Invalidate();
#endif
        }

        private void MouseDownForm_Paint(object sender, PaintEventArgs e)
        {
#if ARRAY
            foreach(var p in arPos)
            {
                e.Graphics.DrawEllipse(Pens.Goldenrod, p.X, p.Y, 10, 10);
            }
#elif WHEEL
            string str = "현재 휠 값: " + CurrentX.ToString();
            e.Graphics.DrawString(str, Font, Brushes.Black, 10, 10);
#elif ENTERLEAVE
            e.Graphics.Clear(BackColor);
            e.Graphics.DrawString(MouseStatus, Font, Brushes.Black, 10, 10);
            e.Graphics.DrawString("카운트: " + HoverCount.ToString(), Font, Brushes.Black, 10, 30);
#else
#endif
        }

        private void MouseDownForm_MouseDown(object sender, MouseEventArgs e)
        {
#if ARRAY
            if(e.Button == MouseButtons.Left)
            {
                arPos.Add(new Point(e.X, e.Y));
                Invalidate();
            }
#elif WHEEL
#elif ENTERLEAVE
#else
            Graphics g = CreateGraphics();

            g.DrawString("Down", Font, Brushes.Black, e.X, e.Y);

            g.Dispose();
#endif
        }

        private void MouseDownForm_MouseClick(object sender, MouseEventArgs e)
        {
#if ARRAY
#elif WHEEL
#elif ENTERLEAVE
#else
            Graphics g = this.CreateGraphics();

            g.DrawString("Click", Font, Brushes.Green, e.X, e.Y);

            g.Dispose();
#endif
        }

        private void MouseDownForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
#if ARRAY
#elif WHEEL
#elif ENTERLEAVE
#else
            using(Graphics g = CreateGraphics())// this.CreateGraphics();
            {
                g.DrawString("DoubleClick", Font, Brushes.YellowGreen, Width / 2 - Font.Size * 11 / 2, Height / 2 - Font.Height - 20);
            }
#endif
        }

        private void MouseDownForm_Click(object sender, EventArgs e)
        {
#if ARRAY
#elif WHEEL
#elif ENTERLEAVE
#else
            ClickedCount++;
            Text = ClickedCount + " Click!";
#endif
        }
    }
}
