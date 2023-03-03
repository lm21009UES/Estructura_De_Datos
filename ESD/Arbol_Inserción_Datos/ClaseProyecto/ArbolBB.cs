using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing; //librería para dibujar figuras geométricas
using System.Windows.Forms;
using ClaseProyecto;

namespace NuevoProyecto
{
    internal class ArbolBB
    {
        public Nodo Raiz;
        public Nodo aux;
        public ArbolBB()
        {
            aux = new Nodo();
        }
        public ArbolBB(Nodo nr)
        {
            Raiz = nr;
        }
        // Función para agregar un nuevo nodo (valor) al Árbol Binario.
        public void Insertar(int clave, string _nombre, string correo)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo(clave, _nombre, correo, null, null, null);
                Raiz.nivel = 0;
            }
            else
                Raiz = Raiz.Insertar(clave, _nombre, correo, Raiz, Raiz.nivel);
        }

        // Función para eliminar un nodo (valor) del Árbol Binario.
        public void Eliminar(int clave, string _nombre, string _correo)
        {
            if (Raiz == null)
                Raiz = new Nodo(clave, _nombre, _correo, null, null, null);
            else
                Raiz.Eliminar(clave, ref Raiz);
        }
        public void Buscar(int clave)
        {
            if (Raiz != null)
            {
                Raiz.buscar(clave, Raiz);
            }

        }
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            int x = 400; // Posiciones de la raíz del árbol
            int y = 75;
            if (Raiz == null)
                return;
            Raiz.PosicionNodo(ref x, y); //Posición de cada nodo
            Raiz.DibujarRamas(grafo, Lapiz); //Dibuja los Enlaces entre nodos                          //Dibuja todos los Nodos
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
        }
        public int x1 = 400;
        // Posiciones iniciales de la raíz del árbol
        public int y2 = 75;
        // Función para Colorear los nodos

        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Nodo Raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nIzquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    // pausar la ejecución 1000 milisegundos
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nDerecho, post, inor, preor);
                }
            }
            else
            if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    // pausar la ejecución 1000 milisegundos
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nIzquierdo, post,
                     inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nDerecho, post, inor, preor);
                }
            }
            else if (post == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nIzquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nDerecho, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000); // pausar la ejecución 1000 milisegundos
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                }
            }
        }

    }
}