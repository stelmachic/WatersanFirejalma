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

        Graphics g;

        public MapManager(Graphics g)
        {
            this.g = g;
        }


        public void GerarMapa()
        {
            string mapLayout = Properties.Resources.Mapa1;
            var block = Properties.Resources.Destructible;
            var blank = Properties.Resources.Blank;
            var lake = Properties.Resources.lakeFull;
            var diagonal = Properties.Resources.Diagonal;

            Rectangle rec = new Rectangle();
            int currentPosX = 0;
            int currentPosY = 0;
            int blockWidth = (16 * 8);
            int blockHeight = (16 * 8);
            int initialPosX = 0;




            using (System.IO.StringReader strReader = new System.IO.StringReader(mapLayout))
            {

                //Generate Map with the txt
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetWrapMode(WrapMode.TileFlipY);

                string strLine = string.Empty;

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
                                g.DrawImage(block, new Rectangle(currentPosX, currentPosY, blockWidth, blockHeight), 0, 0, (16 * 8), (16 * 8), GraphicsUnit.Pixel, attributes);
                                break;
                            case "b":
                                g.DrawImage(blank, new Rectangle(currentPosX, currentPosY, blockWidth, blockHeight), 0, 0, (16 * 8), (16 * 8), GraphicsUnit.Pixel, attributes);
                                break;
                            case "l":
                                g.DrawImage(lake, new Rectangle(currentPosX, currentPosY, blockWidth, blockHeight), 0, 0, (16 * 8), (16 * 8), GraphicsUnit.Pixel, attributes);
                                break;
                            case "d":
                                g.DrawImage(diagonal, new Rectangle(currentPosX, currentPosY, blockWidth, blockHeight), 0, 0, (16 * 8), (16 * 8), GraphicsUnit.Pixel, attributes);
                                break;


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
