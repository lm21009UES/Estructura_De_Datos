using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaseProyecto
{
    internal class Nodo
    {
        public int clave; //dato o valor a almacenar en el nodo, este dato puede ser de cualquier tipo incluso una estructura compleja
        public Nodo nIzquierdo; //nodo izquierdo del árbol
        public Nodo nDerecho; //nodo derecho del árbol
        public Nodo nPadre; //nodo raíz del árbol
        public int altura;//almacena en memoria la altura del árbol
        public int nivel;//almacena en memoria el nivel que tiene un nodo dentro del árbol
        public Rectangle nodo; //para dibujar el nodo del árbol
                               //Variable que definen el tamaño de los círculos que representan los nodos del árbol
        int i = 0, j=1;
        public int cont = 0;
        public int gradoArbol;
        public int hojasArbol;
        public int LCE = 0;
        public int LCI = 0;
        private const int nRadio = 28;//Variable para el manejo de distancia horizontal
        private const int nDistanciaH = 80;//variable para el manejo de distancia vertical
        private const int nDistanciaV = 10;
        private int nCoordenadaX;//variable para manejar posición eje X
        private int nCoordenadaY;//variable para manejar posición eje Y
        Graphics col;//para dibujar los circulos
        private ArbolBB arbol; //declarando un objeto de tipo árbol
                               //constructor con parámetros
        public ArbolBB Arbol
        {
            get
            { return arbol; }
            set
            { arbol = value; }
        }
        public Nodo(int nueva_clave, Nodo nizquierdo, Nodo nderecho, Nodo npadre)
        {
            clave = nueva_clave;
            nIzquierdo = nizquierdo;
            nDerecho = nderecho;
            nPadre = npadre;
            altura = 1;
            gradoArbol = 0;
            hojasArbol = 0;
        }

        public Nodo()
        {
        }
        //método con comportamiento recursivo para insertar un nodo en el árbol
        public Nodo Insertar(int nueva_clave, Nodo p, int Nivel)
        {
            if (p == null)
            {
                p = new Nodo(nueva_clave, null, null, null);//crea el nodo
                p.nivel = Nivel;
                cont++;
            }
            else if (nueva_clave < p.clave) //si el valor a insertar es menor que la raíz
            {
                Nivel++;
                p.nIzquierdo = Insertar(nueva_clave, p.nIzquierdo, Nivel);
            }
            else if (nueva_clave > p.clave) //si el valor a insertar es mayor que la raíz
            {
                Nivel++;
                p.nDerecho = Insertar(nueva_clave, p.nDerecho, Nivel);
            }
            else
            {
                MessageBox.Show("Dato existente en el Arbol", "Error de Ingreso");
            }
            return p;
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
        public void DibujarRamas(Graphics grafo, Pen Lapiz)//genera los arcos de los nodos
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
            //mostrar clave
            grafo.DrawString(this.clave.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);
            grafo.DrawString(this.nivel.ToString(), fuente, RellenoFuente, nCoordenadaX + 50, nCoordenadaY, formato);
            //Dibuja los nodos hijos derecho e izquierdo.
            if (nIzquierdo != null)//nodo izquierdo, bibujando
            {
                nIzquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
            if (nDerecho != null)//nodo derecho dibujar
            {
                nDerecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz)
        {
            //Dibuja el contorno del nodo.
            Rectangle rect = new Rectangle((int)(nCoordenadaX - nRadio / 2), (int)(nCoordenadaY - nRadio / 2), nRadio, nRadio);//coordenadas iniciales
            Rectangle prueba = new Rectangle((int)(nCoordenadaX - nRadio / 2), (int)(nCoordenadaY - nRadio / 2), nRadio, nRadio);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);
            //Dibuja el nombre
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(this.clave.ToString(), fuente, RellenoFuente, nCoordenadaX, nCoordenadaY, formato);
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
        public void AlturaBB(Nodo nodo)//función para calcular altura, pasamos el nodo raiz como parametro
        {
            if(nodo != null)//si el nodo no esta nulo, procedemos a realizar la ejecución
            {
                i++;//incrementamos la variable contadora
                //llamamos a la función de recursividad
                AlturaBB(nodo.nIzquierdo);
                AlturaBB(nodo.nDerecho);
                //decrementamos la variable i par que no nos tome una altura mas elevada de la que nos debería mostrar
                i--;
                if(i == j)//igualamos las variables i con J, si estas son iguales
                {
                    j++;//incrementamos la variable j y sera el valor que tomará la altura
                    altura = j;
                }
            }
        }
        public void GradoBB(Nodo nodo)//función para calcular el grado del arbol
        {
            int tem = 0;//declaramos una variable contadora
            if (gradoArbol == 2)//si el grado del arbol ya se encuentra en 2, pues simplemente retornamos y no ejecutamos nada
                return;
            if(nodo != null)//si el nodo no es nulo, verificamos en el codigo
            {
                if(nodo.nIzquierdo == null && nodo.nIzquierdo != null || nodo.nIzquierdo != null && nodo.nDerecho == null)
                    //si hay un nodo, ya sea izquierdo o derecho, significa que el grado de ese arból es de 1
                {
                    tem++;//incrementamos la variable contadora en 1
                }
                if(nodo.nIzquierdo != null && nodo.nDerecho != null)//si los nodos izquierdos y derechos tienen información, entonces hay dos ramas
                {
                    tem = tem + 2;//la variable contadora será con el valor de 2
                }
                if (gradoArbol < tem)//si la variable contadora es mayor que el grado del arbol actual
                    gradoArbol = tem;//el grado del arból pasara a tomar el valor de la variable contadora
                //llamamos a la función para seguir con el estudio de los demas nodos
                GradoBB(nodo.nIzquierdo);
                GradoBB(nodo.nDerecho);
            }
        }
        public void HojasBB(Nodo nodo)//función para calcular las hojas
        {
            if(nodo != null)//si el nodo no es nulo
            {
                HojasBB(nodo.nIzquierdo);//llamamos a la función recursiva
                HojasBB(nodo.nDerecho);
                if (nodo.nivel > 1)
                {
                    if (nodo.nIzquierdo == null && nodo.nDerecho == null)//si los nodos son nulos, es porque no hay mas información
                    {
                        hojasArbol++;//incrementamos la variable que nos muestra las hojas
                    }
                }
            }
        }
        int vartem = 0;
        public void CaminoInterno(Nodo nodo)//función para el camino interno
        {

            if (nodo != null)//si el nodo tiene información
            {
                vartem++;//aumentamos nuestra variable contadora en 1
                LCI = LCI + vartem;//al lci le sumamos la variable contadora
                CaminoInterno(nodo.nIzquierdo);//llamamos a la función recursiva para continuar
                CaminoInterno(nodo.nDerecho);
                vartem--;
            }
        }
        int bandera = 0;
        public void CaminoExterno(Nodo n)//funcion para calcular el LCE
        {
            if(n != null)//si el dato que pasamos es nulo no ejecutamos nada
            {
                bandera++;//si el dato contiene información incrementamos en una unidad la variable que tenemos como contador
                if (n.nivel > 1)//en el LCE necesitamos mas nodos aparte de la raíz para poder trabajar, por ello, verificamos que no sea el nivel en el que 
                    //se encuentra la raiz
                {
                    if (gradoArbol == 1)//si el grado con el que se cuenta es solamente 1, entramos al if
                    {
                        if (n.nDerecho == null && n.nIzquierdo == null)//siendo que tenemos grado 1, es necesario que el nodo tenga su lado izquierdo y derecho
                            //nulo, ya que si un lado tuviera información, y tenemos grado 1, no entraría en el codigo
                            LCE = LCE + (bandera + 1);//al LCE le sumamos la variable bandera que nos indica el nivel en el que se encuentra y le sumamos 1
                    }
                    if (gradoArbol == 2)//si el grado el arbol es 2, entramos al código
                    {
                        if (n.nIzquierdo == null)//si el nodo izquierdo es nulo
                        {
                            LCE = LCE + (bandera + 1);//incrementamos el LCE
                        }
                        if (n.nDerecho == null)//si el nodo derecho es nulo, incrementamos el LCE
                        {
                            LCE = LCE + (bandera + 1);
                        }
                    }
                }
                //siendo que no es nulo, hacemos la llamada recursiva de la función pasando los nodos izquierdo y derecho
                CaminoExterno(n.nIzquierdo);
                CaminoExterno(n.nDerecho);
                bandera--;
            }
        }
    }
}
