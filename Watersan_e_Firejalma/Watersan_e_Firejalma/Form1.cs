using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Linq;

namespace Watersan_e_Firejalma
{
    public partial class Form1 : Form
    {
        Timer tm = new Timer();
        int frameRate = 2;
        int frame = 0;
        Bitmap bmp = null;
        Graphics g = null;
        //Character edjalma = new Edjalma();
        //Character trevisan = new Trevisan();
        List<Character> characters = new List<Character>();
        List<Block> boxes = new List<Block>();
        List<Entity> entities = new List<Entity>();
        List<Asset> assets = new List<Asset>();
        MapManager level1;
        Image background = Properties.Maps.SenairiodeFundoGame2_0;

        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            tm.Tick += delegate 
            {

                if(assets.Count == 0)
                {
                    this.Hide();
                    Form1 telanova = new Form1();
                    telanova.Show();
                }

                frame++;
                for (int i = 0; i < characters.Count; i++)
                {
                    if (!characters[i].alive)
                    {
                        characters[i].walkSound.Stop();
                        entities.Remove(characters[i]);
                        characters.Remove(characters[i]);
                        i--;
                        this.Hide();
                        TelaMorte telanova = new TelaMorte();
                        telanova.Show();
                    }
                }

                for (int i = 0; i < assets.Count; i++)
                {
                    if (assets[i].disappear)
                    {
                        entities.Remove(assets[i]);
                        assets.Remove(assets[i]);
                        i--;
                    }
                }

                if (frame % frameRate == 0)
                {
                    g.Clear(Color.Transparent);

                    //drawBackground(g, background);

                    foreach (Entity entity in entities)
                    {

                        entity.Draw(g);
                        //entity.DrawHitBox(g);


                    }
                }

                foreach (Character character in characters)
                {
                    character.Move();
                    
                    foreach (Block box in boxes)
                    {
                        float dx = box.box.X - character.posX;
                        float dy = box.box.Y - character.posY;
                        if (dx * dx + dy * dy <= 128 * 128)
                            character.CheckCollision(box, g);
                    }
                }

                foreach (Asset asset in assets)
                {
                    foreach (Character character in characters)
                    {
                        float dx = asset.posX - character.posX;
                        float dy = asset.posY - character.posY;
                        if (dx * dx + dy * dy <= 128 * 128)
                            asset.CheckCollision(character, g);
                    }
                }

                pb.Image = bmp;
            };
        }

        private void transformMap(MapManager mm, Graphics g)
        {
            float aw = this.Width / (float)mm.mapWidth,
                  ah = this.Height / (float)mm.mapHeight;
            if (aw > ah)
            {
                g.ScaleTransform(ah, ah);
                g.TranslateTransform((this.Width - (mm.mapWidth * ah))/2, 0, System.Drawing.Drawing2D.MatrixOrder.Append);
           
            }
            else
            {
                g.ScaleTransform(aw, aw);
                g.TranslateTransform(0, (this.Height - aw * mm.mapHeight) / 2, System.Drawing.Drawing2D.MatrixOrder.Append);
            }
        }

        private void untransformMap(MapManager mm, Graphics g)
        {
            float aw = this.Width / (float)mm.mapWidth,
                  ah = this.Height / (float)mm.mapHeight;
            if (aw > ah)
            {
                g.TranslateTransform(-(this.Width - ah * mm.mapWidth) / 2, 0, System.Drawing.Drawing2D.MatrixOrder.Append);
                g.ScaleTransform(1 / ah, 1 / ah);
            }
            else
            {
                g.TranslateTransform(0, -(this.Height - aw * mm.mapHeight) / 2, System.Drawing.Drawing2D.MatrixOrder.Append);
                g.ScaleTransform(1 / aw, 1 / aw);
            }
        }

        private void drawBackground(Graphics g, Image back)
        {
            g.DrawImage(back,0,0,this.Width, this.Height);
        }

        private void loadLists(MapManager mm)
        {
            foreach (Character character in mm.characters)
                characters.Add(character);

            foreach (Block block in mm.blocks)
                boxes.Add(block);

            foreach (Asset asset in mm.assets)
                assets.Add(asset);





            foreach (Character character in characters)
                entities.Add(character);

            foreach (var block in boxes)
                entities.Add(block);

            foreach (Asset asset in assets)
                entities.Add(asset);

        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);

            level1 = new MapManager(Properties.Maps.Mapateste);
            transformMap(level1, g);
            loadLists(level1);

            tm.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Character character in characters)
            {
                character.KeyCheck(e.KeyCode, true);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
             
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
            foreach (Character character in characters)
            {
                character.KeyCheck(e.KeyCode, false);
            }
        }

    }

}







