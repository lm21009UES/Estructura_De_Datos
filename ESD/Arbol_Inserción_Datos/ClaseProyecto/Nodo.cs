using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
/*Código realizado para la asignatura Estructura de Datos*/
namespace NuevoProyecto
{
    internal class Nodo
    {
        public int Id; //dato o valor a almacenar en el nodo, este dato puede ser de cualquier tipo incluso una estructura compleja
        public string nombre;
        public string correo;
        public Nodo nIzquierdo; //nodo izquierdo del árbol
        public Nodo nDerecho; //nodo derecho del árbol
        public Nodo nPadre; //nodo raíz del árbol
        public int altura;//almacena en memoria la altura del árbol
        public int nivel;//almacena en memoria el nivel que tiene un nodo dentro del árbol
        public Rectangle nodo; //para dibujar el nodo del árbol
                               //Variable que definen el tamaño de los círculos que representan los nodos del árbol
        private const int nRadio = 50;//Variable para el manejo de distancia horizontal
        private const int nDistanciaH = 80;//variable para el manejo de distancia vertical
        private const int nDistanciaV = 10;
        private int nCoordenadaX;//variable para manejar posición eje X
        private int nCoordenadaY;//variable para manejar posición eje Y
        Graphics col;
        private ArbolBB arbol; //declarando un objeto de tipo árbol


        public ArbolBB Arbol
        {
            get
            { return arbol; }
            set
            { arbol = value; }
        }

        //constructor con parámetros
        public Nodo(int nueva_clave, string _nombre, string _correo, Nodo nizquierdo, Nodo nderecho, Nodo npadre)
        {
            Id = nueva_clave;
            nombre = _nombre;
            correo = _correo;
            nIzquierdo = nizquierdo;
            nDerecho = nderecho;
            nPadre = npadre;
            altura = 0;
        }

        public Nodo()
        {
        }

        //método con comportamiento recursivo para insertar un nodo en el árbol
        public Nodo Insertar(int nueva_clave, string _nombre, string _correo, Nodo p, int Nivel)
        {
            if (p == null)
            {
                p = new Nodo(nueva_clave, _nombre, _correo, null, null, null);//crea el nodo
                p.nivel = Nivel;
            }
            //  5
            else if (nueva_clave < p.Id) //si el valor a insertar es menor que la raíz
            {
                Nivel++;
                p.nIzquierdo = Insertar(nueva_clave, _nombre, _correo, p.nIzquierdo, Nivel);
            }
            //
            else if (nueva_clave > p.Id) //si el valor a insertar es mayor que la raíz
            {
                Nivel++;
                p.nDerecho = Insertar(nueva_clave, _nombre, _correo, p.nDerecho, Nivel);
            }
            else
            {
                MessageBox.Show("Dato existente en el Arbol", "Error de Ingreso");
            }
            return p;
        }

