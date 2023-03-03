using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicando
{
    internal class GraficaPonderada
    {
        public List<int> caminosCortos = new List<int>();
        Vertice[] verticeLista;
        public readonly int MAX_VERTICES = 30;//maximo vertices del ejercicio
        public int[,] adyacencia;//matriz de adyacencia contiene los pesos puede tomar valores (nulo,infinito y enteros)
        int n;//cantidad de vertices
        int e;//cantidad de aristas
        private readonly int TEMPORAL = 1;// no tiene el menor peso (no es parte del camino optimo)
        private readonly int PERMANENTE = 2;//tiene menor peso y es parte del camino optimo
        private readonly int NULO = -1;//si los indices son iguales
        private readonly int INFINITO = 99999;//si no existe un camino
        public GraficaPonderada(int x)
        {
            //crea la matrix y el arreglo que contiene la lista de vertices
            adyacencia = new int[MAX_VERTICES, MAX_VERTICES];//Matriz de 30*30
            verticeLista = new Vertice[x];//vector 30 elementos
        }
        private int GetVertice(int s)//funcion para poder obtener el vertice
        {
            for (int i = 0; i < n; i++)//iniciamos a buscar dentro del arreglo de vertices
                if (s.Equals(verticeLista[i].Dato))//si vertice en la posicion i, es igual al vertice que estamos buscando, retornamos i
                    return i;
            throw new System.InvalidOperationException("Vertice invalido");//mensaje de invalidación que demuestra que el vertice no existe
        }

        public void InsertarVertice(int nombre)//metodo para insertar vertice, recibe como parametro un numero entero
        {
            verticeLista[n++] = new Vertice(nombre);//va ingresando en la lista de vertices, de acuerdo a las posiciones que se han insertado
        }
        public void InsertarArista(int s1, int s2, int peso)//metodo para insertar arista
        {
            int u = GetVertice(s1);//primero verificamos si el vertice 1 se encuentra
            int v = GetVertice(s2);//verificamos si el vertice que hemos pasado como segundo se encuentra
            if (u == v)//si los vertices que hemos buscado son iguales
                throw new System.InvalidOperationException("No es posible agregar la arista");//mostramos mensaje que no es posible insertar una arista

            if (adyacencia[u, v] != 0)//si la arista que queremos insertar ya tiene un valor
                Console.Write("Arista ya está presente");//mostramos mensaje que ya esta presente o existe esa arista
            else//si se encuentra vacio
            {
                adyacencia[u, v] = peso;//insertamos el peso que queremos pasar como parametro
                e++;//aumentamos la variable contadora que tenemos
            }
        }
        private void Dijkstra(int s)//recibe vertice origen
        {
            int v, c;// c tiene el indice del vertice con menor tamaño de camino

            for (v = 0; v < n; v++)//llena la lista de vertices con los estados (temporal,infinito,nulo)
            {
                verticeLista[v].status = TEMPORAL;
                verticeLista[v].tamcamino = INFINITO;
                verticeLista[v].predecesor = NULO;
            }

            verticeLista[s].tamcamino = 0; //el tamanio del camino del vertice origen se asigna a cero

            while (true) //se sale de este ciclo hasta que c==NULO
            {
                c = TempVertexMinPL();//retorna los vertices temporales y con menor valor

                if (c == NULO)//el indice del vertice con menor tamanio de camino es igual a nulo se sale del while
                    return;

                verticeLista[c].status = PERMANENTE;//se cambia a permanente  el estatus del vertice con menor tamanio de camino

                for (v = 0; v < n; v++)
                {
                    if (EsAdjacente(c, v) && verticeLista[v].status == TEMPORAL)// si es diferente de cero y vertice recorrido es temporal
                        if (verticeLista[c].tamcamino + adyacencia[c, v] < verticeLista[v].tamcamino)//
                        {
                            verticeLista[v].predecesor = c;//predecesor se actualiza con el menor peso
                            verticeLista[v].tamcamino = verticeLista[c].tamcamino + adyacencia[c, v];////tamaño de amino es igual al  tamanio+ nuevo peso
                        }
                }
            }//fin ciclo
        }
        //Encuentra el vertice con menor tamaño del camino
        private int TempVertexMinPL()
        {
            int min = INFINITO;
            int x = NULO;//indice de vertice con menor camino ==NULO
            for (int v = 0; v < n; v++)//se recorre toda la lista
            {
                if (verticeLista[v].status == TEMPORAL && verticeLista[v].tamcamino < min)//si es temporal y tamaño de camino es < que el valor minimo
                {
                    min = verticeLista[v].tamcamino;//min toma el valor del vertice analizado
                    x = v;//x toma el indice del valor minimo
                }
            }
            return x;//retorna el indice donde esta el vertice con menor tamaño de camino
        }
        private bool EsAdjacente(int u, int v)
        {
            return (adyacencia[u, v] != 0);
        }
        public void BuscaCamino(int origen)
        {
            int s = GetVertice(origen);//Recibe vertice origen

            Dijkstra(s);//recorre la grafica

            Console.WriteLine("Vertice Origen(O) : " + origen + "\n");//muresta vertice origen

            for (int v = 0; v < n; v++)//recorre todo los vertices
            {
                Console.WriteLine("Vertice Destino : " + verticeLista[v].Dato);//hace que el vertice actual sea el destino
                if (verticeLista[v].tamcamino == INFINITO)//si el tamanio de camino del vertice actual es infinito
                    Console.WriteLine("No hay camino desde " + origen + " a " + verticeLista[v].Dato + "\n");//muestra mensaje
                else// si no es infinito
                    BuscaCamino(s, v);//envia vertice origen y destino.
            }
        }
        private void BuscaCamino(int s, int v)
        {
            int i, u;// i almacena el vetice origen  v almacena el vettice destino
            int[] camino = new int[n];//se crea un arreglo de n elementos
            int dc = 0;//la distancia mas corta se inicializa en cero
            int contador = 0;

            while (v != s)//si el vertice destino es diferente al vertice origen  entrar al while
            {
                contador++; //incrementa contador en una unidad
                camino[contador] = v;//camino sera igual al destino
                u = verticeLista[v].predecesor;//
                dc += adyacencia[u, v];//suma a la distancia mas corta el valor de la arista
                v = u;//verice=predecesor
            }
            contador++;//acumula la cantidad de vertices
            camino[contador] = s;//

            Console.Write("Camino más corto es : ");
            for (i = contador; i >= 1; i--)//recorre a la inversa la matriz
                Console.Write(camino[i] + " ");
            Console.WriteLine("\n La distancia más corta es : " + dc + "\n");//muestra ka distancia mas corta
            caminosCortos.Add(dc);
        }
    }
}
