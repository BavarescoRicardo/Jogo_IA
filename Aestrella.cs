using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoSharp
{
    class Aestrella
    {
        public Aestrella()
        {

        }

        public Panel[] calcularCaminho(Point atual, Point Objetivo, Panel[,] grafo)
        {
            Panel[] caminho = new Panel[100];
            Panel[] listaAberta = new Panel[100];
            Panel[] listaFechada = new Panel[100];
            
            int cont = 0;
            listaAberta[cont].Location = atual;
            do
            {
                
            } while (listaAberta.Length > 0);

            return caminho;
        }

        public Point MelhorNodoAdjacente(Point atual,Point objetivo, Panel[,] grafo)
        {
            Point melhor = new Point();


            return melhor;
        }

    }
}
