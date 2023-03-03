using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicando
{
    internal class Vertice
    {
        public int Dato;
        public int status;
        public int predecesor;
        public int tamcamino;

        public Vertice(int date)
        {
            this.Dato = date;
        }
    }
}
