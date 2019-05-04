using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Grafos
    {
        int timestamp;
        bool conexo;
        public int Timestamp{ get { return timestamp; } set { timestamp = value;}}
        public bool Conexo { get { return conexo; } set { conexo = value;}}

        public Grafos() {
            this.buildArestas();
        }

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
                return grau;
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
            {   //se os vértices não possuirem adjacentes o grafo é nulo
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
            /*
             *Para	cada	vértice	u	faça	
                u.cor	=	branco;	
                u.pai	=	null;	
                Fim	para	
                timestamp	=	0	
                Para	cada	vértice	u	faça	
                se	u.cor	==	branco	
	 	        Visitar(u);	
                Fim	se	
                Fim	Para	

                timestamp	=	timestamp	+	1;	
                u.descoberta	=	timestamp;	
                u.cor	=	cinza;	
                Para	cada	vértice	v	vizinho	de	u	faça	
                se	v.cor	==	branco	
	 	        v.pai	=	u;	
	 	        Visitar(v);	
                Fim	se	
                Fim	Para	
                u.cor	=	preto;	
                timestamp	=	timestamp+1;	
                u.término	=	timestamp;	
              */
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                Program.arrayV[i].Cor = 0;
                Program.arrayV[i].Pai = null;
                //if (getGrau(Program.arrayV[i]) == 0) return false;
            }
            Timestamp = 0;
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (getGrau(Program.arrayV[i]) == 0) return this.Conexo = false;
                if (Program.arrayV[i].Cor == 0) visitarVertice(Program.arrayV[i]);
            }

            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (Program.arrayV[i].Cor == 0) return this.Conexo = false;
                else return this.Conexo = true;
            }
            return this.Conexo = true;
        }

        public bool isEuleriano()
        {
            if(this.Conexo)
            {
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    if (getGrau(Program.arrayV[i]) % 2 != 0) return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isUnicursal()
        {
            /*foreach (var item in Program.arrayA)
            {
                item.imprimeArestas(item);
            }*/
            int k = 0;
            if (this.Conexo)
            {
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    if (getGrau(Program.arrayV[i]) % 2 != 0) k++;
                }
                if (2*k > 0) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Grafos getComplementar()
        {
            List<int> verts = getAllVertices();
            List<int> adjcnt = new List<int>();
            //List<int> execpt = new List<int>();
            if (this.isCompleto())
            { 
                return null;
            }
            else
            {
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    foreach (var item in Program.arrayV[i].Adjacente)
                    {
                        adjcnt.Add(item.Id);
                    }

                    var execpt = verts.Except(adjcnt).ToList();
                    if (execpt.Contains(Program.arrayV[i].Id))
                    {
                        if (execpt.Count > 1)
                        {
                            foreach (var item in execpt)
                            {
                                if (item.Equals(Program.arrayV[i].Id)) { }
                                else
                                {
                                    Console.WriteLine("O vértice " + Program.arrayV[i].Id + " não conectar com o vértice " + item);
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    adjcnt = null;
                }
            }
            Console.ReadKey();
            return new Grafos();
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
            return v1.Adjacente.Count;
        }

        public int getGrauSaida(Vertice v1)
        {
            int sai = 0;
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                foreach (var item in Program.arrayV[i].Adjacente)
                {
                    if (item.Id == v1.Id) sai++;
                }
            }
            return sai;
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

        public void visitarVertice(Vertice u)
        {
            Timestamp++;
            u.Descoberta = timestamp;
            u.Cor = 1;
            foreach (var v in u.Adjacente)
            {
                if (v.Cor == 0)
                {
                    v.Pai = u;
                    visitarVertice(v);
                }
            }
            u.Cor = 2;
            Timestamp++;
            u.Termino = Timestamp;
        }

        private void buildArestas(){}

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
