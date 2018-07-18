//#define PEN
//#define DASHSTYLE
//#define DASHANIMATION
//#define PENCAP
//#define LINEJOIN
//#define PENALIGN
//#define HATCHBRUSH
//#define LINEARGRADIENT
#define TEXTUREBRUSH
//#define DRAWXXX

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class GDIPlusForm : Form
    {
#if PEN
#elif DASHSTYLE
#elif DASHANIMATION
        public int Offset { get; set; }
#elif PENCAP
#elif LINEJOIN
#elif PENALIGN
#elif HATCHBRUSH
#elif LINEARGRADIENT
        public float Angle { get; private set; }
#elif TEXTUREBRUSH
        public Image ImgSrc { get; private set; }
#elif DRAWXXX
        public string DrawType { get; private set; }
        public float Tension { get; private set; }
#else
        public int Alpha { get; private set; }
#endif
        public GDIPlusForm()
        {
            InitializeComponent();
#if PEN
#elif DASHSTYLE
#elif DASHANIMATION
            Offset = 0;
            timerOffset.Enabled = true;
#elif PENCAP
#elif LINEJOIN
#elif PENALIGN
#elif HATCHBRUSH
#elif LINEARGRADIENT
            Angle = 0f;
#elif TEXTUREBRUSH
#elif DRAWXXX
            DrawType = "Curve";
            Tension = 0;
#else
            Alpha = 128;
#endif
        }


        private void GDIPlusForm_Load(object sender, EventArgs e)
        {
#if TEXTUREBRUSH
            ImgSrc = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\baby.jpg");//baby.jpg clover.jpg
#endif
        }

        private void GDIPlusForm_Paint(object sender, PaintEventArgs e)
        {
#if PEN
            Pen pen = new Pen(Color.Blue, 3);
            e.Graphics.DrawLine(pen, 10, 10, 200, 10);

            pen.Color = Color.LightSalmon;

            for(int i=1; i<=5; i++)
            {
                pen.Width = i;
                e.Graphics.DrawLine(pen, 10, 50 + i * 10, 200, 50 + i * 10);
            }
            Brush brush = new HatchBrush(HatchStyle.Sphere, Color.Red, Color.LightGreen);
            pen = new Pen(brush, 20);
            e.Graphics.DrawEllipse(pen, 10, 150, 200, 100);
#elif DASHSTYLE
            Pen pen = new Pen(Color.Black, 3);

            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(pen, 10, 10, 200, 10);

            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen, 10, 30, 200, 30);

            pen.DashStyle = DashStyle.Dash;
            e.Graphics.DrawLine(pen, 10, 50, 200, 50);

            pen.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(pen, 10, 70, 200, 70);

            pen.DashStyle = DashStyle.DashDotDot;
            e.Graphics.DrawLine(pen, 10, 90, 200, 90);

            pen.DashStyle = DashStyle.Dash;
            for(int i = 1; i<10; i += 2)
            {
                pen.Width = i;
                e.Graphics.DrawLine(pen, 10, 120 + i * 10, 200, 120 + i * 10);
            }

            pen.Width = 5;
            pen.Color = Color.Brown;
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 3, 4, 5, 6, 7, 8 };//선,공백,선,공백...
            e.Graphics.DrawLine(pen, 210, 10, 450, 10);

            pen.Color = Color.BurlyWood;
            for(int i=0; i<10; i++)
            {
                pen.DashOffset = i;
                e.Graphics.DrawLine(pen, 210, 50 + i * 20, 450, 50 + i * 20);
            }
#elif DASHANIMATION
            Pen pen = new Pen(Color.Goldenrod, 2);
            pen.DashStyle = DashStyle.Dash;
            pen.DashOffset = Offset;
            e.Graphics.DrawRectangle(pen, 50, 10, 200, 150);
