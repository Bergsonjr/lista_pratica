using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Arvore
    {
        List<Vertice> vertices;
        int custo;

        public Arvore()
        {
            this.Vertices = new List<Vertice>();
            this.Custo = 0;
        }

        public int Custo { get => custo; set => custo = value; }
        public List<Vertice> Vertices { get => vertices; set => vertices = value; }
    }
}
