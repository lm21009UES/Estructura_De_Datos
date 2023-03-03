using System;

namespace Practicando;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> listaPesos = new List<int>();
        int tamanio = 0;//variable que determinara el numero de vetices, y el tamaño de nuestra matriz de adyacencia
        do//utilizamos un do while para poder hacer validaciones
        {
            try//metodo try catch que nos permitira manejar excepciones
            {
                Console.WriteLine("INSERTE EL TAMAÑO DE LA MATRIZ DE PESO:");//pedimos al usuario insertar el tamaño de la matriz
                tamanio = Convert.ToInt32(Console.ReadLine());//capturamos el dato que se ha escrito en consola
            }
            catch (FormatException ex)//si se produce una excepcion al insertar letras o decimales, mostramos el mensaje al usuario
            {
                Console.WriteLine(ex.Message);
                tamanio = 0;
            }
        } while (tamanio == 0);//si se produce excepciones en el programa, utilizamos el while para poder asignar tamaño de matriz
        GraficaPonderada g = new GraficaPonderada(tamanio);//una vez que se ha insertado un dato que es aceptable, con el metodo de grafica ponderada
        //inicializamos un objeto pasandole como parametro el dato que hemos capturado de la consola, esto permite generar la matriz de adyacencia
        for (int i = 1; i <= tamanio; i++)//no pedimos el valor de los vertices, sino que se los asignamos en orden de acuerdo a un for
        {
            g.InsertarVertice(i);//con el metodo insertarVertice, lo que hacemos es asignar valores a los vertices que contiene el grafo
        }
        Console.WriteLine("SU MATRIZ HA SIDO GENERADA, EL TAMAÑO ES DE: " + tamanio + "x" + tamanio);//una ves generada la matriz e insertado sus vertices
        //mostramos mensaje al usuario que la matriz ha sigo generada
        Console.WriteLine("***********INSERSION DE PESOS DE LA MATRIZ****************++");//mensaje que indica que empezaremos a insertar los pesos correspondientes
        for(int i=0; i<tamanio; i++)//utilizamos un for para recorrer vertices
        {
            for(int j=0; j<tamanio; j++)//for para determinar la adyacencia que tiene un vertice con los demas
            {
                if (i != j)//si el vertice es el mismo en el que estamos, no realizamos nada, pero si es diferente entramos al codigo
                {
                    int tem = 0;//variable que nos permitira capturar el dato de la consola
                    do//bucle do while que nos permitirá poder ejecutar codigo y realizar validaciones
                    {
                        try//try catch para manejar que los valores que se inserten sean de formato correcto
                        {
                            Console.WriteLine("PESO PARA IR DE " + (i + 1) + " a + " + (j + 1) + ": ");//mensaje que muestra al usuario el peso que se le esta solicitando
                            tem = Convert.ToInt32(Console.ReadLine());//capturamos el dato
                        }catch(FormatException ex)//si se produce error por insersión de valores no aceptables
                        {
                            Console.WriteLine(ex.Message);//mostramos mensaje en consola mostrando el error
                            tem = 0;//reiniciamos la variable que captura los datos
                        }
                        if(tem <1 || tem > 10)//si no se producen excepciones, verificamos que el valor sea el indicado con los parametros que establecemos en el if
                        {
                            Console.WriteLine("SOLO SE PERMITEN PESOS MAYORES A 0 Y NO MAYORES A 10");//si no cumple con los parametros, mostramos mensaje
                        }
                    } while (tem < 1 || tem > 10);//condiciones para que el bucle se repita
                    g.InsertarArista(i + 1, j + 1, tem);//si cumple con los parametros, insertamos la arista con el peso que hemos capturado
                    listaPesos.Add(tem);
                }
            }
        }//fin para insertar pesos a la matriz de adyacencia

        //mostrando la matriz de adyacencia
        for(int i=0; i<tamanio; i++)
        {
            for(int j=0; j<tamanio; j++)
            {
                Console.Write(g.adyacencia[i, j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("------------------");
        }

        Console.WriteLine("MOSTRANDO CAMINO");
        g.BuscaCamino(1);

        Console.WriteLine("MOSTRANDO ORDEN DE PESOS POR EL METODO DE INSERSION");
        Arreglos arr = new Arreglos();
        List<int> tem1 = arr.insersion(listaPesos);
        for(int i=0; i<tem1.Count; i++)
        {
            Console.WriteLine(tem1[i] + " ");
        }
        Console.WriteLine("MOSTRANDO ORDEN DE CAMINO POR EL METODO DE INSERSION");
        List<int> tem2 = arr.insersion(g.caminosCortos);
        for(int i=0; i<tem2.Count; i++)
        {
            Console.WriteLine(tem2[i]);
        }
        Console.ReadKey();
    }
}