using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimoComputo
{
    public partial class Form1 : Form
    {
        int[] arreglo;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int aux = Int32.Parse(txtNumeros.Text);
            this.arreglo = new int[aux];
            for(int i=0; i<aux; i++)
            {
                this.arreglo[i] = r.Next(0, aux);
            }
            string aux1= "";
            for(int i=0; i< arreglo.Length; i++)
            {
                aux1 += arreglo[i].ToString()+",";
            }
            lblMostrar.Text= aux1;
        }
        public void ordenarBurbuja()
        {
            int aux;
            for (int i = 1; i < arreglo.Length; i++)
            { //(i=1;1<4;i++)   (i=3;3<4;i++)
                for (int j = arreglo.Length - 1; j >= i; j--)//(j=3;3>=1;j--) (j=1;1>=1;j--)
                {       //5                  1
                    if (arreglo[j - 1] > arreglo[j])//
                    {
                        //codigo de intercambio
                        aux = arreglo[j - 1]; //5
                        arreglo[j - 1] = arreglo[j];//1
                        arreglo[j] = aux;//5
                                       //  1                5
                    }
                }
            }
        }
        public void ordenarInsersion()
        {
            for (int i = 0; i < arreglo.Length; i++)//4 ciclos
            {
                int t = arreglo[i];
                int j = i - 1;

                while ((j >= 0) && arreglo[j] > t)
                {
                    arreglo[j + 1] = arreglo[j];
                    j--;
                }
                arreglo[j + 1] = t;
            }
        }
        public void ordenarSeleccion()
        {
            int menor, posicion, auxiliar;
            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                menor = arreglo[i];
                posicion = i;

                for (int j = i + 1; j < arreglo.Length; j++)
                {
                    if (arreglo[j] < menor)
                    {
                        menor = arreglo[j];
                        posicion = j;
                    }
                }
                if (posicion != i)
                {
                    auxiliar = arreglo[i];
                    arreglo[i] = arreglo[posicion];
                    arreglo[posicion] = auxiliar;
                }
            }
        }

        private void btnBurbuja_Click(object sender, EventArgs e)
        {
            ordenarBurbuja();
            string aux = "";
            for(int i=0; i<arreglo.Length; i++)
            {
                aux += arreglo[i].ToString() + ",";
            }
            lblOrdenadoBurbuja.Text= aux;
        }

        private void btnInsersion_Click(object sender, EventArgs e)
        {
            ordenarInsersion();
            string aux = "";
            for (int i = 0; i < arreglo.Length; i++)
            {
                aux += arreglo[i].ToString() + ",";
            }
            lblOrdenarInsersion.Text = aux;
        }
    }
}
