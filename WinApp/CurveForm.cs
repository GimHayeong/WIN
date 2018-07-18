//#define CURVELIST
//#define POINTLIST
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
    // Capture : 컨트롤 클래스는 마우스 다운 / 업 할 때 자동으로 캡처하기/캡처풀기 를 한다. 

    public partial class CurveForm : Form
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
#if CURVELIST
        // Rectangle 로 저장하면 시작점과 끝점을 따로 저장하지 않아도 되어 편리하나 메모리 소비가 많다.
        public List<Rectangle> arList { get; private set; }
#elif POINTLIST
        // Point로 저장하면 메모리 소비가 많으나 선분이 끊어지는 부분을 따로 저장해야 한다.
        public List<Point> arList { get; private set; }
        // 선분이 끊어지는 부분 저장
        public List<int> arLastList { get; private set; }
#endif

        public CurveForm()
        {
            InitializeComponent();
#if CURVELIST
            arList = new List<Rectangle>();
            this.Paint += CurveForm_Paint;
#elif POINTLIST
            arList = new List<Point>();
            arLastList = new List<int>();
            this.MouseUp += CurveForm_MouseUp;
            this.Paint += CurveForm_Paint;
#endif
        }

        private void CurveForm_MouseUp(object sender, MouseEventArgs e)
        {
#if POINTLIST

#endif
        }

        private void CurveForm_Paint(object sender, PaintEventArgs e)
        {
#if CURVELIST
            foreach(Rectangle r in arList)
            {
                e.Graphics.DrawLine(Pens.Black, r.Left, r.Top, r.Right, r.Bottom);
            }
#elif POINTLIST
            Point pos, p;
            int idx = 0;
            for(int i = 0; i < arLastList.Count; i++)
            {
                pos = new Point();
                p = new Point();
                for(int j = 0; j < arLastList[i]; j++)
                {
                    p = arList[idx];
                    if (!pos.IsEmpty)
                    {
                        e.Graphics.DrawLine(Pens.Black, pos.X, pos.Y, p.X, p.Y);
                        idx++;
                    }
                    pos = p;
                }
            }
#endif
        }

        private void CurveForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PosX = e.X;
                PosY = e.Y;
#if POINTLIST
                arLastList.Add(1);
#endif
            }
        }

        private void CurveForm_MouseMove(object sender, MouseEventArgs e)
        {
            // 캡처가 풀리면 자동으로 그리기를 중단하기 위해 캡처상태인지 체크

            if(Capture && e.Button == MouseButtons.Left)
            {
                using (Graphics g = CreateGraphics())
                {
                    g.DrawLine(Pens.Black, PosX, PosY, e.X, e.Y);
#if CURVELIST
                    arList.Add(Rectangle.FromLTRB(PosX, PosY, e.X, e.Y));
#elif POINTLIST
                    arList.Add(new Point(e.X, e.Y));
                    arLastList[arLastList.Count - 1]++;
#endif
                    PosX = e.X;
                    PosY = e.Y;
                }//g.Dispose()
            }
           
        }
    }
}
