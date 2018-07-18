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
    public partial class TimerForm : Form
    {
        public string CurrentTime { get; private set; }
        public Random Rand { get; private set; }

        public TimerForm()
        {
            InitializeComponent();

            Width = 400;
            Height = 350;

            Rand = new Random();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            using(Graphics g = CreateGraphics())
            {
                g.DrawRectangle(Pens.Blue, Rand.Next(400), Rand.Next(300), 10, 10);
            }//g.Dispose();
        }

        private void TimerForm_Load(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            //timer.Interval = 1000;
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            CurrentTime = dt.Hour + "시 " + dt.Minute + "분 " + dt.Second + "초";
            Invalidate();
        }

        private void TimerForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(CurrentTime, Font, Brushes.Black, 10, 10);
        }
    }
}
