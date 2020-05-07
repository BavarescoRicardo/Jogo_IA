using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoSharp
{
    public partial class JogoFrm : Form
    {
        bool tabuleiro = false;
        bool movimento = false;
        Panel rato = new Panel();
        Panel queijo = new Panel();
        Panel[,] grafoPaineu = new Panel[10,10];
        Graphics selecionado;
        Graphics g2;

        public JogoFrm()
        {
            InitializeComponent();
        }
        private void grafo_MouseClick(object sender, MouseEventArgs e)
        {
            switch (tabuleiro)
            {
                case true:
                    if(movimento == false)
                        colocarObstacu(e);
                    break;
                default:
                    desenhaTabuleiro();                    
                    break;
            }

        }

        private void desenhaTabuleiro()
        {
            #region Desenhar casas do tabuleiro
            g2 = grafo.CreateGraphics();
            Pen canetaAzul = new Pen(Color.Gray, 1);            

            int coluna, linha;
            for (coluna = 0; coluna < 500; coluna+=50)
            {
                for (linha = 0; linha < 500; linha+=50)
                {
                    g2.DrawRectangle(canetaAzul, linha, coluna, 50, 50);
                    grafoPaineu[linha / 50, coluna / 50] = new Panel();
                    grafoPaineu[linha / 50, coluna / 50].BackColor = Color.LightGray;
                    grafoPaineu[linha / 50, coluna / 50].Bounds = new Rectangle(linha / 50, coluna / 50, 48, 48);
                    grafoPaineu[linha / 50, coluna / 50].Location = new Point(linha, coluna);
                }
            }
            tabuleiro = true;
            #endregion

            // Coloca rato na casa inicial
            rato.BackColor = Color.Blue;
            rato.Bounds = new Rectangle(50, 50, 45, 45);
            rato.Location = new Point(2, 452);
            grafo.Controls.Add(rato);

            // Coloca queijo na casa objetivo final
            queijo.BackColor = Color.Yellow;
            queijo.Bounds = new Rectangle(50, 50, 45, 45);
            queijo.Location = new Point(2, 2);
            grafo.Controls.Add(queijo);
        }

        #region Colocar Obstaculo
        private void colocarObstacu(MouseEventArgs e)
        {
            int xResto = e.X % 50;
            int yResto = e.Y % 50;
            grafoPaineu[e.X / 50, e.Y / 50].BackColor = Color.LightGray;
            grafoPaineu[e.X / 50, e.Y / 50].Bounds = new Rectangle(e.X / 50, e.Y / 50, 48, 48);
            grafoPaineu[e.X / 50, e.Y / 50].Location = new Point(e.X - xResto, e.Y - yResto);
            grafo.Controls.Add(grafoPaineu[e.X / 50, e.Y / 50]);

        }
        #endregion

        private void btnComecar_Click(object sender, EventArgs e)
        {
            if ((tabuleiro == false) || (movimento == true))
                return;
            movimento = true;            
            int n = 0;
            Panel[] caminho;
            caminho = algoritmo(queijo.Location, rato.Location, grafoPaineu);
            // objetivo / Substituir objetivo por lista vazia
            while (n < 9)
            {
                rato.Location = caminho[n].Location;
                Thread.Sleep(500);
                n++;
            }
            movimento = false;
        }

        private void desenharObstaculos()
        {
            // Cortornar objeto selecionado
            selecionado = painelObstaculos.CreateGraphics();
            Pen canetaLaranja = new Pen(Color.Orange, 1);
            selecionado.DrawRectangle(canetaLaranja, 1, 1, 55, 55);

            // Obstaculo generico 
            Panel obstaculo = new Panel();
            obstaculo.BackColor = Color.LightGray;
            obstaculo.Bounds = new Rectangle(1, 1, 50, 50);
            obstaculo.Location = new Point(5, 5);
            painelObstaculos.Controls.Add(obstaculo);
            

            // Obstaculo linha continua
            Panel obsLinha = new Panel();
            obsLinha.BackColor = Color.YellowGreen;
            obsLinha.Bounds = new Rectangle(1, 1, 50, 100);
            obsLinha.Location = new Point(5, 100);
            painelObstaculos.Controls.Add(obsLinha);
        }

        private Panel[] algoritmo(Point objetivo, Point atual, Panel[,] grafo)
        {
            Panel[] caminho = new Panel[100];
            Panel[] listaAberta = new Panel[100];
            Panel[] listaFechada = new Panel[100];

            int yAtual = atual.Y;
            int cont = 0;
            int coluna, linha;
            for (coluna = 0; coluna < 10; coluna ++)
            {
                for (linha = 0; linha < 10; linha ++)
                {

                    caminho[linha+cont] = grafo[linha, coluna];
                }
                cont += 10;
            }

            return caminho;
        }

        private void painelObstaculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            painelObstaculos.Size = new Size(145, 160);
            desenharObstaculos();
        }
    }
}
