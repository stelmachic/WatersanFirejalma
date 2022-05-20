using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


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
        CollisionManager collisionManager = new CollisionManager();
        MapManager mapManager;

        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            
            tm.Tick += delegate 
            {
                frame++;

                
                if (frame % frameRate == 0)
                {
                    g.Clear(Color.White);
                    mapManager.GerarMapa();
                    foreach (Entity entity in entities)
                    {             
                        entity.Draw(g);
                        entity.DrawHitBox(g);
                    }
                    
                }

                foreach (Character character in characters)
                {
                    character.Move();


                    foreach(Box box in boxes)
                    {
                        //character.CheckCollision(box, g);
                    }
                }


                //collisionManager.HandleCollisions(g);
                



                pb.Image = bmp;
            };
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);

            mapManager = new MapManager(g);



            characters.Add(edjalma);
            edjalma.posY = pb.Height - edjalma.height - 50;

            //characters.Add(trevisan);
            //trevisan.posY = pb.Height - trevisan.height - 50;
            //trevisan.posX += 200;


            boxes.Add(new Box(0, pb.Height - 20, pb.Width, 100)); // floor
            boxes.Add(new Box((pb.Width/2), pb.Height-150, 150, 150)); // center cube
            boxes.Add(new Box(-60, 0, 80,pb.Height)); // left wall
            boxes.Add(new Box((pb.Width - 20), 0, 20, pb.Height)); // right wall


            
            foreach (Box box in boxes)
                entities.Add(box);
            
            foreach(Character character in characters)
                entities.Add(character);
            
            collisionManager.Entities = entities;
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
            foreach (Character character in characters)
            {
                character.KeyCheck(e.KeyCode, false);
            }
        }

    }

}







