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
            switch (tabuleiro == true)
            {
                case true:
                    colocarObstacu(e);
                    break;
                default:
                    desenhaTabuleiro();
                    desenharObstaculos();
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
                }
            }
            tabuleiro = true;
            #endregion

            // Coloca rato na casa inicial
            rato.BackColor = Color.Blue;
            rato.Bounds = new Rectangle(50, 50, 45, 45);
            rato.Location = new Point(450, 450);
            grafo.Controls.Add(rato);

            // Coloca queijo na casa objetivo final
            queijo.BackColor = Color.Yellow;
            queijo.Bounds = new Rectangle(50, 50, 45, 45);
            queijo.Location = new Point(0, 0);
            grafo.Controls.Add(queijo);
        }

        #region Colocar Obstaculo
        private void colocarObstacu(MouseEventArgs e)
        {
            int xResto = e.X % 50;
            int yResto = e.Y % 50;
            grafoPaineu[e.X / 50, e.Y / 50] = new Panel();
            grafoPaineu[e.X / 50, e.Y / 50].BackColor = Color.LightGray;
            grafoPaineu[e.X / 50, e.Y / 50].Bounds = new Rectangle(e.X / 50, e.Y / 50, 48, 48);
            grafoPaineu[e.X / 50, e.Y / 50].Location = new Point(e.X - xResto, e.Y - yResto);
            grafo.Controls.Add(grafoPaineu[e.X / 50, e.Y / 50]);

        }
        #endregion

        private void btnComecar_Click(object sender, EventArgs e)
        {
            Point posicao = new Point(450,450);
            // objetivo / Substituir objetivo por lista vazia
            while (rato.Location.Y > 0)
            {
                posicao.Y -= 50;
                rato.Location = posicao;
                Thread.Sleep(500);
            }
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
            obsLinha.BackColor = Color.LightGray;
            obsLinha.Bounds = new Rectangle(1, 1, 50, 200);
            obsLinha.Location = new Point(5, 100);
            painelObstaculos.Controls.Add(obsLinha);
        }

        private void algoritmo()
        {

        }
    }
}
