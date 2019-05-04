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

        public Vertice Origem{get{return origem;}set{ origem = value;}}
        public Vertice Destino{ get{return destino;} set{ destino = value;}}
        public int Peso{ get{return peso;} set{peso = value;}}

        public Aresta(Vertice o, Vertice d, int p)
        {
            this.origem = o;
            this.destino = d;
            this.peso = p;
        }

        public void imprimeArestas(Aresta item)
        {
            Console.WriteLine("Aresta origem: " + item.Origem.Id);
            Console.WriteLine("Aresta destino: " + item.Destino.Id);
            Console.WriteLine("Aresta peso: " + item.Peso);
            Console.WriteLine("\n");
        }
    }
}
