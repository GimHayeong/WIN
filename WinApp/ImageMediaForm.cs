//#define BACKGROUNDIMAGE
//#define BEFOREDOUBLEBUFFER
//#define AFTERDOUBLEBUFFER
//#define VECTOR
//#define IMAGEATTRIBUTE
//#define RESOURCES
#define CONTROLS

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class ImageForm : Form
    {
#if BACKGROUNDIMAGE
        // 백그라운드에서 비트맵에 출력할 이미지를 모두 그린 후 결과만 출력
        public Bitmap BmpSrc { get; private set; }
#elif BEFOREDOUBLEBUFFER
        public int BallX { get; private set; }
        public int BallY { get; private set; }
        private const int R = 15;
#elif AFTERDOUBLEBUFFER
        public int BallX { get; private set; }
        public int BallY { get; private set; }
        private const int R = 15;
        public Bitmap BmpSrc { get; private set; }
#elif VECTOR
        public Metafile MetaSrc { get; private set; }
#elif IMAGEATTRIBUTE
        public Image ImgSrc { get; private set; }
        public ImageAttributes ImgAttrs { get; private set; }
        public float Threshold { get; private set; }
        public float Gamma { get; private set; }
        public float Bright { get; private set; }
#elif RESOURCES
        public Bitmap ResPng { get; private set; }
        public Bitmap ResBmp { get; private set; }
        public Icon ResIcon { get; private set; }
#elif CONTROLS
        public DashStyle Dash { get; set; }
#else
        public Image ImgSrc { get; private set; }
#endif
        public ImageForm()
        {
            InitializeComponent();
#if AFTERDOUBLEBUFFER || IMAGEATTRIBUTE
            DoubleBuffered = true;
#elif RESOURCES
            Text = Properties.Resources.AppProjectName;
#elif CONTROLS
            lstbxDash.DrawMode = DrawMode.OwnerDrawFixed;
#endif
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
#if BACKGROUNDIMAGE
            BmpSrc = new Bitmap(600, 400);
#elif BEFOREDOUBLEBUFFER
            BallX = 10;
            BallY = 100;
            timerDoubleBuffer.Enabled = true;
            timerDoubleBuffer.Start();
            timerDoubleBuffer.Tick += TimerDoubleBuffer_Tick;
#elif AFTERDOUBLEBUFFER
            BallX = 10;
            BallY = 100;
            timerDoubleBuffer.Enabled = true;
            timerDoubleBuffer.Start();
            timerDoubleBuffer.Tick += TimerDoubleBuffer_Tick;
#elif VECTOR
            MetaSrc = new Metafile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\dog.wmf");
            SetStyle(ControlStyles.ResizeRedraw, true);
#elif IMAGEATTRIBUTE
            InitImage();
#elif RESOURCES
            ResPng = Properties.Resources.MyCar;
            ResBmp = Properties.Resources.MyBmp;
            ResIcon = Properties.Resources.MyIcon;
#elif CONTROLS

#else
            ImgSrc = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\baby.jpg");//baby.jpg clover.jpg
#endif
    }


#if AFTERDOUBLEBUFFER || IMAGEATTRIBUTE
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // DoubleBuffered = true 적용하려면 반드시 재정의(내용 없음)
        }
