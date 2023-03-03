namespace NuevoProyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Dato = 0;
        int cont = 0;
        ArbolBB miArbol = new ArbolBB(null); //Creación del objeto Árbol
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                if (Dato <= 0 || Dato >= 100)
                    MessageBox.Show("Solo Recibe Valores desde 1 hasta 99", "Error de Ingreso");
                else
                {
                    miArbol.Insertar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();
                    cont++;
                    Refresh();
                    Refresh();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe ingresar el valor a eliminar");
            }
            else
            {
                Dato = Convert.ToInt32(txtDato.Text);
                if (Dato <= 0 || Dato >= 100)
                {
                    MessageBox.Show("Sólo se adminten valores entre 1 y 99", "Error de Ingreso");
                }
                else
                {
                    miArbol.Eliminar(Dato);
                    txtDato.Clear();
                    txtDato.Focus();
                    cont--;
                    Refresh();
                    Refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
              
            {
                MessageBox.Show("Debe ingresar el valor a buscar");
            }
            else
            {
                Dato = Convert.ToInt32(txtDato.Text);
                if (Dato <= 0 || Dato >= 100)
                {
                    MessageBox.Show("Sólo se admiten valores entre 1 y 99", "Error de Ingreso");
                }
                else
                {
                    miArbol.Buscar(Dato);
                   //btnBuscar.Clear();
                    btnModificar.Focus();
                    Refresh();
                    Refresh();
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;//modo asociacion
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//calidad grafico
            g = e.Graphics;
            Font fuente = new Font("Arial", 18);
           miArbol.DibujarArbol(g, fuente, Brushes.Blue,Brushes.White, Pens.Black, Brushes.White);
           miArbol.colorear(g, fuente, Brushes.Blue, Brushes.White, Pens.Black, miArbol.Raiz, true, false, false);
        }
    }
    }
// Pens.Azure,
