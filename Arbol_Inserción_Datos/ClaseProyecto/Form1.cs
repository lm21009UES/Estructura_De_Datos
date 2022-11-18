using NuevoProyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseProyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Dato = 0;//variable que almacenara el ID
        string NombreP;//variable para almacenar el nombre
        string correoP;//variable para almacenar el correo
        int cont = 0;//variable contadora para verificar el numero de nodos o registros
        ArbolBB miArbol = new ArbolBB(null); //Creación del objeto Árbol
        Graphics g;//variable que nos permitira dibujar 

        //metodo boton insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "" || txtNombre.Text =="" || txtCorreo.Text == "")//si la sección donde se inserta datos esta vacia
            {
                if (txtDato.Text == "")//si el campo donde se inserta el ID esta vacio, hacemos que que su color cambie a rosado
                    txtDato.BackColor = Color.Pink;
                else
                    txtDato.BackColor = Color.White;//sino, su color sera blanco
                if (txtNombre.Text == "")
                    txtNombre.BackColor = Color.Pink;//si el campo donde se inserta el nombre esta vacio, se rellena con el color rosado
                else
                    txtNombre.BackColor = Color.White;//sino esta vacio, lo colocamos de color blanco
                if (txtCorreo.Text == "")
                    txtCorreo.BackColor = Color.Pink;//si donde esta el correo, se encuentra vacio, lo coloreamos rosado
                else
                    txtCorreo.BackColor = Color.White;//si no esta vacio, lo ponemos color blanco
                MessageBox.Show("HAY CAMPOS QUE SE ENCUENTRAN VACIOS, DEBE DE RELLENARLOS");//mostramos la validación para datos nulos
            }
            else//si hay información validamos lo siguiente
            {
                Dato = int.Parse(txtDato.Text);//el texto de string lo convertimos a int
                NombreP = txtNombre.Text;//guardamos el nombre
                correoP = txtCorreo.Text;//guardamos el correo
                if (Dato<1)//si el dato no esta en el rango permitido, mostramos mensaje de error
                    MessageBox.Show("SOLO RECIBE VALORES MAYORES DE 1", "Error de ingreso");
                else//si el dato es aceptable
                {
                    txtDato.Clear();//limpiamos el textBox donde se inserta la imformación
                    txtDato.Focus();//el puntero se coloca en el textBox
                    txtNombre.Clear();//limpiamos el campo de nombre
                    txtCorreo.Clear();//limpiamos el campo de correo
                    //cambiamos los colores de los campos
                    txtCorreo.BackColor = Color.White;
                    txtDato.BackColor = Color.White;
                    txtNombre.BackColor = Color.White;
                    miArbol.Insertar(Dato, NombreP, correoP);//llamamos al constructor de mi arbol que crea un nodo
                    
                    cont++;//el contador se aumenta en una unidad, que nos indica la cantidad de nodos
                    Refresh();//actualizamos los elementos del formulario
                    //automaticamente llamamos el metodo Paint
                    Refresh();
                    MessageBox.Show("**************+DATOS INSERTADOS***************\n   +ID: "+Dato+"\n   +NOMBRE: "+NombreP+"\n  +CORREO: "+correoP);
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
            miArbol.DibujarArbol(g, fuente, Brushes.Pink, Brushes.Black, Pens.Black, Brushes.White);
            //miArbol.colorear(g, fuente, Brushes.Blue, Brushes.White, Pens.Black, miArbol.Raiz, true, false, false);
        }
        //BOTON BUSCAR
        private void btbBuscar_Click(object sender, EventArgs e)
        {
            if (miArbol.Raiz != null)//si hay información almacenada en el arbol
            {
                if (txtDato.Text == "")//verificamos que no este vacio el campo de ID
                {
                    //mostramos mensaje de error, y limpiamos los campos
                    MessageBox.Show("PARA HACER BUSQUEDAS, SOLO SE REQUIERE CAMPO DE ID, VERIFIQUE QUE HAYA INGRESADO UN ID");
                    txtCorreo.Clear();
                    txtNombre.Clear();
                }
                else//si hay un ID digitado
                {
                    Dato = Convert.ToInt32(txtDato.Text);//hacemos la conversión de String a int
                    if (Dato < 1)// si el ID es menor a 1
                    {
                        //mostramos mensaje de error
                        MessageBox.Show("Sólo se admiten valores mayores a  0", "Error de Ingreso");
                    }
                    else//si cumple las restricciones
                    {
                        //llamamos a la función de buscar de la clase ArbolBB
                        miArbol.Buscar(Dato);
                        //btnBuscar.Clear();
                        txtDato.Clear();
                        txtNombre.Clear();
                        txtCorreo.Clear();
                        btbBuscar.Focus();
                        Refresh();
                        Refresh();
                    }
                }
            }
            else//si no hay datos aun, mostramos mensaje de error
            {
                MessageBox.Show("NO HAY DATOS PARA PODER BUSCAR");
            }

        }
        //BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (miArbol.Raiz != null)//si el arbol tiene elementos
            {
                if (txtDato.Text == "")//verificamos si el campo de ID esta vacio
                {
                    MessageBox.Show("PARA ELIMINAR, SE REQUIERE QUE DIGITE UN ID EXISTENTE, VERIFIQUE QUE EL CAMPO NO ESTE VACIO");
                    txtCorreo.Clear();
                    txtNombre.Clear();
                }
                else//si contiene información
                {
                    Dato = Convert.ToInt32(txtDato.Text);//hacemos la conversión de la informacion a entero
                    if (Dato <1)//si el ID insertado es menor a 1
                    {
                        MessageBox.Show("Sólo se adminten valores mayores a 0", "Error de Ingreso");//mensaje de error
                    }
                    else//si cumple con las restricciones
                    {
                        miArbol.Eliminar(Dato, NombreP, correoP);//llamamos a la función de Eliminar de la clase ArbolBB, pasamos ID, nombre, correo como parametros
                        //limpiamos los campos que contienen información
                        txtDato.Clear();
                        txtDato.Focus();
                        txtCorreo.Clear();
                        txtNombre.Clear();
                        //disminuimos la variable que nos demuestra los datos que se han insertado
                        cont--;
                        Refresh();
                        Refresh();
                    }
                }
            }
            else//si no hay datos insertados, mostramos mensajes de error
            {
                MessageBox.Show("NO HAY DATOS INSERTADOS AUN");
            }

        }
        //validacion para el campo de ID
        private void txtDato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))//si se presiona alguna letra, mostramos el mensaje de error
            {
                e.Handled = true;
                MessageBox.Show("SOLO SE PERMITE INSERSION DE NUMEROS");
            }
        }
        //validacion de lo que se esta insertando en el campo de nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))//se permite letras
            {
                e.Handled = false;
            }
            else if(e.KeyChar == ' ')//se permite espacios
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))//se permite letras de control
            {
                e.Handled = false;
            }
            else//cualquier otro tipo de caracteres no es permitido
            {
                e.Handled = true;
                MessageBox.Show("DATO NO PERMITIDO");
            }
        }
    }
}
