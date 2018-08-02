﻿//#define PEN
//#define DASHSTYLE
//#define DASHANIMATION
//#define PENCAP
//#define LINEJOIN
//#define PENALIGN
//#define HATCHBRUSH
//#define LINEARGRADIENT
//#define TEXTUREBRUSH
//#define DRAWXXX
//#define COLOR_DIALOG
//#define GET_GRAPHICS
//#define GET_GRAPHICS_byMEASUREITEM
//#define GET_GRAPHICS_byDRAWITEM
#define GET_GRAPHICS_byFROMIMAGE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
#elif COLOR_DIALOG
        Button btnForeground, btnBackground;
#elif GET_GRAPHICS
        Button btnGraphics;
#elif GET_GRAPHICS_byFROMIMAGE
        Button btnGraphicsFromImage;
        Image m_img = null;
#elif GET_GRAPHICS_byMEASUREITEM
        ListBox lbx;
        //ComboBox cbx;
        //CheckedListBox ckb;
        //TabControl tab;
#elif GET_GRAPHICS_byDRAWITEM
        ListBox lbx;
        //ComboBox cbx;       
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
#elif COLOR_DIALOG
            btnForeground = new Button();
            btnForeground.Name = "btnForeground";
            btnForeground.Text = "전경색 설정";
            btnForeground.SetBounds(120, 150, 100, 50);
            btnForeground.Click += ColorDialogButton_Click;

            btnBackground = new Button();
            btnBackground.Name = "btnBackground";
            btnBackground.Text = "배경색 설정";
            btnBackground.SetBounds(10, 150, 100, 50);
            btnBackground.Click += ColorDialogButton_Click;

            this.Controls.Add(btnBackground);
            this.Controls.Add(btnForeground);
#elif GET_GRAPHICS

            this.Paint += GDIPlusForm_PaintEventHandler;

            btnGraphics = new Button();
            btnGraphics.Name = "btnGetGraphics";
            btnGraphics.Text = "버튼위에 GDI+ 출력";
            btnGraphics.SetBounds(10, 10, 200, 100);
            btnGraphics.Click += GraphicsButton_Click;
            this.Controls.Add(btnGraphics);

#elif GET_GRAPHICS_byFROMIMAGE

            btnGraphicsFromImage = new Button();
            btnGraphicsFromImage.Name = "btnGraphicsFromImage";
            btnGraphicsFromImage.Text = "그림위에 GDI+ 출력";
            btnGraphicsFromImage.SetBounds(10, 50, 200, 100);
            btnGraphicsFromImage.Click += GraphicsButton_Click;
            this.Controls.Add(btnGraphicsFromImage);

#elif GET_GRAPHICS_byMEASUREITEM

            lbx = new ListBox();
            lbx.SetBounds(10, 10, 200, 100);
            lbx.Items.Add("사과");
            lbx.Items.Add("포도");
            lbx.Items.Add("수박");
            lbx.DrawMode = DrawMode.OwnerDrawVariable;// MeasureItem 이벤트 호출 ---> DrawItem 이벤트 호출
            lbx.MeasureItem += ListBox_MeasureItemEvent;
            lbx.DrawItem += ListBox_DrawItemEvent;
            this.Controls.Add(lbx);

#elif GET_GRAPHICS_byDRAWITEM

            lbx = new ListBox();
            lbx.SetBounds(10, 10, 200, 100);
            lbx.Items.Add("사과");
            lbx.Items.Add("포도");
            lbx.Items.Add("수박");
            lbx.DrawMode = DrawMode.OwnerDrawFixed;// DrawItem 이벤트만 호출
            lbx.DrawItem += ListBox_DrawItemEvent;
            this.Controls.Add(lbx);
#else
            Alpha = 128;
