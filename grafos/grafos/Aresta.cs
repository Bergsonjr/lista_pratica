using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Aresta
    {
        Vertice origem;
        Vertice destino;
        int peso;
        public Aresta(Vertice o, Vertice d, int p)
        {
            this.origem = o;
            this.destino = d;
            this.peso = p;
        }
    }
}
