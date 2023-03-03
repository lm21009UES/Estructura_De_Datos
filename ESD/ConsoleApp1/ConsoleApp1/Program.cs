using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] numeros = new int[10];
            for(int i=0; i< numeros.Length; i++)
            {
                numeros[i] = r.Next(0,20);
            }
            for(int i=0; i< numeros.Length; i++) {
                Console.WriteLine(numeros[i]);
            }
            //Console.WriteLine("VALOR = ", ht["bmp"]);
            //ICollection mapa = htb.Values;
            //ICollection valoresmapa = htb.Keys;
            Console.WriteLine("VECTOR ORDENADO");
            //burbuja(numeros);
            //insersion(numeros);

            seleccion(numeros);

            quick_sort(numeros);
            for(int i=0; i<numeros.Length; i++)
            {
                Console.WriteLine(numeros[i]);
            }
            
            Console.ReadKey();
        }
        static void burbuja(int[] r)
        {
            int aux = 0;
            for(int i=1; i<r.Length; i++)
            {
                for(int j=r.Length-1; j>=i; j--)
                {
                    if (r[j-1] > r[j])
                    {
                        aux = r[j - 1];
                        r[j - 1] = r[j];
                        r[j] = aux;
                    }
                }
            }
        }
        static void insersion(int[] r)
        {
            for(int i=0; i< r.Length; i++)
            {
                int aux = r[i];
                int j = i-1;
                while((j>=0) && r[j] > aux) {
                    r[j + 1] = r[j];
                    j--;
                }
                r[j+1] = aux;
            }
        }
        static void seleccion(int[] arreglo)
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
        static void quick_sort(int[] arreglo)
        {

            quick_sort(arreglo, 0, arreglo.Length - 1);

            ///----
        }
        static void quick_sort(int[] arr, int inicio, int fin)
        {
            //5+(8-5) =8/2
            int pivote = arr[(inicio + (fin - inicio) / 2)];
            int izquierda = inicio;//5
            int derecha = fin;//8
            while (izquierda <= derecha)//5<=8
            {
                while (arr[izquierda] < pivote)//
                {
                    izquierda++;
                }
                while (arr[derecha] > pivote)
                {
                    derecha--;
                }
                if (izquierda <= derecha)//
                {
                    swap(arr, izquierda, derecha);
                    izquierda++;
                    derecha--;
                }

            }
            if (inicio < derecha)
            {
                quick_sort(arr, inicio, izquierda - 1);
            }
            if (fin > izquierda)
            {
                quick_sort(arr, izquierda + 1, fin);
            }
        }
        static void swap(int[] items, int x, int y)
        {
            int temp = items[x];
            items[x] = items[y];
            items[y] = temp;
        }
    }
}