#endif
        }

        private void BtnGetGraphicsFromImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#if GET_GRAPHICS_byMEASUREITEM

        private void ListBox_MeasureItemEvent(object sender, MeasureItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Console.WriteLine($"{e} : MeasureItem 이벤트 실행");
        }

        private void ListBox_DrawItemEvent(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = Brushes.Black;

            switch (e.Index)
            {
                case 0:
                    brush = Brushes.Red;
                    break;

                case 1:
                    brush = Brushes.Violet;
                    break;

                case 2:
                    brush = Brushes.Green;
                    break;
            }

            g.DrawString($"{lbx.Items[e.Index]}", e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            Console.WriteLine($"{e} : DrawItem 이벤트 실행");
        }
#endif

#if GET_GRAPHICS_byDRAWITEM
        private void ListBox_DrawItemEvent(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = Brushes.Black;

            switch (e.Index)
            {
                case 0:
                    brush = Brushes.Red;
                    break;

                case 1:
                    brush = Brushes.Violet;
                    break;

                case 2:
                    brush = Brushes.Green;
                    break;
            }

            g.DrawString($"{lbx.Items[e.Index]}", e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            Console.WriteLine($"{e} : DrawItem 이벤트 실행");
        }
#endif

#if GET_GRAPHICS
        /// <summary>
        /// Paint 이벤트 핸들러를 통해 Graphics 객체 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GDIPlusForm_PaintEventHandler(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.FillRectangle(new SolidBrush(Color.Green), this.ClientRectangle);
        }

        /// <summary>
        /// Control 클래스의 CreateGraphics 메서드를 통해 Graphics 객체 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            switch (btn.Name)
            {
                case "btnGraphics":
                    using (Graphics g = btnGraphics.CreateGraphics())
                    {
                        g.FillRectangle(new SolidBrush(Color.Yellow), btnGraphics.ClientRectangle);
                    }//g.Dispose() 반드시 필요
                    break;
            }
        }
#endif
#if GET_GRAPHICS_byFROMIMAGE
        /// <summary>
        /// Control 클래스의 CreateGraphics 메서드를 통해 Graphics 객체 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            switch (btn.Name)
            {
                case "btnGraphicsFromImage":
                    Image img = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\Baby.jpg");
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        Font font = new Font("돋움", 20);
                        Brush brush = Brushes.Pink;
                        g.DrawString("이미지에 글씨쓰기", font, brush, 10, 10);
                    }//g.Dispose() 반드시 필요

                    if(m_img == null)
                    {
                        FileInfo file = new FileInfo(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\Baby_copied.png");
                        if (file.Exists) file.Delete();

                        img.Save(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\Baby_copied.png", System.Drawing.Imaging.ImageFormat.Png);//@"D:\downloads\temp\Images\Baby_copied.png"
                        this.m_img = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\Baby_copied.png");
                    }
                    this.Invalidate(this.ClientRectangle);
                    break;
            }
        }
#endif 

#if COLOR_DIALOG
        private void ColorDialogButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                ColorDialog dlg = new ColorDialog();
                dlg.AllowFullOpen = false;//사용자지정 비활성
                dlg.ShowHelp = true;//도움말출력

                switch (btn.Name)
                {
                    case "btnForeground":
                        dlg.Color = this.ForeColor;
                        if(dlg.ShowDialog() == DialogResult.OK)
                        {
                            this.ForeColor = dlg.Color;
                        }
                        break;

                    case "btnBackground":
                        dlg.Color = this.BackColor;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            this.BackColor = dlg.Color;
                        }
                        break;
                }
            }
        }
#endif

        private void GDIPlusForm_Load(object sender, EventArgs e)
        {
#if TEXTUREBRUSH
            ImgSrc = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\baby.jpg");//baby.jpg clover.jpg
#endif
        }

        /// <summary>
        /// Control 클래스의 OnPaint 메서드 재정의하여 Graphics 객체 얻기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

#elif COLOR_DIALOG
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(this.ForeColor);
            Font font = new Font("돋움", 20);
            g.DrawString("글자색 변경", font, brush, 10, 20);
#elif GET_GRAPHICS
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.Blue), this.ClientRectangle);
#elif GET_GRAPHICS_byFROMIMAGE
            Graphics g = e.Graphics;
            if (m_img != null) g.DrawImage(m_img, 0, 0);
#elif GET_GRAPHICS_byMEASUREITEM
#elif GET_GRAPHICS_byDRAWITEM
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
#elif COLOR_DIALOG
#elif GET_GRAPHICS
#elif GET_GRAPHICS_byFROMIMAGE
#elif GET_GRAPHICS_byMEASUREITEM
#elif GET_GRAPHICS_byDRAWITEM
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
