using System.Data;

namespace CLASE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Dato = 0;
        int cont = 0;
        ArbolBB miArbol = new ArbolBB(null);//creación del objeto arbol
        Graphics g;
        private void txtDato_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if(txtDato.Text == "")//si la sección donde se inserta datos esta vacia
            {
                MessageBox.Show("Debe Ingresar un Valor");//mostramos la validación para datos nulos
            }
            else//si hay información validamos lo siguiente
            {
                Dato = int.Parse(txtDato.Text);//el texto de string lo convertimos a int
                if (Dato <= 0 || Dato >= 100)//si el dato no esta en el rango permitido, mostramos mensaje de error
                    MessageBox.Show("SOLO RECIBE VALORES DESDE 1 HASTA 99", "Error de ingreso");
                else//si el dato es aceptable
                {
                    miArbol.Insertar(Dato);//llamamos al constructor de mi arbol que crea un nodo
                    txtDato.Clear();//limpiamos el textBox donde se inserta la imformación
                    txtDato.Focus();//el puntero se coloca en el textBox
                    cont++;//el contador se aumenta en una unidad, que nos indica la cantidad de nodos
                    Refresh();//actualizamos los elementos del formulario
                    //automaticamente llamamos el metodo Paint
                    Refresh();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;//para ajustar el texto
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//calidad de grafico
            g = e.Graphics;
            Font fuente = new Font("Arial", 15);//fuente y tamaño de fuente que se utilizara para los nodos
            miArbol.DibujarArbol(g, fuente, Brushes.YellowGreen, Brushes.Black, Pens.Black, Brushes.Black);//mandamos los parametros para dibujar el arbol
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}