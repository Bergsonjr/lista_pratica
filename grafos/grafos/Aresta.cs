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

        internal Vertice Origem
        {
            get
            {
                return origem;
            }

            set
            {
                origem = value;
            }
        }

        internal Vertice Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        public int Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public Aresta(Vertice o, Vertice d, int p)
        {
            this.origem = o;
            this.destino = d;
            this.peso = p;
        }
    }
}
