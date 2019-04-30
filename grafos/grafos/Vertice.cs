using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Vertice
    {
        int id;
        List<Vertice> adjacente;

        public int Id{get{return id;}set {id = value;}}
        public List<Vertice> Adjacente { get { return adjacente; } set { adjacente = value; } }

        public Vertice(int id) { this.id = id; Adjacente = new List<Vertice>(); }
        public Vertice(int id, List<Vertice> adjc)
        {
            this.Id = id;
            this.Adjacente = adjc;
        }
    }
}
