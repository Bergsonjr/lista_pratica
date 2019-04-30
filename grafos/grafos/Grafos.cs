﻿using System;
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
            if (v1.Adjacente.IndexOf(v2) == 0 || v2.Adjacente.IndexOf(v1) == 0) return true;
           return false;
        }

        public int getGrau(Vertice v1)
        {
            return v1.Adjacente.Count;
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
