using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Linq;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Watersan_e_Firejalma
{
    public partial class Game : Form
    {
        Timer tm = new Timer();
        int frameRate = 2;
        int frame = 0;


        Bitmap bmp = null;
        Graphics g = null;
        int currentTutorial=1;

        List<Character> characters = new List<Character>();
        List<Block> boxes = new List<Block>();
        List<Entity> entities = new List<Entity>();
        List<Asset> assets = new List<Asset>();
        List<Wall> walls = new List<Wall>();
        List<BackgroundManager> backgrounds = new List<BackgroundManager>();
        List<MapManager> levels = new List<MapManager>();


        MapManager level0 = new MapManager(Properties.Maps.MapaFase0);
        MapManager level1 = new MapManager(Properties.Maps.MapaFase1);
        MapManager level2 = new MapManager(Properties.Maps.MapaFase2);
        MapManager level3 = new MapManager(Properties.Maps.MapaFase3);
        BackgroundManager background0 = new BackgroundManager(Properties.Maps.fundoMapa0);
        BackgroundManager background1 = new BackgroundManager(Properties.Maps.fundoMapa1);
        BackgroundManager background2 = new BackgroundManager(Properties.Maps.fundoMapa2);
        BackgroundManager background3 = new BackgroundManager(Properties.Maps.fundoMapa3);


        int currentLevel = 0;
        int brownies = 0;
        int c_sharps = 0;

        public Game()
        {
            InitializeComponent();
            tm.Interval = 25;
            Menu_Voltar.Hide();


            tm.Tick += delegate 
            {
                frame++;

                checkVictory();
                checkDeath();
                collectPoints();
                renderGame();
                manageMovement();

                pb.Image = bmp;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tutorial.Show();
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);

            levels.Add(level0);
            levels.Add(level1);
            levels.Add(level2);
            levels.Add(level3);

            backgrounds.Add(background0);
            backgrounds.Add(background1);
            backgrounds.Add(background2);
            backgrounds.Add(background3);

            transformMap(levels[currentLevel], g);

            loadLists(levels[currentLevel], backgrounds[currentLevel]);

            EdPoints.Text = "0";
            TrevPoints.Text = "0";
            tutorial.Location = new Point((this.Width / 2) - (tutorial.Width / 2), (this.Height / 2) - (tutorial.Height / 2));
            Menu_Voltar.Size = new Size(510, 350);
            Menu_Voltar.Location = new Point((this.Width / 2) - (Menu_Voltar.Width / 2), (this.Height / 2) - (Menu_Voltar.Height / 2));

            tm.Start();
        }



        private void checkVictory()
        {
            if (assets.Where(c => c.assetType == AssetType.door).All(c => c.victory == true))
            {
                if (currentLevel == levels.Count - 1)
                {
                    for (int i = 0; i < characters.Count; i++)
                    {
                        entities.Remove(characters[i]);
                        characters.Remove(characters[i]);
                    }


                    this.Close();
                    tm.Stop();
                    TelaVitoria telanova = new TelaVitoria();
                    telanova.Show();
                    return;
                }
                else
                {
                    clearLists();
                    currentLevel++;

                    untransformMap(levels[currentLevel - 1], g);
                    transformMap(levels[currentLevel], g);
                    loadLists(levels[currentLevel], backgrounds[currentLevel]);
                }
            }
        }

        private void checkDeath()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (!characters[i].alive)
                {

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
        }

        private void collectPoints()
        {
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

            for (int i = 0; i < assets.Count; i++)
            {
                if (assets[i].disappear)
                {
                    if (assets[i] is Brownie)
                    {
                        brownies++;
                        EdPoints.Text = brownies.ToString();
                    }
                    else if (assets[i] is C_Sharp)
                    {
                        c_sharps++;
                        TrevPoints.Text = c_sharps.ToString();
                    }
                    entities.Remove(assets[i]);
                    assets.Remove(assets[i]);
                    i--;
                }
            }
        }

        private void renderGame()
        {
            if (frame % frameRate == 0)
            {
                g.Clear(Color.Transparent);

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
        }

        private void clearLists()
        {
            characters.Clear();
            assets.Clear();
            walls.Clear();
            boxes.Clear();
            entities.Clear();
        }

        private void manageMovement()
        {
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
        }

        private void Tutorial()
        {
            switch (currentTutorial)
            {
                case 1:
                    labelTutorial.Text = "Firejalma e Watersan são grandes professores na terra de SenaiLandia, e a muito tempo eles descobriram que precisam trabalhar juntos para alcançar os melhores resultados, mas para se tornar o melhor professor, eles terao que passar por uma jornada sem igual, e apenas um sai com um titulo!";
                    break;
                case 2:
                    labelTutorial.Text = "Watersan com os tempos de aula desenvolveu poderes de agua sendo extremamente sensivel a lava, então cuidado, e o Firejalma ao contrario, poderes de lava e extremamente sensivel a agua.";
                    break;
                case 3:
                    labelTutorial.Text = "Watersan se move com os botões W, A, S, D e o Firejalma pelas setas.";
                    break;
                case 4:
                    tutorial.Hide();
                    break;
            }
            
            
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

        private void loadLists(MapManager mm, BackgroundManager bg)
        {
            foreach (Character character in mm.characters)
                characters.Add(character);

            foreach (Block block in mm.blocks)
                boxes.Add(block);

            foreach (Asset asset in mm.assets)
                assets.Add(asset);

            foreach(Wall wall in mm.walls) 
                walls.Add(wall);

            foreach (Asset asset in assets)
                entities.Add(asset);

            foreach (Character character in characters)
                entities.Add(character);

            foreach (var block in boxes)
                entities.Add(block);

            foreach (Wall wall in bg.walls)
            {
                walls.Add(wall);
            }

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


        // botao de fechar menu
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menu_Voltar.Hide();
        }

        private void buttonTutorial_Click(object sender, EventArgs e)
        {
            currentTutorial++;
            Tutorial();
        }
    }
}







