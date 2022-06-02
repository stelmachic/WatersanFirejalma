using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watersan_e_Firejalma
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            Timer tm = new Timer();
            tm.Interval = 25;
            tm.Tick += delegate
            {
                var rect = new RectangleF(820, 700, 200, 100);
                Graphics g = Graphics.FromImage(fundo.Image);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                if (rect.Contains(cursor))
                {
                    g.DrawString("Play", new Font("Thayer Street NDP", 48f), Brushes.Goldenrod, new RectangleF(fundo.Image.Width / 2 - 110, 0.25f * Height, 200, 100), sf);
                    fundo.Cursor = Cursors.Hand;
                    if (down)
                    {
                        Form1 telanova = new Form1();
                        
                        telanova.FormClosed += (s, args) => this.Close();
                        telanova.Show();
                        this.Hide();
                    }
                }
                else
                {
                    g.DrawString("Play", new Font("Thayer Street NDP", 48f), Brushes.Black, new RectangleF(fundo.Image.Width / 2 - 110, 0.25f * Height, 200, 100), sf);
                    fundo.Cursor = Cursors.Default;
                }
                fundo.Refresh();
            };
            tm.Start();
        }
        private void TelaInicial_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        Point cursor = Point.Empty;
        bool down = false;
        private void fundo_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
        }

        private void fundo_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
        }

        private void fundo_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

    }
}
