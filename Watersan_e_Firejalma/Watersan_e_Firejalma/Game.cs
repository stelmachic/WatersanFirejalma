using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Linq;

namespace Watersan_e_Firejalma
{
    public partial class Game : Form
    {
        Timer tm = new Timer();
        int frameRate = 2;
        int frame = 0;

        Bitmap bmp = null;
        Graphics g = null;


        List<Character> characters = new List<Character>();
        List<Block> boxes = new List<Block>();
        List<Entity> entities = new List<Entity>();
        List<Asset> assets = new List<Asset>();
        List<Wall> walls = new List<Wall>();
        List<BackgroundManager> backgrounds = new List<BackgroundManager>();
        List<MapManager> levels = new List<MapManager>();

        int brownies = 0;
        int c_sharps = 0;

        MapManager level0;
        MapManager level1;
        MapManager level2;
        MapManager level3;
        BackgroundManager background0;
        BackgroundManager background1;
        BackgroundManager background2;
        BackgroundManager background3;

        int currentLevel = 1;
        Image background = Properties.Maps.SenairiodeFundoGame2_0;




        public Game()
        {
            InitializeComponent();
            tm.Interval = 25;
            Menu_Voltar.Hide();
            tm.Tick += delegate 
            {

                if(assets.Where(c => c.assetType == AssetType.door).All(c => c.victory == true))
                {
                    if(currentLevel == levels.Count-1)
                    {
                        for (int i = 0; i < characters.Count; i++)
                        {
                            characters[i].walkSound.Stop();
                            entities.Remove(characters[i]);
                            characters.Remove(characters[i]);
                        }
                     

                        this.Close();
                        tm.Stop();
                        TelaVitoria telanova = new TelaVitoria();
                        telanova.Show();
                        return;
                    }else
                    {
                        clearLists();
                        currentLevel++;

                        untransformMap(levels[currentLevel - 1], g);
                        transformMap(levels[currentLevel], g);
                        loadLists(levels[currentLevel]);
                        loadBackgrounds(backgrounds[currentLevel]);
                    }
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

                        this.Close();
                        tm.Stop();
                        TelaMorte telanova = new TelaMorte();
                        telanova.Show();
                        return;
                    }
                }

                for (int i = 0; i < assets.Count; i++)
                {
                    if (assets[i].disappear)
                    {
                        if (assets[i] is Brownie)
                        {
                            brownies++;
                            label1.Text = brownies.ToString();
                        }
                        else if (assets[i] is C_Sharp) {
                            c_sharps++;
                            label2.Text = c_sharps.ToString();
                        }
                        entities.Remove(assets[i]);
                        assets.Remove(assets[i]);
                        i--;
                    }
                }

                if (frame % frameRate == 0)
                {
                    g.Clear(Color.Transparent);

                    //drawBackground(g, background);

                    foreach (Wall wall in walls)
                    {
                        wall.Draw(g);
                    }
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

        private void clearLists()
        {
            characters.Clear();
            assets.Clear();
            walls.Clear();
            boxes.Clear();
            entities.Clear();
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

        private void loadBackgrounds(BackgroundManager bg)
        {
            foreach (Wall wall in bg.walls)
            {
                walls.Add(wall);
            }
        }

        private void loadLists(MapManager mm)
        {
            foreach (Character character in mm.characters)
                characters.Add(character);

            foreach (Block block in mm.blocks)
                boxes.Add(block);

            foreach (Asset asset in mm.assets)
                assets.Add(asset);

            foreach(Wall wall in mm.walls) 
                walls.Add(wall);

            foreach (Character character in characters)
                entities.Add(character);

            foreach (var block in boxes)
                entities.Add(block);

            foreach (Asset asset in assets)
                entities.Add(asset);
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            currentLevel = 0;
            
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);

            

            level0 = new MapManager(Properties.Maps.Mapateste);
            level1 = new MapManager(Properties.Maps.MapaFase1);
            level2 = new MapManager(Properties.Maps.MapaFase2);
            level3 = new MapManager(Properties.Maps.MapaFase3);

            background0 = new BackgroundManager(Properties.Maps.fundoMapateste);
            background1 = new BackgroundManager(Properties.Maps.fundoMapa1);
            background2 = new BackgroundManager(Properties.Maps.fundoMapa2);
            background3 = new BackgroundManager(Properties.Maps.fundoMapa3);

            levels.Add(level0);
            levels.Add(level1);
            levels.Add(level2);
            levels.Add(level3);

            backgrounds.Add(background0);
            backgrounds.Add(background1);
            backgrounds.Add(background2);
            backgrounds.Add(background3);

            transformMap(levels[currentLevel], g);
            loadLists(levels[currentLevel]);
            loadBackgrounds(backgrounds[currentLevel]);

            label1.Text = "0";
            label2.Text = "0";

            Menu_Voltar.Size = new Size(510,350);
            Menu_Voltar.Location = new Point((this.Width / 2) - (Menu_Voltar.Width / 2) , (this.Height / 2) - (Menu_Voltar.Height / 2));

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
                    if (!Menu_Voltar.Visible)
                    {
                        Menu_Voltar.Show();
                    }
                    else
                    {
                        Menu_Voltar.Hide();
                    }
                   
                    break;

                case Keys.NumPad9:
                    Application.Exit();
                    break;
            }
            foreach (Character character in characters)
            {
                character.KeyCheck(e.KeyCode, false);
            }
        }

        private void Voltar_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            tm.Stop();
            TelaInicial telanova = new TelaInicial();
            telanova.Show();
            return;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu_Voltar.Hide();
        }
    }
}







