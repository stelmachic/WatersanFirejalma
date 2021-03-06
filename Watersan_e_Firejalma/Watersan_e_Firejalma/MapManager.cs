using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class MapManager
    {

        
        public List<Block> blocks { get; set; } = new List<Block>();
        public List<Character> characters { get; set; } = new List<Character>();
        public List<Asset> assets { get; set; } = new List<Asset>();
        public List<Wall> walls { get; set; } = new List<Wall>();

        public string mapLayout;

        
        public List<Image> FullBlock = new List<Image>();            // a
        public Image FullWaterBlock = Properties.Blocks.BlocoAgua;          // c
        public Image FullLavaBlock = Properties.Blocks.BlocoLava;           // f
        public Image FullDeathBlock = Properties.Blocks.BlocoMorte;         // m
        public Image FullWallBlock = Properties.Blocks.BlocoInteiro_parede; // v

        public Image RightDiagonal = Properties.Blocks.DiagonalDir;         // i
        public Image RightDiagonalWater = Properties.Blocks.CantoDirAgua;   // g
        public Image RightDiagonalLava = Properties.Blocks.CantoDirLava;    // d
        public Image RightDiagonalDeath = Properties.Blocks.CantoDirMorte;  // n

        public Image LeftDiagonal = Properties.Blocks.DiagonalEsq;          // h
        public Image LeftDiagonalWater = Properties.Blocks.CantoEsqAgua;    // e
        public Image LeftDiagonalLava = Properties.Blocks.CantoEsqLava;     // b
        public Image LeftDiagonalDeath = Properties.Blocks.CantoEsqMorte;   // l

        public Image TopRightDiagonal = Properties.Blocks.BlocoDiagInvDir;  // k
        public Image TopLeftDiagonal = Properties.Blocks.BlocoDiagInvEsq;   // j 
        public Image Empty = Properties.Blocks.Vazio;                       // w

        private Character character;
        private Asset asset;

        private int BlockType;

      


        Image sprite = null;

        Rectangle rec = new Rectangle();

        int currentPosX = 0;
        int currentPosY = 0;
        int blockWidth = 32;
        int blockHeight = 32;
        int initialPosX = 0;

        public int mapHeight;
        public int mapWidth;


        public int lines=0;
        public int columns=0;
        string strLine = string.Empty;
        Random random = new Random();


        public MapManager(string mapLayout)
        {

            FullBlock.Add(Properties.Blocks.BlocoInteiro);

            this.mapLayout = mapLayout;

            using (System.IO.StringReader strReader = new System.IO.StringReader(mapLayout))
            {
                while ((strLine = strReader.ReadLine()) != null)
                {
                    lines++;
                    string[] strLineArray = strLine.Split(' ');
                    foreach (string strBlockChar in strLineArray)
                    { 
                        columns++;
                    }
                }
            }

            mapHeight = lines * blockHeight;
            mapWidth = (columns/lines) * blockWidth;

            GenerateMap();
        }


        public void GenerateMap()
        {
            using (System.IO.StringReader strReader = new System.IO.StringReader(mapLayout))
            {
                
                while ((strLine = strReader.ReadLine()) != null)
                {
                    string[] strLineArray = strLine.Split(' ');
                    
                    
                    foreach (string strBlockChar in strLineArray)
                    {
                     
                        rec.Location = new Point(currentPosX, currentPosY);

                        switch (strBlockChar)
                        {
                            case "a":
                                sprite = FullBlock[random.Next(0, 1)];
                                BlockType = 0;
                                break;
                            case "b":
                                sprite = LeftDiagonalLava;
                                BlockType = 1;
                                break;
                            case "c":
                                sprite = FullLavaBlock;
                                BlockType = 1;
                                break;
                            case "d":
                                sprite = RightDiagonalLava;
                                BlockType = 1;
                                break;
                            case "e":
                                sprite = LeftDiagonalWater;
                                BlockType = 2;
                                break;
                            case "f":
                                sprite = FullWaterBlock;
                                BlockType = 2;
                                break;
                            case "g":
                                sprite = RightDiagonalWater;
                                BlockType = 2;
                                break;
                            case "h":
                                sprite = LeftDiagonal;
                                BlockType = 4;
                                break;
                            case "i":
                                sprite = RightDiagonal;
                                BlockType = 4;
                                break;
                            case "j":
                                sprite = TopLeftDiagonal;
                                BlockType = 4;
                                break;
                            case "k":
                                sprite = TopRightDiagonal;
                                BlockType = 4;
                                break;
                            case "l":
                                sprite = LeftDiagonalDeath;
                                BlockType = 3;
                                break;
                            case "m":
                                sprite = FullDeathBlock;
                                BlockType = 3;
                                break;
                            case "n":
                                sprite =RightDiagonalDeath ;
                                BlockType = 3;
                                break;

                            case "o":
                                sprite = null;
                                character = new Edjalma(currentPosX, currentPosY);
                                characters.Add(character);
                                break;

                            case "p":
                                sprite = null;
                                character = new Trevisan(currentPosX, currentPosY);
                                characters.Add(character);
                                break;
                            case "q":
                                sprite = null;
                                BlockType = 5;
                                asset = new Brownie(currentPosX, currentPosY, BlockType);
                                assets.Add(asset);
                                break;

                            case "r":
                                sprite = null;
                                BlockType = 5;
                                asset = new C_Sharp(currentPosX, currentPosY, BlockType);
                                assets.Add(asset);
                                break;
                            case "s":
                                sprite = null;
                                BlockType = 5;
                                asset = new EdDoor(currentPosX, currentPosY, BlockType);
                                assets.Add(asset);
                                break;
                            case "t":
                                sprite = null;
                                BlockType = 5;
                                asset = new TrevDoor(currentPosX, currentPosY, BlockType);
                                assets.Add(asset);
                                break;

                            case "w":
                                sprite = Empty;
                                BlockType = 9;
                                break;

                            case "v":
                                sprite = null;
                                break;
                        }

                        if (sprite!= null)
                        {
                            Block block = new Block(currentPosX, currentPosY, blockWidth, blockHeight, sprite, BlockType);
                            blocks.Add(block);
                        }
                        
                        currentPosX += blockWidth;
                    }

                    currentPosX = initialPosX;
                    currentPosY += blockHeight;
                }
            }
        }
    }
}
