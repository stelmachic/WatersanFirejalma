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
        Character edjalma = new Edjalma();
        Character trevisan = new Trevisan();
        List<Character> characters = new List<Character>();
        List<Box> boxes = new List<Box>();
        List<Entity> entities = new List<Entity>();
        MapManager level1;
        Image background = Properties.Maps.SenairiodeFundoGame2_0;

        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            
            tm.Tick += delegate 
            {
                frame++;
                for (int i = 0; i<characters.Count; i++)
                {
                    if (!characters[i].alive)
                    {
                        characters[i].walkSound.Stop();
                        entities.Remove(characters[i]);
                        characters.Remove(characters[i]);
                        i--;
                    }
                }

                if (frame % frameRate == 0)
                {
                    g.Clear(Color.Transparent);

                    drawBackground(g, background);

                    foreach (Entity entity in entities)
                    {             
                        
                        entity.Draw(g);
                        entity.DrawHitBox(g);
                        
                            
                    }
                }
                
                

                foreach (Character character in characters)
                {
                    character.Move();


                    foreach (Box box in level1.blocks)
                    {
                        character.CheckCollision(box, g);
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

        private void loadCharacter(Character character)
        {
            characters.Add(character);
            character.posX = 0 + character.width;
            character.posY = level1.mapHeight - character.height - 32;
        }

        private void loadLists(MapManager mm, List<Character> characters)
        {
            foreach (var block in mm.blocks)
                boxes.Add(block);

            foreach (var block in boxes)
                entities.Add(block);

            foreach (Character character in characters)
                entities.Add(character);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            level1 = new MapManager(Properties.Maps.Map1);


            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            transformMap(level1, g);


            loadCharacter(edjalma);
            loadCharacter(trevisan);
            loadLists(level1, characters);
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







