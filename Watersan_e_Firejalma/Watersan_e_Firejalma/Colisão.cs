using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watersan_e_Firejalma
{
    public class Colisão
    {

        public bool checkCollission(Personagem personagem, objeto objeto)
        {

            if ((personagem.PosX + personagem.Resolucaox) == objeto.pontos[1].X)
                return true;
            else
                return false;
        }
    }
}