#elif PENCAP
            Pen pen = new Pen(Color.PaleGoldenrod, 9);
            pen.StartCap = pen.EndCap = LineCap.Flat;
            e.Graphics.DrawLine(pen, 10, 20, 200, 20);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 20);

            pen.StartCap = pen.EndCap = LineCap.Round;
            e.Graphics.DrawLine(pen, 10, 40, 200, 40);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 40);

            pen.StartCap = pen.EndCap = LineCap.Square;
            e.Graphics.DrawLine(pen, 10, 60, 200, 60);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 60);

            pen.StartCap = pen.EndCap = LineCap.Triangle;
            e.Graphics.DrawLine(pen,10, 80, 200, 80);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 80);

            pen.StartCap = pen.EndCap = LineCap.RoundAnchor;
            e.Graphics.DrawLine(pen, 10, 100, 200, 100);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 100);

            pen.StartCap = pen.EndCap = LineCap.SquareAnchor;
            e.Graphics.DrawLine(pen, 10, 120, 200, 120);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 120);

            pen.StartCap = pen.EndCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen, 10, 140, 200, 140);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 140);

            pen.StartCap = pen.EndCap = LineCap.DiamondAnchor;
            e.Graphics.DrawLine(pen, 10, 160, 200, 160);
            e.Graphics.DrawString(pen.StartCap.ToString(), Font, Brushes.Black, 210, 160);

            pen.StartCap = pen.EndCap = LineCap.Flat;
            pen.Width = 15;
            pen.DashStyle = DashStyle.Dash;
            pen.DashCap = DashCap.Flat;
            e.Graphics.DrawLine(pen, 10, 200, 200, 200);
            e.Graphics.DrawString("DashCap:" + pen.DashCap.ToString(), Font, Brushes.Black, 210, 200);

            pen.DashCap = DashCap.Round;
            e.Graphics.DrawLine(pen, 10, 220, 200, 220);
            e.Graphics.DrawString("DashCap:" + pen.DashCap.ToString(), Font, Brushes.Black, 210, 220);

            pen.DashCap = DashCap.Triangle;
            e.Graphics.DrawLine(pen, 10, 240, 200, 240);
            e.Graphics.DrawString("DashCap:" + pen.DashCap.ToString(), Font, Brushes.Black, 210, 240);
#elif LINEJOIN
            Pen pen = new Pen(Color.Black, 15);
            pen.LineJoin = LineJoin.Miter;
            e.Graphics.DrawRectangle(pen, 10, 10, 80, 80);
            e.Graphics.DrawString(pen.LineJoin.ToString(), Font, Brushes.Gold, 10, 100);

            pen.LineJoin = LineJoin.MiterClipped;
            e.Graphics.DrawRectangle(pen, 120, 10, 80, 80);
            e.Graphics.DrawString(pen.LineJoin.ToString(), Font, Brushes.Gold, 130, 100);

            pen.LineJoin = LineJoin.Bevel;
            e.Graphics.DrawRectangle(pen, 10, 120, 80, 80);
            e.Graphics.DrawString(pen.LineJoin.ToString(), Font, Brushes.Gold, 10, 220);

            pen.LineJoin = LineJoin.Round;
            e.Graphics.DrawRectangle(pen, 120, 120, 80, 80);
            e.Graphics.DrawString(pen.LineJoin.ToString(), Font, Brushes.Gold, 130, 220);
#elif PENALIGN
            // PenAlignment : 폐곡선을 그릴때만 적용됨
            // Center와 Inset 만 구현되어 있고 나머지는 구현되어 있지 않아 Center(Default) 와 동일하다.

            Pen pen = new Pen(Color.DodgerBlue, 15);
            pen.Alignment = PenAlignment.Center;
            e.Graphics.DrawRectangle(pen, 10, 10, 80, 80);
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, 80, 80);

            pen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawRectangle(pen, 120, 10, 80, 80);
            e.Graphics.DrawRectangle(Pens.Black, 120, 10, 80, 80);

            pen.Alignment = PenAlignment.Outset;
            e.Graphics.DrawRectangle(pen, 10, 120, 80, 80);
            e.Graphics.DrawRectangle(Pens.Black, 10, 120, 80, 80);
            
            pen.Alignment = PenAlignment.Left;
            e.Graphics.DrawRectangle(pen, 120, 120, 80, 80);
            e.Graphics.DrawRectangle(Pens.Black, 120, 120, 80, 80);
#elif HATCHBRUSH
            // HatchBrush: 무늬가 있는 브러쉬. 속성들은 읽기전용이므로 변경하려면 새 브러쉬를 생성해야 함.

            int x, y;
            HatchStyle style = (HatchStyle)0;
            for(y = 0; ; y++)
            {
                for(x = 0; x < 8; x++)
                {
                    HatchBrush brush = new HatchBrush(style, Color.White, Color.Black);
                    e.Graphics.FillRectangle(brush, x * 70, y * 70, 60, 60);
                    style++;
                    if(style > (HatchStyle)52) { break; }
                }
                if(style > (HatchStyle)52) { break; }
            }
#elif LINEARGRADIENT
            LinearGradientBrush brushPoint = new LinearGradientBrush(new Point(0, 0), new Point(100, 100), Color.Blue, Color.Yellow);
            e.Graphics.FillRectangle(brushPoint, 0, 0, 300, 150);

            LinearGradientBrush brushRect = new LinearGradientBrush(new Rectangle(0, 0, 100, 100), Color.White, Color.Black, Angle);
            e.Graphics.FillRectangle(brushRect, 0, 200, 300, 150);
            e.Graphics.DrawString("Angle: " + Angle, Font, Brushes.Gainsboro, 0, 370);
