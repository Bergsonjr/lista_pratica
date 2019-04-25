using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Grafos
    {
        private bool isAdjacente(Vertice v1, Vertice v2)
        {
            return false;
        }
        private int getGrau(Vertice v1)
        {
            return 0;
        }
        private bool isIsolado(Vertice v1)
        {
            //if(v1.Proximos)
            return false;
        }
        private bool isPendente(Vertice v1)
        {
            return false;
        }
        private bool isRegular()
        {
            return false;
        }
        private bool isNulo()
        {
            return true;
        }
        private bool isCompleto()
        {
            return true;
        }
        private bool isConexo()
        {
            return false;
        }
        private bool isEuleriano()
        {
            return true;
        }
        private bool isUnicursal()
        {
            return false;
        }
        private Grafos getComplementar()
        {
            return null;
        }
        private Grafos getAGMPrim(Vertice v1)
        {
            //deve retornar, para um grafo conexo, sua arvore geradora minima(Algoritmo de Prim)
            return null;
        }
        private Grafos getAGMKruskal(Vertice v1)
        {
            //deve retornar, para um grafo conexo, sua arvore geradora minima(Algoritmo de Kruskal)
            return null;
        }

        private int getCutVertices()
        {
            return 0;
        }

        //para grafos dirigidos
        private int getGrauEntrada()
        {
            return 0;
        }
        private int getGrauSaida()
        {
            return 0;
        }
        private bool hasCiclo()
        {
            return true;
        }
    }
}
