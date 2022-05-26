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

        
        public Image floor = Properties.Blocks.BlocoInteiro;
        public Image lake = Properties.Blocks.BlocoAgua;
        public Image diagonalDir = Properties.Blocks.DiagonalDir;
        public Image diagonalEsq = null;






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
                            //Teste
                            case "w":
                                sprite = floor;
                                break;
                            case "b":
                                sprite = null;
                                break;
                            case "l":
                                sprite = lake;
                                break;
                            case "d":
                                sprite = diagonalDir;
                                break;
                        
                        }

                        if(sprite!= null)
                        {
                            Box block = new Box(currentPosX, currentPosY, blockWidth, blockHeight, sprite);
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
