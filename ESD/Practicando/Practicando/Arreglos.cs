using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicando
{
    internal class Arreglos
    {
        public List<int> insersion(List<int> r)
        {
            for (int i = 0; i < r.Count; i++)
            {
                int aux = r[i];
                int j = i - 1;
                while ((j >= 0) && r[j] > aux)
                {
                    r[j + 1] = r[j];
                    j--;
                }
                r[j + 1] = aux;
            }
            return r;
        }
    }
}
