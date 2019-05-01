using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Grafos
    {
        public Grafos() {}

        public bool isAdjacente(Vertice v1, Vertice v2)
        {
            if (v1.Adjacente.Exists(x => x.Id == v2.Id) || v2.Adjacente.Exists(x => x.Id == v1.Id)) return true;
           return false;
        }

        public int getGrau(Vertice v1)
        {
            int grau = 0;
            if (v1.Adjacente.Count == 0)
            {
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    if(Program.arrayV[i].Adjacente != null) { 
                        foreach (var item in Program.arrayV[i].Adjacente)
                        {
                            if (item.Id == v1.Id) grau++;
                        }
                    }
                }
            }
            return grau;
        }

        public bool isIsolado(Vertice v1)
        {
            if (getGrau(v1) > 0) return false;
            else return true;   
        }

        public bool isPendente(Vertice v1)
        {
            return false;
        }

        public bool isRegular()
        {
            return false;
        }

        public bool isNulo()
        {
            return true;
        }

        public bool isCompleto()
        {
            return true;
        }

        public bool isConexo()
        {
            return false;
        }

        public bool isEuleriano()
        {
            return true;
        }

        public bool isUnicursal()
        {
            return false;
        }

        public Grafos getComplementar()
        {
            return null;
        }

        public Grafos getAGMPrim(Vertice v1)
        {
            //deve retornar, para um grafo conexo, sua arvore geradora minima(Algoritmo de Prim)
            return null;
        }

        public Grafos getAGMKruskal(Vertice v1)
        {
            //deve retornar, para um grafo conexo, sua arvore geradora minima(Algoritmo de Kruskal)
            return null;
        }

        public int getCutVertices()
        {
            return 0;
        }

        //para grafos dirigidos
        public int getGrauEntrada()
        {
            return 0;
        }

        public int getGrauSaida()
        {
            return 0;
        }

        public bool hasCiclo()
        {
            return true;
        }
    }
}
