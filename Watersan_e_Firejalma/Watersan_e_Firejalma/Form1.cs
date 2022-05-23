﻿using System;
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
        MapManager map1;

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
               
                    foreach (Entity entity in entities)
                    {             
                        entity.Draw(g);
                        entity.DrawHitBox(g);
                    }
                    
                }

                foreach (Character character in characters)
                {
                    character.Move();


                    foreach (Box box in map1.blocks)
                    {
                        character.CheckCollision(box, g);
                    }
                }


                //collisionManager.HandleCollisions(g);




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
                g.TranslateTransform((this.Width - ah * mm.mapWidth) / 2, 0);
            }
            else
            {
                g.ScaleTransform(aw, aw);
                g.TranslateTransform(0, (this.Height - aw * mm.mapHeight) / 2);
            }
        }

        private void untransformMap(MapManager mm, Graphics g)
        {
            float aw = this.Width / (float)mm.mapWidth,
                  ah = this.Height / (float)mm.mapHeight;
            if (aw > ah)
            {
                g.TranslateTransform(-(this.Width - ah * mm.mapWidth) / 2, 0);
                g.ScaleTransform(1 / ah, 1 / ah);
            }
            else
            {
                g.TranslateTransform(0, -(this.Height - aw * mm.mapHeight) / 2);
                g.ScaleTransform(1 / aw, 1 / aw);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            map1 = new MapManager(Properties.Resources.Mapa1);


            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            transformMap(map1, g);


            characters.Add(edjalma);

            //characters.Add(trevisan);
            //trevisan.posY = pb.Height - trevisan.height - 50;
            //trevisan.posX += 200;

            //edjalma.posX = -200;
            edjalma.posX = +1300;
            edjalma.posY = map1.mapHeight - edjalma.height - 128;


            foreach (var block in map1.blocks)
                entities.Add(block);

            foreach (Character character in characters)
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







