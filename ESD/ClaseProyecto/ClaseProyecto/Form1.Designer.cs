namespace ClaseProyecto
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
            this.txtDato = new System.Windows.Forms.TextBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btbBuscar = new System.Windows.Forms.Button();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblMostrarAltura = new System.Windows.Forms.Label();
            this.lblGrado = new System.Windows.Forms.Label();
            this.lblMostrarGrado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadNodo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHojas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLCI = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLCE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(93, 50);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(174, 20);
            this.txtDato.TabIndex = 0;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(311, 46);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 1;
            this.btnInsertar.Text = "INSERTAR";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(408, 46);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btbBuscar
            // 
            this.btbBuscar.Location = new System.Drawing.Point(510, 46);
            this.btbBuscar.Name = "btbBuscar";
            this.btbBuscar.Size = new System.Drawing.Size(75, 23);
            this.btbBuscar.TabIndex = 3;
            this.btbBuscar.Text = "BUSCAR";
            this.btbBuscar.UseVisualStyleBackColor = true;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(49, 110);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(50, 13);
            this.lblAltura.TabIndex = 4;
            this.lblAltura.Text = "ALTURA";
            // 
            // lblMostrarAltura
            // 
            this.lblMostrarAltura.AutoSize = true;
            this.lblMostrarAltura.Location = new System.Drawing.Point(114, 110);
            this.lblMostrarAltura.Name = "lblMostrarAltura";
            this.lblMostrarAltura.Size = new System.Drawing.Size(32, 13);
            this.lblMostrarAltura.TabIndex = 5;
            this.lblMostrarAltura.Text = "\".....\"";
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Location = new System.Drawing.Point(49, 140);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(46, 13);
            this.lblGrado.TabIndex = 6;
            this.lblGrado.Text = "GRADO";
            // 
            // lblMostrarGrado
            // 
            this.lblMostrarGrado.AutoSize = true;
            this.lblMostrarGrado.Location = new System.Drawing.Point(114, 140);
            this.lblMostrarGrado.Name = "lblMostrarGrado";
            this.lblMostrarGrado.Size = new System.Drawing.Size(29, 13);
            this.lblMostrarGrado.TabIndex = 7;
            this.lblMostrarGrado.Text = "\"::::\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CANTIDAD NODOS";
            // 
            // lblCantidadNodo
            // 
            this.lblCantidadNodo.AutoSize = true;
            this.lblCantidadNodo.Location = new System.Drawing.Point(90, 198);
            this.lblCantidadNodo.Name = "lblCantidadNodo";
            this.lblCantidadNodo.Size = new System.Drawing.Size(29, 13);
            this.lblCantidadNodo.TabIndex = 9;
            this.lblCantidadNodo.Text = "\"::::\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "HOJAS";
            // 
            // lblHojas
            // 
            this.lblHojas.AutoSize = true;
            this.lblHojas.Location = new System.Drawing.Point(97, 227);
            this.lblHojas.Name = "lblHojas";
            this.lblHojas.Size = new System.Drawing.Size(29, 13);
            this.lblHojas.TabIndex = 11;
            this.lblHojas.Text = "\"::::\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "LCI";
            // 
            // lblLCI
            // 
            this.lblLCI.AutoSize = true;
            this.lblLCI.Location = new System.Drawing.Point(84, 258);
            this.lblLCI.Name = "lblLCI";
            this.lblLCI.Size = new System.Drawing.Size(29, 13);
            this.lblLCI.TabIndex = 13;
            this.lblLCI.Text = "\"::::\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "LCE";
            // 
            // lblLCE
            // 
            this.lblLCE.AutoSize = true;
            this.lblLCE.Location = new System.Drawing.Point(84, 288);
            this.lblLCE.Name = "lblLCE";
            this.lblLCE.Size = new System.Drawing.Size(29, 13);
            this.lblLCE.TabIndex = 15;
            this.lblLCE.Text = "\"::::\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLCE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLCI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHojas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCantidadNodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMostrarGrado);
            this.Controls.Add(this.lblGrado);
            this.Controls.Add(this.lblMostrarAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.btbBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.txtDato);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btbBuscar;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblMostrarAltura;
        private System.Windows.Forms.Label lblGrado;
        private System.Windows.Forms.Label lblMostrarGrado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadNodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHojas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLCI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLCE;
    }
}

