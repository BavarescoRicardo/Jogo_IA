namespace JogoSharp
{
    partial class JogoFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grafo = new System.Windows.Forms.Panel();
            this.painelObstaculos = new System.Windows.Forms.Panel();
            this.btnComecar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grafo
            // 
            this.grafo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grafo.Location = new System.Drawing.Point(200, 20);
            this.grafo.Margin = new System.Windows.Forms.Padding(0);
            this.grafo.Name = "grafo";
            this.grafo.Size = new System.Drawing.Size(500, 500);
            this.grafo.TabIndex = 0;
            this.grafo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grafo_MouseClick);
            // 
            // painelObstaculos
            // 
            this.painelObstaculos.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.painelObstaculos.Location = new System.Drawing.Point(13, 55);
            this.painelObstaculos.Name = "painelObstaculos";
            this.painelObstaculos.Size = new System.Drawing.Size(72, 22);
            this.painelObstaculos.TabIndex = 1;
            this.painelObstaculos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.painelObstaculos_MouseDoubleClick);
            // 
            // btnComecar
            // 
            this.btnComecar.Location = new System.Drawing.Point(24, 496);
            this.btnComecar.Name = "btnComecar";
            this.btnComecar.Size = new System.Drawing.Size(91, 35);
            this.btnComecar.TabIndex = 2;
            this.btnComecar.Text = "Começar";
            this.btnComecar.UseVisualStyleBackColor = true;
            this.btnComecar.Click += new System.EventHandler(this.btnComecar_Click);
            // 
            // JogoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnComecar);
            this.Controls.Add(this.painelObstaculos);
            this.Controls.Add(this.grafo);
            this.Name = "JogoFrm";
            this.Text = "Jogo Trabalho I.A";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grafo;
        private System.Windows.Forms.Panel painelObstaculos;
        private System.Windows.Forms.Button btnComecar;
    }
}

