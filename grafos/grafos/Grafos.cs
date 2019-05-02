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
            //verifica se existe v2 na lista de adjacencia de v1 e vice e versa.
            return v1.Adjacente.Exists(x => x.Id == v2.Id) || v2.Adjacente.Exists(x => x.Id == v1.Id) ? true : false;
        }

        public int getGrau(Vertice v1)
        { 
            //verifica se é um vertice isolado, se não for percorre contabilizando sua adjacencia com outros vértices do grafo.
            int grau = 0;
            
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    if(Program.arrayV[i] != null && Program.arrayV[i].Adjacente != null) { 
                        foreach (var item in Program.arrayV[i].Adjacente)
                        {
                            if (item.Id == v1.Id) grau++;
                        }
                    }
                }
                return grau + v1.Adjacente.Count;
        }

        public bool isIsolado(Vertice v1)
        {
            //verifica o grau do vertice e retorna
            return getGrau(v1) > 0 ? false : true;
        }

        public bool isPendente(Vertice v1)
        {
            //verica a quantidade de adjacentes daquele vertice e o grau do mesmo(vertice folha)
            return v1.Adjacente.Count == 0 && getGrau(v1) > 0 ? true : false;
        }

        public bool isRegular()
        {
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if(Program.arrayV[i] != null && Program.arrayV[i].Adjacente != null)
                {
                    foreach (var item in Program.arrayV[i].Adjacente)
                    {
                        if (Program.arrayV[i].Id == item.Id)
                        {
                            // significa que possui um loop
                            return false;
                        }
                        if (!verifyAdj(Program.arrayV[i], item)) return false;
                    }
                }
            }
            return true;
        }

        public bool isNulo()
        {
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if(Program.arrayV[i] != null && Program.arrayV[i].Adjacente != null) if (Program.arrayV[i].Adjacente.Count > 0) return false;
            }
            return true;
        }

        public bool isCompleto()
        {
            List<int> verts = getAllVertices();
            int count = 0;

            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (Program.arrayV[i] != null && Program.arrayV[i].Adjacente != null)
                {
                    foreach (var itemVB in verts)
                    {
                        foreach (var item in Program.arrayV[i].Adjacente)
                        {
                            if (item.Id == itemVB) count++;
                        }
                    }
                    if (count != verts.Count - 1) return false;
                    count = 0;
                }
            }
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
        public int getGrauEntrada(Vertice v1)
        {
            return 0;
        }

        public int getGrauSaida(Vertice v1)
        {
            return 0;
        }

        public bool hasCiclo()
        {
            return true;
        }

        //metodos genericos e privados
        private bool verifyAdj(Vertice vertice, Vertice item)
        {
            foreach (var it in item.Adjacente)
            {
                if (vertice.Id == it.Id) return false;
            }
            return true;
        }

        private List<int> getAllVertices()
        {
            List<int> verticesFinal = new List<int>();
            List<int> verts = new List<int>();

            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (Program.arrayV[i] != null)
                {
                    verts.Add(Program.arrayV[i].Id);
                    if(Program.arrayV[i].Adjacente != null)
                    {
                        foreach (var item in Program.arrayV[i].Adjacente)
                        {
                            verts.Add(item.Id);
                        }
                    }
                }
            }
            foreach (var item in verts)
            {
                if (!verticesFinal.Contains(item)) verticesFinal.Add(item);
            }
            return verticesFinal;
        }
    }
}
