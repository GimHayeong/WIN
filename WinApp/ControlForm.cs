using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class ControlForm : Form
    {
        public int FontSize { get; private set; }

        public ControlForm()
        {
            InitializeComponent();
            ddlType.SelectedIndex = 0;
            FontSize = 10;
            Image img = Properties.Resources.android_96X32;
            imageList1.Images.AddStrip(img);
        }

        private void btnProgressbar_Click(object sender, EventArgs e)
        {
            prgValue.Style = (chkIsMarquee.Checked) ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;

            for(int i=0; i<100; i++)
            {
                prgStep.PerformStep();
                prgValue.Value = i;
                Thread.Sleep(30);
            }

            MessageBox.Show("작업을 완료했습니다.");
            
            if(chkIsMarquee.Checked)
            {
                prgValue.MarqueeAnimationSpeed = 0;
                prgStep.MarqueeAnimationSpeed = 0;
            }
            prgValue.Value = 0;
            prgStep.Value = 0;
        }

        private void trkFontSize_Scroll(object sender, EventArgs e)
        {
            FontSize = trkFontSize.Value;
            Invalidate();
        }

        private void ControlForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("대한민국", new Font("궁서", FontSize), Brushes.Black, 10, 10);

            for(int i=0; i<imageList1.Images.Count; i++)
            {
                //e.Graphics.TranslateTransform(200, 200);
                imageList1.Draw(e.Graphics, 200 + 32 * i, 200 + 32 * i, i);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            Text = dtpDate.Value.ToString();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            tip.SetToolTip(dtpDate, "날짜를 선택하세요");
            tip.SetToolTip(ddlType, "유형을 선택하세요");
        }
    }
}
