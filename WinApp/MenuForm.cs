using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class MenuForm : Form
    {
        public enum Shapes { CIRCLE, RECT, LINE };
        public int PenWidth { get; private set; }
        public Color InColor { get; private set; }
        public Shapes ShapeType { get; private set; }
        public string SelectedText { get; private set; }
        private PosForm dlgModalless;


        public MenuForm()
        {
            InitializeComponent();

            PenWidth = 1;
            InColor = Color.Red;
            ShapeType = Shapes.CIRCLE;
        }

        private void mainMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            if(mnu != null)
            {
                switch (mnu.Name)
                {
                    case "mnuNew":
#if MDIFORM
                        TimerForm child = new TimerForm();
                        child.MdiParent = this;
                        child.Show();
#else 
                        rtbContents.Visible = true;
                        rtbContents.Clear();
#endif
                        break;

                    case "mnuOpen":
                        rtbContents.Visible = true;
                        OpenFileDialog dlgOpen = new OpenFileDialog();
                        dlgOpen.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// @"C:\";
                        if(dlgOpen.ShowDialog() == DialogResult.OK)
                        {
                            rtbContents.Text = File.ReadAllText(dlgOpen.FileName);
                        }
                        break;

                    case "mnuSave":
                        rtbContents.Visible = true;
                        SaveFileDialog dlgSave = new SaveFileDialog();
                        dlgSave.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        dlgSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        if(dlgSave.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(dlgSave.FileName, rtbContents.Text);
                        }
                        break;

                    case "mnuSelectFolder":
                        rtbContents.Visible = true;
                        FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                        dlgFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                        if(dlgFolder.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show(dlgFolder.SelectedPath + "를 기본폴더로 선택했습니다.");
                        }
                        break;

                    case "mnuFont":
                        rtbContents.Visible = true;
                        FontDialog dlgFont = new FontDialog();
                        if(dlgFont.ShowDialog() == DialogResult.OK)
                        {
                            rtbContents.Font = dlgFont.Font;
                        }
                        break;

                    case "mnuBackground":
                        rtbContents.Visible = true;
                        ColorDialog dlgColor = new ColorDialog();
                        if(dlgColor.ShowDialog() == DialogResult.OK)
                        {
                            rtbContents.BackColor = dlgColor.Color;
                        }
                        break;

                    case "mnuExit":
#if MDIFORM
                        Form child = ActiveMdiChild;
                        if(child != null)
                        {
                            child.Close();
                        }
#endif
                        rtbContents.Visible = true;
                        Application.Exit();
                        break;

                    case "mnuCopy":
                        rtbContents.Visible = true;
                        SelectedText = rtbContents.SelectedText ?? String.Empty;
                        break;

                    case "mnuCut":
                        rtbContents.Visible = true;
                        SelectedText = rtbContents.SelectedText ?? String.Empty;
                        rtbContents.SelectedText = "";
                        break;

                    case "mnuPaste":
                        rtbContents.Visible = true;
                        rtbContents.SelectedText = SelectedText;
                        break;

                    case "mnuCircle":
                        rtbContents.Visible = false;
                        ShapeType = Shapes.CIRCLE;
                        Invalidate();
                        break;

                    case "mnuRectangle":
                        rtbContents.Visible = false;
                        ShapeType = Shapes.RECT;
                        Invalidate();
                        break;

                    case "mnuLine":
                        rtbContents.Visible = false;
                        ShapeType = Shapes.LINE;
                        Invalidate();
                        break;

                    case "mnuRed":
                        rtbContents.Visible = false;
                        InColor = Color.Red;
                        Invalidate();
                        break;

                    case "mnuBlue":
                        rtbContents.Visible = false;
                        InColor = Color.Blue;
                        Invalidate();
                        break;

                    case "mnuBold":
                        rtbContents.Visible = false;
                        PenWidth = (PenWidth == 1) ? 5 : 1;
                        Invalidate();
                        break;

                    case "mnuInfo":
                        AboutForm dlgModal = new AboutForm();
                        dlgModal.Owner = this;
                        dlgModal.ShowDialog();
                        dlgModal.Dispose();
                        break;

                    case "mnuPos":
                        rtbContents.Visible = false;
                        lblPosInfo.Visible = true;
                        if(dlgModalless == null || dlgModalless.IsDisposed)
                        {
                            dlgModalless = new PosForm();
                            dlgModalless.Owner = this;
                            dlgModalless.Apply += DlgModalless_Apply;
                            dlgModalless.PosLeft = lblPosInfo.Left;
                            dlgModalless.PosTop = lblPosInfo.Top;
                            dlgModalless.PosText = lblPosInfo.Text;
                            dlgModalless.Show();
                        }
                        break;


#if MDIFORM
                    case "mnuCascade":
                        LayoutMdi(MdiLayout.Cascade);
                        break;

                    case "mnuHorizontal":
                        LayoutMdi(MdiLayout.TileHorizontal);
                        break;

                    case "mnuVertical":
                        LayoutMdi(MdiLayout.TileVertical);
                        break;
#endif
                }
            }
        }

        private void DlgModalless_Apply(object sender, EventArgs e)
        {
            lblPosInfo.Left = dlgModalless.PosLeft;
            lblPosInfo.Top = dlgModalless.PosTop;
            lblPosInfo.Text = dlgModalless.PosText;
        }

        private void MenuForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, PenWidth);
            SolidBrush brush = new SolidBrush(InColor);

            switch (ShapeType)
            {
                case Shapes.CIRCLE:
                    e.Graphics.FillEllipse(brush, 100, 50, 100, 100);
                    e.Graphics.DrawEllipse(pen, 100, 50, 100, 100);
                    break;

                case Shapes.RECT:
                    e.Graphics.FillRectangle(brush, 100, 50, 100, 100);
                    e.Graphics.DrawRectangle(pen, 100, 50, 100, 100);
                    break;

                case Shapes.LINE:
                    e.Graphics.DrawLine(pen, 100, 50, 200, 150);
                    break;
            }
        }

        private void mnuMainStrip_MenuActivate(object sender, EventArgs e)
        {
            mnuBold.Checked = (PenWidth == 5);
            mnuCircle.Checked = (ShapeType == Shapes.CIRCLE);
            mnuRectangle.Checked = (ShapeType == Shapes.RECT);
            mnuLine.Checked = (ShapeType == Shapes.LINE);

            mnuRed.Checked = (InColor == Color.Red);
            mnuBlue.Checked = (InColor == Color.Blue);

            mnuRed.Enabled = mnuBlue.Enabled = (ShapeType != Shapes.LINE);
        }

        private void mnuBgContext_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            if(mnu != null)
            {
                switch (mnu.Name)
                {
                    case "mnuBgRed":
                        BackColor = Color.Red;
                        break;

                    case "mnuBgBlue":
                        BackColor = Color.Blue;
                        break;

                    case "mnuBgGreen":
                        BackColor = Color.Green;
                        break;
                }
            }
        }

        private void mnuBgStrip_Opening(object sender, CancelEventArgs e)
        {
            mnuBgRed.Checked = (BackColor == Color.Red);
            mnuBgBlue.Checked = (BackColor == Color.Blue);
            mnuBgGreen.Checked = (BackColor == Color.Green);
        }

        private void MenuForm_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point pos = new Point(e.X, e.Y);// 작업영역좌표
                pos = PointToScreen(pos);//화면좌표로 변경

                if (e.X < Width / 4) 
                {
                    mnuJungsikStrip.Show(pos.X, pos.Y);
                }
                else if (e.X > Width / 4 * 3)
                {
                    mnuHansikStrip.Show(pos.X, pos.Y);
                }
                else
                {
                    mnuBgStrip.Show();
                }
            }
        }
    }
}