#endif

        private void TimerDoubleBuffer_Tick(object sender, EventArgs e)
        {
#if BEFOREDOUBLEBUFFER
            BallX += 6;
            if(BallX > ClientRectangle.Right) { BallX = 0; }
            Invalidate();
#elif AFTERDOUBLEBUFFER
            if(BmpSrc == null || BmpSrc.Width != ClientSize.Width || BmpSrc.Height != ClientSize.Height)
            {
                BmpSrc = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            Graphics g = Graphics.FromImage(BmpSrc);
            g.Clear(SystemColors.Window);//윈도우 화면 다시 그림(OnPaintBackground 메서드 기능)

            BallX += 6;
            if(BallX > ClientRectangle.Right) { BallX = 0; }

            DisplayGrid(g);
            Invalidate();
#elif VECTOR
#elif IMAGEATTRIBUTE
#elif RESOURCES
#elif CONTROLS
#else
#endif
        }

        private void ImageForm_Paint(object sender, PaintEventArgs e)
        {
#if BACKGROUNDIMAGE
            e.Graphics.DrawImage(BmpSrc, 0, 0);
#elif BEFOREDOUBLEBUFFER
            DisplayGrid(e.Graphics);
#elif AFTERDOUBLEBUFFER
            if(BmpSrc != null)
            {
                e.Graphics.DrawImage(BmpSrc, 0, 0);
            }
#elif VECTOR
            e.Graphics.DrawImage(MetaSrc, ClientRectangle);
#elif IMAGEATTRIBUTE
            e.Graphics.Clear(SystemColors.Window);//윈도우 화면 다시 그림(OnPaintBackground 메서드 기능)
            e.Graphics.DrawImage(ImgSrc, new Rectangle(0, 0, ImgSrc.Width, ImgSrc.Height), 0, 0, ImgSrc.Width, ImgSrc.Height, GraphicsUnit.Pixel, ImgAttrs);
#elif RESOURCES
            e.Graphics.DrawImage(ResPng, 10, 10);
            e.Graphics.DrawImage(ResBmp, 20, 20);
            e.Graphics.DrawIcon(ResIcon, 100, 20);
#elif CONTROLS
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = Dash;
            e.Graphics.DrawRectangle(pen, 200, 20, 140, 140);
#else
            // 원본크기
            //e.Graphics.DrawImage(ImgSrc, 0, 0);

            // 확대/축소
            //e.Graphics.DrawImage(ImgSrc, 0, 0, 200, 169);

            // 출력영역(70, 20, 300, 320)만큼 원본이미지 좌측상단을 기준으로 자르기
            //e.Graphics.DrawImage(ImgSrc, 0, 0, new Rectangle(70, 20, 300, 320), GraphicsUnit.Pixel);

            // 원본의 특정영역(70, 20, 300, 300)을 자르기하여 출력영역(10, 10, 200, 200)에 그리기
            e.Graphics.DrawImage(ImgSrc, new Rectangle(10, 10, 200, 200), 70, 170, 300, 300, GraphicsUnit.Pixel);
#endif
        }

        private void DisplayGrid(Graphics g)
        {
#if BEFOREDOUBLEBUFFER || AFTERDOUBLEBUFFER

            for (int x = 0; x < ClientRectangle.Right; x += 10)
            {
                g.DrawLine(Pens.Black, x, 0, x, ClientRectangle.Bottom);
            }
            for (int y = 0; y < ClientRectangle.Bottom; y += 10)
            {
                g.DrawLine(Pens.Black, 0, y, ClientRectangle.Right, y);
            }
            g.FillEllipse(new SolidBrush(Color.LightGreen), BallX - R, BallY - R, R * 2, R * 2);
            g.DrawEllipse(new Pen(Color.Blue, 5), BallX - R, BallY - R, R * 2, R * 2);
#endif
        }

        private void ImageForm_MouseClick(object sender, MouseEventArgs e)
        {
#if BACKGROUNDIMAGE
            if (e.Button == MouseButtons.Left)
            {
                using(Graphics g = Graphics.FromImage(BmpSrc))
                {
                    g.Clear(BackColor);
                    Random rand = new Random();
                    for(int i=0; i<500; i++)
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256), rand.Next(256)));
                        g.FillEllipse(brush, rand.Next(600), rand.Next(400), rand.Next(70) + 30, rand.Next(70) + 30);
                    }
                }
                Invalidate();
            }
#elif BEFOREDOUBLEBUFFER
#elif AFTERDOUBLEBUFFER
#elif VECTOR
#elif IMAGEATTRIBUTE
#elif RESOURCES
#elif CONTROLS
#else
#endif
        }

        private bool ConvertToImageFormat(string oldFile, string extension)
        {
            string newFile;
            ImageFormat imgFormat;

            switch (extension.ToLower())
            {
                case "wmf":
                    newFile = Path.ChangeExtension(oldFile, "wmf");
                    imgFormat = ImageFormat.Wmf;
                    break;

                case "bmp":
                    imgFormat = ImageFormat.Bmp;
                    newFile = Path.ChangeExtension(oldFile, "bmp");
                    break;

                default:
                    return false;
            }
            using (Bitmap img = new Bitmap(oldFile))
            {
                img.Save(newFile, imgFormat);
                FileInfo file = new FileInfo(newFile);
                if (file.Exists)
                {
                    MessageBox.Show(extension.ToUpper() + " 파일로 변환했습니다", "파일변환");
                    return true;
                }
            }

            return false;
        }

        private void ImageForm_KeyDown(object sender, KeyEventArgs e)
        {
#if IMAGEATTRIBUTE
            switch (e.KeyCode)
            {
                case Keys.Space:
                    InitImage();
                    break;

                case Keys.Right:
                    ImgSrc.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case Keys.Left:
                    ImgSrc.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case Keys.Up:
                    ImgSrc.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;

                case Keys.Down:
                    ImgSrc.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    break;

                case Keys.Q:
                    if (Threshold < 1) Threshold += 0.1f;
                    ImgAttrs.SetThreshold(Threshold);
                    break;

                case Keys.W:
                    if (Threshold > 0) Threshold -= 0.1f;
                    ImgAttrs.SetThreshold(Threshold);
                    break;

                case Keys.E:
                    if (Gamma < 5.0) Gamma += 0.1f;
                    ImgAttrs.SetGamma(Gamma);
                    break;

                case Keys.R:
                    if (Gamma > 0.1) Gamma -= 0.1f;
                    ImgAttrs.SetGamma(Gamma);
                    break;

                case Keys.D1:
                    if (Bright < 1.0f) Bright += 0.1f;
                    float[][] matrixBright =
                    {
                        new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 0.0f, 1.0f, 0.0f }
                        , new float[] {Bright, Bright, Bright, 0.0f, 1.0f }
                    };
                    ColorMatrix colorBright = new ColorMatrix(matrixBright);
                    ImgAttrs.SetColorMatrix(colorBright);
                    break;

                case Keys.D2:
                    if (Bright > -1.0f) Bright -= 0.1f;
                    float[][] matrixDark =
                    {
                        new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 0.0f, 1.0f, 0.0f }
                        , new float[] {Bright, Bright, Bright, 0.0f, 1.0f }
                    };
                    ColorMatrix colorDark = new ColorMatrix(matrixDark);
                    ImgAttrs.SetColorMatrix(colorDark);
                    break;

                case Keys.D3:
                    float[][] matrixReverse =
                    {
                        new float[] {-1.0f, 0.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, -1.0f, 0.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, -1.0f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 0.0f, 1.0f, 0.0f }
                        , new float[] {1.0f, 1.0f, 1.0f, 0.0f, 1.0f }
                    };
                    ColorMatrix colorReverse = new ColorMatrix(matrixReverse);
                    ImgAttrs.SetColorMatrix(colorReverse);
                    break;

                case Keys.D4:
                    float[][] matrixGrayScale =
                    {
                        new float[] {0.299f, 0.299f, 0.299f, 0.0f, 0.0f }
                        , new float[] {0.587f, 0.587f, 0.587f, 0.0f, 0.0f }
                        , new float[] {0.114f, 0.114f, 0.114f, 0.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 0.0f, 1.0f, 0.0f }
                        , new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
                    };
                    ColorMatrix colorGrayScale = new ColorMatrix(matrixGrayScale);
                    ImgAttrs.SetColorMatrix(colorGrayScale);
                    break;

                case Keys.D5:
                    ColorMap[] colorMap = new ColorMap[1];
                    colorMap[0] = new ColorMap();
                    colorMap[0].OldColor = Color.White;
                    colorMap[0].NewColor = Color.Blue;
                    ImgAttrs.SetRemapTable(colorMap);
                    break;
            }
            Invalidate();
