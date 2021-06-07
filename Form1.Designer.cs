namespace CrazyCircle
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verkruskal = new System.Windows.Forms.Button();
            this.verPrim = new System.Windows.Forms.Button();
            this.verGrafo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PrimG = new System.Windows.Forms.Label();
            this.Kruskgen = new System.Windows.Forms.Label();
            this.subgen = new System.Windows.Forms.Label();
            this.KruskalList = new System.Windows.Forms.ListBox();
            this.PrimList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 555);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar Escenario";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(486, 555);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Generar Grafo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(891, 262);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(18, 20);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Aqua;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(891, 296);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(18, 20);
            this.textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Orange;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(891, 328);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(18, 20);
            this.textBox3.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(921, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Vertices";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Aristas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(921, 332);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Puntos mas cercanos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // verkruskal
            // 
            this.verkruskal.Enabled = false;
            this.verkruskal.Location = new System.Drawing.Point(903, 152);
            this.verkruskal.Margin = new System.Windows.Forms.Padding(2);
            this.verkruskal.Name = "verkruskal";
            this.verkruskal.Size = new System.Drawing.Size(91, 19);
            this.verkruskal.TabIndex = 20;
            this.verkruskal.Text = "Ver Kruskal";
            this.verkruskal.UseVisualStyleBackColor = true;
            this.verkruskal.Click += new System.EventHandler(this.verkruskal_Click);
            // 
            // verPrim
            // 
            this.verPrim.Enabled = false;
            this.verPrim.Location = new System.Drawing.Point(1118, 152);
            this.verPrim.Margin = new System.Windows.Forms.Padding(2);
            this.verPrim.Name = "verPrim";
            this.verPrim.Size = new System.Drawing.Size(91, 19);
            this.verPrim.TabIndex = 21;
            this.verPrim.Text = "Ver Prim";
            this.verPrim.UseVisualStyleBackColor = true;
            this.verPrim.Click += new System.EventHandler(this.verPrim_Click);
            // 
            // verGrafo
            // 
            this.verGrafo.Enabled = false;
            this.verGrafo.Location = new System.Drawing.Point(1013, 190);
            this.verGrafo.Margin = new System.Windows.Forms.Padding(2);
            this.verGrafo.Name = "verGrafo";
            this.verGrafo.Size = new System.Drawing.Size(91, 19);
            this.verGrafo.TabIndex = 22;
            this.verGrafo.Text = "Ver Grafo";
            this.verGrafo.UseVisualStyleBackColor = true;
            this.verGrafo.Click += new System.EventHandler(this.verGrafo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "ARM Prim generados:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "ARM Kruskal generados:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 624);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Subgrafos Conexos:";
            // 
            // PrimG
            // 
            this.PrimG.AutoSize = true;
            this.PrimG.Location = new System.Drawing.Point(131, 578);
            this.PrimG.Name = "PrimG";
            this.PrimG.Size = new System.Drawing.Size(0, 13);
            this.PrimG.TabIndex = 26;
            // 
            // Kruskgen
            // 
            this.Kruskgen.AutoSize = true;
            this.Kruskgen.Location = new System.Drawing.Point(144, 600);
            this.Kruskgen.Name = "Kruskgen";
            this.Kruskgen.Size = new System.Drawing.Size(0, 13);
            this.Kruskgen.TabIndex = 27;
            // 
            // subgen
            // 
            this.subgen.AutoSize = true;
            this.subgen.Location = new System.Drawing.Point(121, 624);
            this.subgen.Name = "subgen";
            this.subgen.Size = new System.Drawing.Size(0, 13);
            this.subgen.TabIndex = 28;
            // 
            // KruskalList
            // 
            this.KruskalList.FormattingEnabled = true;
            this.KruskalList.Location = new System.Drawing.Point(888, 52);
            this.KruskalList.Name = "KruskalList";
            this.KruskalList.Size = new System.Drawing.Size(120, 95);
            this.KruskalList.TabIndex = 29;
            // 
            // PrimList
            // 
            this.PrimList.FormattingEnabled = true;
            this.PrimList.Location = new System.Drawing.Point(1101, 52);
            this.PrimList.Name = "PrimList";
            this.PrimList.Size = new System.Drawing.Size(120, 95);
            this.PrimList.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(888, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "ARMs Kruskal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1098, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "ARMs Prim";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1259, 687);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PrimList);
            this.Controls.Add(this.KruskalList);
            this.Controls.Add(this.subgen);
            this.Controls.Add(this.Kruskgen);
            this.Controls.Add(this.PrimG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.verGrafo);
            this.Controls.Add(this.verPrim);
            this.Controls.Add(this.verkruskal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button verkruskal;
        private System.Windows.Forms.Button verPrim;
        private System.Windows.Forms.Button verGrafo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label PrimG;
        private System.Windows.Forms.Label Kruskgen;
        private System.Windows.Forms.Label subgen;
        private System.Windows.Forms.ListBox KruskalList;
        private System.Windows.Forms.ListBox PrimList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

