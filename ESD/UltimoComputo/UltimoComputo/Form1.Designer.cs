namespace UltimoComputo
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtNumeros = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnBurbuja = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.btnInsersion = new System.Windows.Forms.Button();
            this.lblMostrar = new System.Windows.Forms.Label();
            this.lblOrdenadoBurbuja = new System.Windows.Forms.Label();
            this.lblOrdenarInsersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(67, 37);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(141, 13);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "CANTIDAD DE NUMEROS:";
            // 
            // txtNumeros
            // 
            this.txtNumeros.Location = new System.Drawing.Point(226, 37);
            this.txtNumeros.Name = "txtNumeros";
            this.txtNumeros.Size = new System.Drawing.Size(179, 20);
            this.txtNumeros.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(435, 37);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnBurbuja
            // 
            this.btnBurbuja.Location = new System.Drawing.Point(453, 79);
            this.btnBurbuja.Name = "btnBurbuja";
            this.btnBurbuja.Size = new System.Drawing.Size(75, 23);
            this.btnBurbuja.TabIndex = 3;
            this.btnBurbuja.Text = "BURBUJA";
            this.btnBurbuja.UseVisualStyleBackColor = true;
            this.btnBurbuja.Click += new System.EventHandler(this.btnBurbuja_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Location = new System.Drawing.Point(453, 108);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccion.TabIndex = 4;
            this.btnSeleccion.Text = "SELECCION";
            this.btnSeleccion.UseVisualStyleBackColor = true;
            // 
            // btnInsersion
            // 
            this.btnInsersion.Location = new System.Drawing.Point(453, 138);
            this.btnInsersion.Name = "btnInsersion";
            this.btnInsersion.Size = new System.Drawing.Size(75, 23);
            this.btnInsersion.TabIndex = 5;
            this.btnInsersion.Text = "INSERSION";
            this.btnInsersion.UseVisualStyleBackColor = true;
            this.btnInsersion.Click += new System.EventHandler(this.btnInsersion_Click);
            // 
            // lblMostrar
            // 
            this.lblMostrar.AutoSize = true;
            this.lblMostrar.Location = new System.Drawing.Point(67, 193);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(35, 13);
            this.lblMostrar.TabIndex = 6;
            this.lblMostrar.Text = "label1";
            // 
            // lblOrdenadoBurbuja
            // 
            this.lblOrdenadoBurbuja.AutoSize = true;
            this.lblOrdenadoBurbuja.Location = new System.Drawing.Point(70, 224);
            this.lblOrdenadoBurbuja.Name = "lblOrdenadoBurbuja";
            this.lblOrdenadoBurbuja.Size = new System.Drawing.Size(35, 13);
            this.lblOrdenadoBurbuja.TabIndex = 7;
            this.lblOrdenadoBurbuja.Text = "label1";
            // 
            // lblOrdenarInsersion
            // 
            this.lblOrdenarInsersion.AutoSize = true;
            this.lblOrdenarInsersion.Location = new System.Drawing.Point(70, 250);
            this.lblOrdenarInsersion.Name = "lblOrdenarInsersion";
            this.lblOrdenarInsersion.Size = new System.Drawing.Size(35, 13);
            this.lblOrdenarInsersion.TabIndex = 8;
            this.lblOrdenarInsersion.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOrdenarInsersion);
            this.Controls.Add(this.lblOrdenadoBurbuja);
            this.Controls.Add(this.lblMostrar);
            this.Controls.Add(this.btnInsersion);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.btnBurbuja);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtNumeros);
            this.Controls.Add(this.lblCantidad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtNumeros;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnBurbuja;
        private System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Button btnInsersion;
        private System.Windows.Forms.Label lblMostrar;
        private System.Windows.Forms.Label lblOrdenadoBurbuja;
        private System.Windows.Forms.Label lblOrdenarInsersion;
    }
}

