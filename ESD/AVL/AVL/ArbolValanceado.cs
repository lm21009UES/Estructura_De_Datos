using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVL
{
    class ArbolValanceado
    {
        public int valor; //dato o valor a almacenar en el nodo, este dato puede ser de cualquier tipo incluso una estructura compleja
        public ArbolValanceado nIzquierdo; //nodo izquierdo del árbol
        public ArbolValanceado nDerecho; //nodo derecho del árbol
        public ArbolValanceado nPadre; //nodo raíz del árbol
        public int altura;//almacena en memoria la altura del árbol
        public Rectangle prueba; //para dibujar el nodo del árbol
                               //Variable que definen el tamaño de los círculos que representan los nodos del árbol
        private DibujarArbolValanceado arbol; //declarando un objeto de tipo árbol


        public DibujarArbolValanceado Arbol
        {
            get
            { return arbol; }
            set
            { arbol = value; }
        }

        //constructor con parámetros
        public ArbolValanceado(int nueva_clave, ArbolValanceado nizquierdo, ArbolValanceado nderecho, ArbolValanceado npadre)
        {
            valor = nueva_clave;
            nIzquierdo = nizquierdo;
            nDerecho = nderecho;
            nPadre = npadre;
            altura = 0;
        }

        public ArbolValanceado()
        {
        }

        //método con comportamiento recursivo para insertar un nodo en el árbol
        public ArbolValanceado Insertar(int valor_nuevo, ArbolValanceado Raiz)
        {
            if (Raiz == null)
            {
                Raiz = new ArbolValanceado(valor_nuevo, null, null, null);
            }
            else if (valor_nuevo < Raiz.valor) //si el valor a insertar es menor que la raíz
            {
                Raiz.nIzquierdo = Insertar(valor_nuevo, Raiz.nIzquierdo);
            }
            else if (valor_nuevo > Raiz.valor) //si el valor a insertar es mayor que la raíz
            {
                Raiz.nDerecho = Insertar(valor_nuevo, Raiz.nDerecho);
            }
            else
            {
                MessageBox.Show("Dato existente en el Arbol", "Error de Ingreso");
            }
            //realiza las rotaciones simples o dobles segun el caso
            if(Alturas(Raiz.nIzquierdo)-Alturas(Raiz.nDerecho) == 2)
            {
                if(valor_nuevo < Raiz.nIzquierdo.valor)
                {
                    Raiz = RotacionIzquierdaSimple(Raiz);
                }
                else
                {
                    Raiz = RotacionIzquierdaDoble(Raiz);
                }
            }
            if(Alturas(Raiz.nDerecho)- Alturas(Raiz.nIzquierdo) == 2)
            {
                if(valor_nuevo > Raiz.nDerecho.valor)
                {
                    Raiz = RotacionDerechaSimple(Raiz);
                }
                else
                {
                    Raiz = RotacionDerechaDoble(Raiz);
                }
            }
            Raiz.altura = max(Alturas(Raiz.nIzquierdo), Alturas(Raiz.nDerecho));
            return Raiz;
        }
        //función de prueba para realizar las rotaciones
        //función para obtener que rama es mayor
        private static int max(int lhs, int rhs)
        {
            return lhs>rhs? lhs : rhs;
        }
        private static ArbolValanceado RotacionIzquierdaSimple(ArbolValanceado k2)
        {
            ArbolValanceado k1 = k2.nIzquierdo;
            k2.nIzquierdo = k1.nDerecho;
            k1.nDerecho = k2;
            k2.altura = max(Alturas(k2.nIzquierdo), Alturas(k2.nDerecho)) +1;
            k1.altura = max(Alturas(k1.nIzquierdo), k2.altura) + 1;
            return k1;
        }
        private static ArbolValanceado RotacionDerechaSimple(ArbolValanceado k1)
        {
            ArbolValanceado k2 = k1.nIzquierdo;
            k1.nDerecho = k2.nIzquierdo;
            k2.nIzquierdo = k1;
            k1.altura = max(Alturas(k1.nIzquierdo), Alturas(k1.nDerecho)) + 1;
            k2.altura = max(Alturas(k2.nIzquierdo), k1.altura) + 1;
            return k2;
        }
        private static ArbolValanceado RotacionDerechaDoble(ArbolValanceado k1)
        {
            k1.nDerecho = RotacionIzquierdaSimple(k1.nDerecho);
            return RotacionDerechaSimple(k1);
        }
        private static ArbolValanceado RotacionIzquierdaDoble(ArbolValanceado k3)
        {
            k3.nIzquierdo = RotacionDerechaSimple(k3.nIzquierdo);
            return RotacionIzquierdaSimple(k3);
        }
        ArbolValanceado nodoE, nodoP;
        /*public ArbolValanceado Eliminar(int valorEliminar, ref ArbolValanceado Raiz)
        {
            if(Raiz != null)
            {
                if(valorEliminar < Raiz.valor)
                {
                    nodoE = Raiz;
                    Eliminar(valorEliminar, ref Raiz.nIzquierdo);
                }
                else
                {
                    if(valorEliminar> Raiz.valor)
                    {
                        nodoE = Raiz;
                        Eliminar(valorEliminar, ref Raiz.nDerecho);
                    }
                    else
                    {
                        //posicionado sobre el elemento a eliminar
                        ArbolValanceado NodoEliminar = Raiz;
                        if (NodoEliminar.nDerecho == null)
                        {
                            Raiz = NodoEliminar.nIzquierdo;
                            if (Alturas(nodoE.nIzquierdo)- Alturas(nodoE.nDerecho) == 2)
                            {
                                if(valorEliminar < nodoE.valor)
                                {
                                    nodoP = RotacionIzquierdaSimple(nodoE);
                                }
                                else
                                {
                                    nodoE = RotacionDerechaSimple(nodoE);
                                }
                            }
                            if (Alturas(nodoE.nDerecho) - Alturas(nodoE.nIzquierdo) == 2)
                            {
                                if (valorEliminar > nodoE.nDerecho.valor)
                                    nodoE = RotacionDerechaSimple(nodoE);
                                else
                                    nodoE = RotacionDerechaDoble(nodoE);
                                nodoP = RotacionDerechaSimple(nodoE);
                            }
                        }
                        else
                        {
                            if(NodoEliminar.nIzquierdo == null)
                            {
                                Raiz = NodoEliminar.nDerecho;
                            }
                            else
                            {
                                if(Alturas(Raiz.nIzquierdo)- Alturas(Raiz.nDerecho)>1)
                            }
                        }
                    }
                }
            }
        }*/
        //******************+VARIABLES PARA DIBUJAR*******************************
        private const int nRadio = 28;//Variable para el manejo de distancia horizontal
        private const int nDistanciaH = 80;//variable para el manejo de distancia vertical
        private const int nDistanciaV = 10;
        private int nCoordenadaX;//variable para manejar posición eje X
        private int nCoordenadaY;//variable para manejar posición eje Y
        Graphics col;
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
                grafo.DrawLine(Lapiz, nCoordenadaX, nCoordenadaY,
               nDerecho.nCoordenadaX, nDerecho.nCoordenadaY);
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
            grafo.DrawString(this.valor.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);
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
            grafo.DrawString(this.valor.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);
        }
        //Verificar altura del árbol
        private static int Alturas(ArbolValanceado p)
        {
            return p == null ? -1 : p.altura;
        }
        public void encontrado(ArbolValanceado p)
        {
            Rectangle rec = new Rectangle(p.nCoordenadaX, p.nCoordenadaY, 40, 40);
        }
    }//Clase
}
