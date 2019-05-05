using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafos
{
    class Grafos
    {
        Vertice[] removed;
        int timestamp;
        bool passed;
        bool conexo;
        int count;
        int count2;
        int qtd;
        Arvore arv;
        public int Timestamp{ get { return timestamp; } set { timestamp = value;}}
        public bool Conexo { get { return conexo; } set { conexo = value;}}
        public bool Passed { get => passed; set => passed = value; }
        public Arvore Arv { get => arv; set => arv = value; }
        public int Count { get => count; set => count = value; }
        public int Count2 { get => count2; set => count2 = value; }
        public int Qtd { get => qtd; set => qtd = value; }
        internal Vertice[] Removed { get => removed; set => removed = value; }

        public Grafos() {
            this.buildArestas();
            this.passed = false;
            this.Arv = new Arvore();
            this.qtd = 0;
            this.Count2 = 0;
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
                Para	cada	vértice	u	faça	
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

            for (int j = 0; j < Program.arrayV.Length; j++)
            {
                if (Program.arrayV[j].Cor == 0) return this.Conexo = false;
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
            /* 
              Seja G(V,A) um grafo orientado e s um vértice de G:

              Atribua valor zero à estimativa do custo mínimo do vértice s (a raiz da busca) e infinito às demais estimativas;
              Atribua um valor qualquer aos precedentes (o precedente de um vértice t é o vértice que precede t no caminho de custo mínimo de s para t);
              Enquanto houver vértice aberto:
              seja k um vértice ainda aberto cuja estimativa seja a menor dentre todos os vértices abertos;
              feche o vértice k
              Para todo vértice j ainda aberto que seja sucessor de k faça:
              some a estimativa do vértice k com o custo do arco que une k a j;
              caso esta soma seja melhor que a estimativa anterior para o vértice j, substitua-a e anote k como precedente de j.
             */

            if (!Passed) {
                for (int i = 0; i < Program.arrayV.Length; i++)
                {
                    Program.arrayV[i].Cor = 0;
                }
                foreach (var item in Program.arrayA)
                {
                    item.Origem.Cor = 0;
                    item.Destino.Cor = 0;
                }
            }
            if (this.Conexo && v1.Cor == 0 && v1 != null)
            {
                Passed = true;
                Arv.Vertices.Add(v1); // iniciando pelo vertice parametrizado
                int peso = int.MaxValue;
                var atual = v1;
                Vertice proximo = null;

                foreach (var aresta in Program.arrayA)
                {
                    if (atual.Id == aresta.Origem.Id && aresta.Origem.Cor == 0 && aresta.Destino.Cor == 0) // se o vertice atual for igual ao da aresta percorrida
                    {
                        if (aresta.Peso < peso)
                        {
                            peso = aresta.Peso;
                            proximo = aresta.Destino;
                        }
                        if (aresta.Peso == peso)
                        {
                            if (proximo != null)
                            {
                                if (proximo.Id < aresta.Origem.Id)  // escolhe o vértice de menor indice
                                {
                                    peso = aresta.Peso;
                                    proximo = aresta.Destino;
                                }
                            }
                        }
                    }
                    else if (atual.Id == aresta.Destino.Id && aresta.Origem.Cor == 0 && aresta.Destino.Cor == 0)
                    {
                        if (aresta.Peso < peso)
                        {
                            peso = aresta.Peso;
                            proximo = aresta.Origem;
                        }
                        if (aresta.Peso == peso)
                        {
                            if (proximo != null)
                            {
                                if (proximo.Id < aresta.Destino.Id) // escolhe o vértice de menor indice
                                {
                                    peso = aresta.Peso;
                                    proximo = aresta.Origem;
                                }
                            }
                        }
                    }
                }

                foreach (var item in Program.arrayA)
                {
                    /*
                      procura o elemento que foi selecionado para ser o atual
                      e atualiza para marca lo como visitado na classe de Arestas
                    */
                    if (item.Destino.Id == v1.Id && item.Peso == peso)
                    {
                        item.Destino.Cor = 2;
                        //proximo.Cor = 2;
                        break;
                    }
                    else if (item.Origem.Id == v1.Id && item.Peso == peso) 
                    {
                        item.Origem.Cor = 2;
                        //proximo.Cor = 2;
                        break;
                    }
                }
                v1.Cor = 2;//preto -> ja foi visitado
                
                if (proximo != null)
                {
                    Console.WriteLine(v1.Id + " -> folha");
                    this.Count++;
                    if (proximo.Cor != 2 && Count < Program.arrayV.Length)
                    {
                        Console.WriteLine("| -> galho");
                    }
                    this.getAGMPrim(proximo);
                }
                //TODO
                //resolver de forma que quando percorrer todos os vértices, pare de executar a chamada para o metodo.
            }
            else
            {
                return null;
            }
            return new Grafos();
        }

        public Grafos getAGMKruskal(Vertice v1)
        {
            //deve retornar, para um grafo conexo, sua arvore geradora minima(Algoritmo de Kruskal)
            return null;
        }

        public int getCutVertices()
        {
            /*
            * remover por completo um vertice do grafo e verificar se o grafo continuar conexo
            * se o grafo se desconectar qtd++ -> que representa a quantidade de cutVertices do grafo
            * fazer este passo para todos os vertice do grafo e ir incrementando esta variavel caso satisfaça a condição estabelecida.
            */

            Timestamp = 0;
            Count2++;
            resetColor(this.Removed);
            while (this.Removed.Length > Count2)
            {
                //removed.Sort();
                Vertice deleted = this.Removed[0];
                this.Removed[0] = null;
                foreach (var item in this.Removed)
                {
                    if(item != null) item.Adjacente.Remove(deleted); //removendo da lista de adjacencia de todos
                }

                foreach (var item in this.Removed)
                {
                    if (item != null)
                    {
                        if (item.Cor == 0)
                        {
                            visit(item);
                        }
                    }
                }

                foreach (var item in this.Removed)
                {
                    if (item != null)
                    {
                        if (item.Cor == 0) Qtd++;
                    }
                }
                organizeArray(this.Removed);
                this.Removed[this.Removed.Length - 1] = deleted;
                this.getCutVertices();
            }
            return Qtd;
        }
    
        public void organizeArray(Vertice[] array)
        {
            Vertice aux, prox;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == null && i < (array.Length - 1))
                {
                    prox = array[i + 1];
                    array[i] = prox;
                }
            }
        }

        public void visit(Vertice u)
        {
            Timestamp++;
            u.Descoberta = timestamp;
            u.Cor = 1; //cinza
            foreach (var v in u.Adjacente)
            {
                if (v.Cor == 0)
                {
                    v.Pai = u;
                    visit(v);
                }
            }
            u.Cor = 2;
            Timestamp++;
            u.Termino = Timestamp;
        }

        private void resetColor(Vertice[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i].Cor = 0;
                foreach (var item in v[i].Adjacente)
                {
                    item.Cor = 0;
                }
            }
        }
        //para grafos dirigidos
        public int getGrauEntrada(Vertice v1)
        {
            int entra = 0;
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                foreach (var item in Program.arrayV[i].Adjacente)
                {
                    if (item.Id == v1.Id) entra++;
                }
            }
            return entra;
        }

        public int getGrauSaida(Vertice v1)
        {
            return v1.Adjacente.Count; 
        }

        public bool hasCiclo()
        {
            /*
            busca em profundidade
            Algoritmo profundidade recursiva(n)
            Inicio
            Visitar_nó(n)
            Marcar_nó(n)
            Para cada nó m marcado não visitado adjacente a n faça
            Se(nómarcado(m) = “F” ) então
            profundidade recursiva(m)
            Fim se
            Fim para
            Fim
            */
            // 0 = branco
            // 1 = cinza
            // 2 = preto
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                Program.arrayV[i].Cor = 0;
                Program.arrayV[i].Pai = null;
            }
            this.Timestamp = 0;
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (Program.arrayV[i].Cor == 0)
                {
                    visitarVertice(Program.arrayV[i]);
                }
            }
            for (int i = 0; i < Program.arrayV.Length; i++)
            {
                if (Program.arrayV[i].Cor == 1) return true; //possui aresta de retorno
                else if (Program.arrayV[i].Cor == 0) return false;
                //Console.WriteLine(Program.arrayV[i].Cor);
            }
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
            u.Cor = 1; //cinza
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

        public void convertArray(Vertice[] array)
        {
            this.Removed = new Vertice[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Removed[i] = array[i];
            }
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