        //*----
        //Función para eliminar un nodo de un árbol binario
        public void Eliminar(int x, ref Nodo p)
        {
            if (p != null) //si la raíz es distinta de null
            {
                if (x < p.Id) //si el valor a eliminar es menor que la raíz
                {
                    Eliminar(x, ref p.nIzquierdo);
                }
                else
                {
                    if (x > p.Id) //si el valor a eliminar es mayor que la raíz
                    {
                        Eliminar(x, ref p.nDerecho);
                    }
                    else
                    {
                        Nodo NodoEliminar = p; //se ubica el nodo a eliminar
                                               //se verifica si tiene hijo derecho
                        if (NodoEliminar.nDerecho == null)
                        {
                            //-----
                            p = NodoEliminar.nIzquierdo;
                        }

                        else
                        {
                            //se verifica si tiene hijo izq
                            if (NodoEliminar.nIzquierdo == null)
                            {
                                p = NodoEliminar.nDerecho;
                            }
                            else
                            {
                                if (Alturas(p.nIzquierdo) - Alturas(p.nDerecho) > 0)
                                //Para verificar que hijo pasa a ser nueva raíz del subárbol
                                {
                                    Nodo AuxiliarNodo = null;
                                    Nodo Auxiliar = p.nIzquierdo;
                                    bool bandera = false;
                                    while (Auxiliar.nDerecho != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = Auxiliar.nDerecho;
                                        bandera = true;
                                    }
                                    // se crea nodo temporal
                                    p.Id = Auxiliar.Id;
                                    NodoEliminar = Auxiliar;
                                    if (bandera == true)
                                    {
                                        AuxiliarNodo.nDerecho = Auxiliar.nIzquierdo;
                                    }
                                    else
                                    {
                                        p.nIzquierdo = Auxiliar.nIzquierdo;
                                    }
                                }
                                else
                                {
                                    if (Alturas(p.nDerecho) - Alturas(p.nIzquierdo) > 0)
                                    {
                                        Nodo AuxiliarNodo = null;
                                        Nodo Auxiliar = p.nDerecho;
                                        bool bandera = false;
                                        while (Auxiliar.nIzquierdo != null)
                                        {
                                            AuxiliarNodo = Auxiliar;
                                            Auxiliar = Auxiliar.nIzquierdo;
                                            bandera = true;
                                        }
                                        p.Id = Auxiliar.Id;
                                        NodoEliminar = Auxiliar;
                                        if (bandera == true)
                                        {
                                            AuxiliarNodo.nIzquierdo = Auxiliar.nDerecho;
                                        }
                                        else
                                        {
                                            p.nDerecho = Auxiliar.nDerecho;
                                        }
                                    }
                                    else
                                    {
                                        if (Alturas(p.nDerecho) - Alturas(p.nIzquierdo) == 0)
                                        {
                                            Nodo AuxiliarNodo = null;
                                            Nodo Auxiliar = p.nIzquierdo;
                                            bool bandera = false;
                                            while (Auxiliar.nDerecho != null)
                                            {
                                                AuxiliarNodo = Auxiliar;
                                                Auxiliar = Auxiliar.nDerecho;
                                                bandera = true;
                                            }
                                            p.Id = Auxiliar.Id;
                                            NodoEliminar = Auxiliar;
                                            if (bandera == true)
                                            {
                                                AuxiliarNodo.nDerecho = Auxiliar.nIzquierdo;
                                            }
                                            else
                                            {
                                                p.nIzquierdo = Auxiliar.nIzquierdo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo NO existente el Arbol", "Error de eliminación");
            }
        } //Final de la función eliminar
          //Función buscar un nodo


        public void buscar(int clave, Nodo p)
        {
            if (p != null)
            {
                if (clave == p.Id)
                {
                    MessageBox.Show("ID ENCONTRADO\nID: " + p.Id + "\nNOMBRE: " + p.nombre + "\nCORREO: "+p.correo);
                    encontrado(p);
                }
                else
                {
                    if (clave < p.Id) //búsqueda en el subárbol izquierdo
                    {
                        buscar(clave, p.nIzquierdo);
                    }
                    else
                    {
                        if (clave > p.Id) //búsqueda en el subárbol derecho
                        {
                            buscar(clave, p.nDerecho);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo NO encontrado", "Error de búsqueda");
            }
        }

        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            nCoordenadaY = (int)(ymin + nRadio / 2);
            //obtiene la posición del sub-árbol izquierdo
            if (nIzquierdo != null)
            {
                nIzquierdo.PosicionNodo(ref xmin, ymin + nRadio + nDistanciaV);
            }
            if ((nIzquierdo != null) && (nDerecho != null))
            {
                xmin += nDistanciaH;
            }
            //si existe nodo derecho y el nodo izquierdo deja un espacio entre ellos
            if (nDerecho != null)
            {
                nDerecho.PosicionNodo(ref xmin, ymin + nRadio + nDistanciaV);
            }
            if (nIzquierdo != null && nDerecho != null)
                nCoordenadaX = (int)((nIzquierdo.nCoordenadaX + nDerecho.nCoordenadaX) / 2);
            else
            if (nIzquierdo != null)
            {
                aux1 = nIzquierdo.nCoordenadaX;
                nIzquierdo.nCoordenadaX = nCoordenadaX - 80;
                nCoordenadaX = aux1;
            }
            else if (nDerecho != null)
            {
                aux2 = nDerecho.nCoordenadaX;
                //no hay nodo izquierdo, centrar en nodo derecho
                nDerecho.nCoordenadaX = nCoordenadaX + 80;
                nCoordenadaX = aux2;
            }
            else
            {
                nCoordenadaX = (int)(xmin + nRadio / 2);
                xmin += nRadio;
            }
        }
        //Función para dibujar las ramas de los nodos izquierdo y derecho
        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if (nIzquierdo != null)
            // Dibujará rama izquierda
            {
                grafo.DrawLine(Lapiz, nCoordenadaX, nCoordenadaY, nIzquierdo.nCoordenadaX, nIzquierdo.nCoordenadaY);
                nIzquierdo.DibujarRamas(grafo, Lapiz);
            }
            if (nDerecho != null)
            // Dibujará rama derecha
            {
                grafo.DrawLine(Lapiz, nCoordenadaX, nCoordenadaY, nDerecho.nCoordenadaX, nDerecho.nCoordenadaY);
                nDerecho.DibujarRamas(grafo, Lapiz);
            }
        }
        //Función para dibujar el nodo en la posición especificada

        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            col = grafo;
            // Dibuja el contorno del nodo
            Rectangle rect = new Rectangle((int)(nCoordenadaX - nRadio / 2), (int)(nCoordenadaY - nRadio / 2), nRadio, nRadio);
            grafo.FillEllipse(encuentro, rect);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);
            grafo.DrawEllipse(Lapiz, rect);
            // Para dibujar el nombre del nodo, es decir el contenido
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(this.Id.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);

            //Dibuja los nodos hijos derecho e izquierdo.
            if (nIzquierdo != null)
            {
                nIzquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
            if (nDerecho != null)
            {
                nDerecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz)
        {
            //Dibuja el contorno del nodo.
            Rectangle rect = new Rectangle((int)(nCoordenadaX - nRadio / 2), (int)(nCoordenadaY - nRadio / 2), nRadio, nRadio);
            Rectangle prueba = new Rectangle((int)(nCoordenadaX - nRadio / 2), (int)(nCoordenadaY - nRadio / 2), nRadio, nRadio);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);
            //Dibuja el nombre
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(this.Id.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);
        }
        //Verificar altura del árbol
        private static int Alturas(Nodo p)
        {
            return p == null ? -1 : p.altura;
        }
        public void encontrado(Nodo p)
        {
            Rectangle rec = new Rectangle(p.nCoordenadaX, p.nCoordenadaY, 40, 40);
        }
    }//Clase
}// Fin Namespace
