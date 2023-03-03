using System.Drawing;
using System.Threading;

namespace ClaseProyecto
{
    internal class ArbolBB
    {
        public Nodo Raiz;
        public Nodo aux;
        public ArbolBB()//crea nodo vacio
        {
            aux = new Nodo();
        }
        public ArbolBB(Nodo nr)
        {
            Raiz = nr;
        }
        // Función para agregar un nuevo nodo (valor) al Árbol Binario.
        public void Insertar(int clave)//recibe una clave
        {
            if (Raiz == null)//primera clave, arbol
            {
                Raiz = new Nodo(clave, null, null, null);
                Raiz.nivel = 1;
                Raiz.cont = 1;
                Raiz.gradoArbol = 0;
            }
            else//ya hay elementos en el arbol
                Raiz = Raiz.Insertar(clave, Raiz, Raiz.nivel);
            Raiz.AlturaBB(Raiz);
            Raiz.GradoBB(Raiz);
            Raiz.hojasArbol = 0;
            Raiz.HojasBB(Raiz);
            Raiz.LCI = 0;
            Raiz.CaminoInterno(Raiz);
            Raiz.LCE = 0;
            Raiz.CaminoExterno(Raiz);
        }
        // Función para eliminar un nodo (valor) del Árbol Binario.
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            //posiciones iniciales
            int x = 400; // Posiciones de la raíz del árbol
            int y = 75;
            if (Raiz == null)
                return;
            Raiz.PosicionNodo(ref x, y); //Posición de cada nodo, se calcula las coordenadas
            Raiz.DibujarRamas(grafo, Lapiz); //Dibuja los Enlaces entre nodos, se calcula los arcos
                                             //Dibuja todos los Nodos
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);//dibuja las elipses de los nodos
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
                    //pintar nodos a la izquierda
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.nIzquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    // pausar la ejecución 1000 milisegundos
                    //pintar nodos a la derecha
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