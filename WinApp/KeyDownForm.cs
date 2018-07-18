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
    public partial class KeyDownForm : Form
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public KeyDownForm()
        {
            InitializeComponent();

            PosX = 10;
            PosY = 10;
        }

        private void KeyDownForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Black, PosX - 8, PosY - 8, 16, 16);
        }

        private void KeyDownForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    PosX -= 10;
                    Invalidate();
                    break;
                case Keys.Right:
                    PosX += 10;
                    Invalidate();
                    break;
                case Keys.Up:
                    PosY -= 10;
                    Invalidate();
                    break;
                case Keys.Down:
                    PosY += 10;
                    Invalidate();
                    break;
            }
        }
    }
}
