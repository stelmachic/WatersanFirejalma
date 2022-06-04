using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Watersan_e_Firejalma
{
    internal class BackgroundManager
    {
        public List<Wall> walls { get; set; } = new List<Wall>();

        public string mapLayout;


        public Image FullBlock = Properties.Blocks.BlocoInteiro_parede; // a
        public Image Detail = Properties.Blocks.Parede_Detail;          // d
        public Image FireExt = Properties.Blocks.FireExtinguisher;      // f
        public Image AirLeft = Properties.Blocks.airCondLeft;           // g
        public Image AirRight = Properties.Blocks.airCondRight;         // h


        Image sprite = null;

        Rectangle rec = new Rectangle();

        int currentPosX = 0;
        int currentPosY = 0;
        int blockWidth = 32;
        int blockHeight = 32;
        int initialPosX = 0;

        public int mapHeight;
        public int mapWidth;


        public int lines = 0;
        public int columns = 0;
        string strLine = string.Empty;



        public BackgroundManager(string mapLayout)
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
            mapWidth = (columns / lines) * blockWidth;

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
                                break;

                            case "d":
                                sprite = Detail;
                                break;

                            case "f":
                                sprite = FireExt;
                                break;

                            case "g":
                                sprite = AirLeft;
                                break;

                            case "h":
                                sprite = AirRight;
                                break;

                            case "v":
                                sprite = null;
                                break;
                        }

                        if (sprite != null)
                        {
                            Wall wall = new Wall(sprite, currentPosX, currentPosY);
                            walls.Add(wall);
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
