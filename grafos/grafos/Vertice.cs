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
        int cor;
        int descoberta;
        int termino;
        Vertice pai;

        public int Id{get{return id;}set {id = value;}}
        public List<Vertice> Adjacente { get { return adjacente; } set { adjacente = value; } }
        public int Cor {get {return cor;}set {cor = value;}}
        public Vertice Pai{get{return pai;}set{pai = value;}}
        public int Descoberta{get{return descoberta;}set{ descoberta = value;}}
        public int Termino { get { return termino; } set { termino = value; } }

        public Vertice(int id) { this.id = id; Adjacente = new List<Vertice>(); }
        public Vertice(int id, List<Vertice> adjc)
        {
            this.Id = id;
            this.Adjacente = adjc;
            this.cor = 0;
            this.pai = null;
        }
    }
}