#else
#endif
        }

        private void btnDingdong_Click(object sender, EventArgs e)
        {
#if RESOURCES

            Button btn = sender as Button;
            if (btn.Name == "btnDingdong")
            {
                SystemSounds.Asterisk.Play();
            }
            else if(btn.Name == "btnPosion")
            {
                SoundPlayer sndPlay = new SoundPlayer();
                //sndPlay.SoundLocation = "";
                sndPlay.Stream = Properties.Resources.poison;
                sndPlay.Play();
            } 
            else if(btn.Name == "btnMobile")
            {
                MessageBox.Show("휴대폰 번호 입력 완료", "입력알림");
            }
#endif            
        }

        private void lnkDaum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
#if CONTROLS
            System.Diagnostics.Process.Start("IExplore", lnkDaum.Text);
            lnkDaum.LinkVisited = true;
#endif
        }

        private void mskPhone_TextChanged(object sender, EventArgs e)
        {
#if CONTROLS
            if (mskPhone.MaskCompleted)
            {
                btnMobile.Enabled = true;
            }
            else
            {
                btnMobile.Enabled = false;
            }
#endif
        }
        private void lstbxDash_DrawItem(object sender, DrawItemEventArgs e)
        {
#if CONTROLS
            //컨트롤.DrawMode = DrawMode.OwnerDrawXXX 로 설정된 경우 이벤트 실행
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = (DashStyle)e.Index;
            e.DrawBackground();
            pen.Color = e.ForeColor;
            e.Graphics.DrawLine(pen, e.Bounds.Left + 10, e.Bounds.Top + 10, e.Bounds.Right - 10, e.Bounds.Top + 10);
            e.DrawFocusRectangle();
#endif
        }

        private void lstbxDash_SelectedIndexChanged(object sender, EventArgs e)
        {
#if CONTROLS
            ListBox listbox = sender as ListBox;
            if(listbox != null)
            {
                Dash = (DashStyle)listbox.SelectedIndex;
                Invalidate();
            }
#endif
        }

        private void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                Text = cbx.Text;
            }
        }

        private void combox_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null && cbx.Items.IndexOf(cbx.Text) > -1)
            {
                Text = cbx.Text;
            }
        }

        private void chkLstInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox chkLst = sender as CheckedListBox;
            if (chkLst != null && chkLst.CheckedItems != null)
            {
                lblSelections.Text = "";
                for (int i = 0; i < chkLst.CheckedItems.Count; i++)
                {
                    lblSelections.Text += chkLst.CheckedItems[i].ToString();
                }
            }
        }

        private void chkLstInfo_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

#if IMAGEATTRIBUTE
        private void InitImage()
        {
            ImgSrc = Image.FromFile(Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf(@"\bin")) + @"\Images\baby.jpg");
            ImgAttrs = new ImageAttributes();
            Threshold = 0.5f;
            Gamma = 1.0f;
            Bright = 0.0f;
        }
#endif
    }
}