#elif TEXTUREBRUSH
            bool isOrigin = true;
            TextureBrush brush = new TextureBrush(ImgSrc);// new TextureBrush(img, WrapMode.TileFlipX);
            if(isOrigin)
            {
                // 원점(0, 0)에 출력
                e.Graphics.FillRectangle(brush, ClientRectangle);
            } else
            {
                // 이동 지점(50, 50)에 출력 : 
                //      FillRectangle 에서 시작점을 50, 50으로 이동하므로 
                //      텍스처브러시의 시작점도 Matrix 메서드를 이용해 50, 50 이동해 시작 원점 재정렬 필요(최좌측/최상측 이미지 이동위치만큼 잘림현상 해결).
                brush.Transform = new Matrix(1, 0, 0, 1, 50, 50);
                e.Graphics.FillRectangle(brush, 50, 50, ClientRectangle.Right, ClientRectangle.Bottom);
            }
#elif DRAWXXX
            if (DrawType == "Normal") {
                Point[] pointData = { new Point(112, 0), new Point(0, 83), new Point(45, 215), new Point(185, 215), new Point(223, 83), new Point(112, 0) };
                e.Graphics.DrawLines(Pens.Black, pointData);
            }
            else if(DrawType == "Polygon")
            {
                // XXXPolygon : 시작점과 끝점을 강제로 연결하여 폐곡선을 그린다.
                Point[] koreaData = { new Point(292, 6), new Point(331, 45), new Point(307, 45), new Point(269, 77)
                                    , new Point(274, 111), new Point(251, 116), new Point(207, 149), new Point(165, 155)
                                    , new Point(161, 190), new Point(201, 206), new Point(239, 270), new Point(258, 280)
                                    , new Point(257, 306), new Point(249, 313), new Point(251, 335), new Point(263, 333)
                                    , new Point(252, 364), new Point(231, 380), new Point(203, 378), new Point(201,392)
                                    , new Point(181, 391), new Point(157, 389), new Point(143, 404), new Point(117, 402)
                                    , new Point(108, 416), new Point(95, 403), new Point(108, 393), new Point(96, 378)
                                    , new Point(121, 341), new Point(109, 302), new Point(96, 303), new Point(95, 292)
                                    , new Point(114, 285), new Point(132, 292), new Point(121, 267), new Point(114, 243)
                                    , new Point(74, 231), new Point(72, 251), new Point(26, 231), new Point(70, 205)
                                    , new Point(51, 198), new Point(71, 166), new Point(13, 142), new Point(90, 103)
                                    , new Point(132, 73), new Point(151, 56), new Point(161, 71), new Point(202, 79)
                                    , new Point(211, 66), new Point(206, 51), new Point(241, 49), new Point(266, 30)
                                    , new Point(282, 26), new Point(283, 7)
                                };
                e.Graphics.FillPolygon(Brushes.LightGreen, koreaData);
                e.Graphics.DrawPolygon(new Pen(Color.Blue, 3), koreaData);
            }
            else if(DrawType == "Bezier")
            {
                e.Graphics.DrawBezier(Pens.Black, new Point(10, 10), new Point(150, 30), new Point(30, 150), new Point(200, 200));
            }
            else if(DrawType == "Curve")
            {
                Point[] curveData = { new Point(10, 80), new Point(100, 10), new Point(80, 200), new Point(200, 150) };
                e.Graphics.DrawCurve(Pens.Black, curveData, Tension);
                e.Graphics.DrawString("장력: " + Tension, Font, Brushes.Black, 0, 220);
            }

#else
            e.Graphics.FillEllipse(Brushes.Blue, 10, 10, 150, 100);
            SolidBrush brush = new SolidBrush(Color.FromArgb(Alpha, 255, 0, 0));
            e.Graphics.FillRectangle(brush, 50, 50, 150, 100);
            e.Graphics.DrawString("방향키↑: 투명도 증가, 방향키↓: 투명도 감소", Font, Brushes.Black, 10, 160);
#endif
        }

        private void GDIPlusForm_KeyDown(object sender, KeyEventArgs e)
        {
#if PEN
#elif DASHSTYLE
#elif DASHANIMATION
#elif PENCAP
#elif LINEJOIN
#elif PENALIGN
#elif HATCHBRUSH
#elif LINEARGRADIENT
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Angle += 5f;
                    Invalidate();
                    break;

                case Keys.Down:
                    Angle -= 5f;
                    Invalidate();
                    break;
            }
#elif TEXTUREBRUSH
#elif DRAWXXX
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Tension += 0.1f;
                    Invalidate();
                    break;

                case Keys.Down:
                    Tension -= 0.1f;
                    Invalidate();
                    break;
            }
#else
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Alpha = Math.Max(0, Alpha - 25);
                    Invalidate();
                    break;

                case Keys.Down:
                    Alpha = Math.Min(255, Alpha + 25);
                    Invalidate();
                    break;
            }
#endif
        }

        private void timerOffset_Tick(object sender, EventArgs e)
        {
#if DASHANIMATION
            Offset--;
            if (Offset < 0) Offset = 3;
            Invalidate();
#else
#endif
        }

    }
}
