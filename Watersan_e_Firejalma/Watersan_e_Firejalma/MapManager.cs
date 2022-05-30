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

        
        public List<Box> blocks { get; set; } = new List<Box>();
        public string mapLayout;

        
        public Image FullBlock = Properties.Blocks.BlocoInteiro;            // a
        public Image FullWaterBlock = Properties.Blocks.BlocoAgua;          // c
        public Image FullLavaBlock = Properties.Blocks.BlocoLava;           // f
        public Image FullDeathBlock = Properties.Blocks.BlocoMorte;         // m

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



        public MapManager(string mapLayout)
        {
        

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
                                sprite = FullBlock;
                                BlockType = 0;
                                break;
                            case "b":
                                sprite = LeftDiagonalLava;
                                BlockType = 0;
                                break;
                            case "c":
                                sprite = FullLavaBlock;
                                BlockType = 1;
                                break;
                            case "d":
                                sprite = RightDiagonalLava;
                                BlockType = 0;
                                break;
                            case "e":
                                sprite = LeftDiagonalWater;
                                BlockType = 0;
                                break;
                            case "f":
                                sprite = FullWaterBlock;
                                BlockType = 2;
                                break;
                            case "g":
                                sprite = RightDiagonalWater;
                                BlockType = 0;
                                break;
                            case "h":
                                sprite = LeftDiagonal;
                                BlockType = 0;
                                break;
                            case "i":
                                sprite = RightDiagonal;
                                BlockType = 0;
                                break;
                            case "j":
                                sprite = TopLeftDiagonal;
                                BlockType = 0;
                                break;
                            case "k":
                                sprite = TopRightDiagonal;
                                BlockType = 0;
                                break;
                            case "l":
                                sprite = LeftDiagonalDeath;
                                BlockType = 0;
                                break;
                            case "m":
                                sprite = FullDeathBlock;
                                BlockType = 3;
                                break;
                            case "n":
                                sprite =RightDiagonalDeath ;
                                BlockType = 0;
                                break;
                            case "v":
                                sprite = null;
                                break;
                        }

                        if (sprite!= null)
                        {
                            Box block = new Box(currentPosX, currentPosY, blockWidth, blockHeight, sprite, BlockType);
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
