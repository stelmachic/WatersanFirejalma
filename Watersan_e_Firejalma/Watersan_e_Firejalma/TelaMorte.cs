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
    public partial class TelaMorte : Form
    {
        public TelaMorte()
        {
            InitializeComponent();
        }

        private void TelaMorte_Load(object sender, EventArgs e)
        {
            Timer tm = new Timer();
            RectangleF rect;
            tm.Interval = 25;
            tm.Tick += delegate
            {
                rect = new RectangleF(850, 467, 200, 100);
                Graphics g = Graphics.FromImage(fundo.Image);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                if (rect.Contains(cursor))
                {
                    g.DrawString("Voltar", new Font("Thayer Street NDP", 48f), Brushes.Goldenrod, new RectangleF(fundo.Image.Width / 2 - 110, 0.25f * Height, 200, 100), sf);
                    fundo.Cursor = Cursors.Hand;
                    if (down)
                    {
                        TelaInicial telanova = new TelaInicial();

                        telanova.FormClosed += (s, args) => this.Close();
                        telanova.Show();
                        this.Hide();
                    }
                }
                else
                {
                    g.DrawString("Voltar", new Font("Thayer Street NDP", 48f), Brushes.Black, new RectangleF(fundo.Image.Width / 2 - 110, 0.25f * Height, 200, 100), sf);
                    fundo.Cursor = Cursors.Default;
                }
                fundo.Refresh();
            };
            tm.Start();
        }
        Point cursor = Point.Empty;
        bool down = false;

        private void TelaMorte_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void fundo_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            label1.Text = cursor.ToString();
        }

        private void fundo_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
        }

        private void fundo_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }
    }
}
