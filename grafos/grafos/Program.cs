using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace grafos
{
    class Program
    {
        public static List<Aresta> arrayA = new List<Aresta>();
        public static Vertice[] arrayV;
        public static Grafos dirigido = new Grafos();
        public static Grafos naoDirigido = new Grafos();
        
        //files
        const string pathNaoDirigido = "grafo_nao_dirigido.txt";
        const string pathDirigido = "grafo_dirigido.txt";

        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }

        public static void Menu()
        {
            Console.WriteLine("1. para grafo não dirigido");
            Console.WriteLine("2. para grafo dirigido");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    callMethodDirigido();
                    break;
                case 2:
                    callMethodNotDirigido();
                    break;
                default:
                    Console.Clear();
                    Console.Write("Essa opção não existe!");
                    break;
            }
        }

        public static void callMethodDirigido()
        {
            try
            {
                readFileGrafo(pathNaoDirigido);
                /*Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isAdjacente();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                getGrau();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isIsolado();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isPendente();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isRegular();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isNulo();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isCompleto();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();*/
                isConexo();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                /*isEuleriano();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                isUnicursal();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                getComplementar();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                getAGMPrim();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
                getAGMKruskal();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();*/
                getCutVertices();
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }        
        }

        public static void callMethodNotDirigido()
        {
            readFileDigrafo(pathDirigido);
            getGrauEntrada();
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadKey();
            getGrauSaida();
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadKey();
            hasCiclo();
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadKey();  
        }

        //1 - A
        public static void isAdjacente()
        {
            Console.Clear();
            Console.WriteLine("*----- Adjacência entre vértices -----*");
            try
            {
                Console.Write("Digite o primeiro vértice: ");
                int v1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o segundo vértice: ");
                int v2 = int.Parse(Console.ReadLine());

                if((dirigido.isAdjacente(findVertice(v1), findVertice(v2)))){
                    Console.WriteLine("Os vértices " + v1 + " e " + v2 + " são adjacentes.");
                }
                else
                {
                    Console.WriteLine("Os vértices " + v1 + " e " + v2 + " não são adjacentes.");
                }
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        //1 - B
        public static void getGrau()
        {
            Console.Clear();
            Console.WriteLine("*----- Grau do vértice -----*");
            try
            {
                Console.Write("Digite o vértice: ");
                int v1 = int.Parse(Console.ReadLine());

                Console.WriteLine("O grau do vértice é " + dirigido.getGrau(findVertice(v1)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //1 - C
        public static void isIsolado()
        {
            Console.Clear();
            Console.WriteLine("*----- Vértice isolado -----*");
            try
            {
                Console.Write("Digite o vértice: ");
                int v1 = int.Parse(Console.ReadLine());

                if (dirigido.isIsolado(findVertice(v1)))
                {
                    Console.WriteLine("Os vértice " + v1 + " é isolado.");
                }
                else
                {
                    Console.WriteLine("Os vértice " + v1 + " não é isolado.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 D
        public static void isPendente()
        {
            Console.Clear();
            Console.WriteLine("*----- Vértice pendente -----*");
            try
            {
                Console.Write("Digite o vértice: ");
                int v1 = int.Parse(Console.ReadLine());

                if (dirigido.isPendente(findVertice(v1)))
                {
                    Console.WriteLine("O vértice " + v1 + " é pendente");
                }
                else
                {
                    Console.WriteLine("O vértice " + v1 + " não é pendente");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 E
        public static void isRegular()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo regular -----*");
            try
            {
                if (dirigido.isRegular())
                {
                    Console.WriteLine("O grafo é regular. ");
                }
                else
                {
                    Console.WriteLine("O grafo não é regular. ");
                }
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 F
        public static void isNulo()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo nulo -----*");
            try
            {
                if (dirigido.isNulo())
                {
                    Console.WriteLine("O grafo é nulo. ");
                }
                else
                {
                    Console.WriteLine("O grafo não é nulo. ");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 G
        public static void isCompleto()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo completo -----*");
            try
            {
                if (dirigido.isCompleto())
                {
                    Console.WriteLine("O grafo é completo.");
                }
                else
                {
                    Console.WriteLine("O grafo não é completo.");
                }  
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 H
        public static void isConexo()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo conexo -----*");
            try
            {
                if (dirigido.isConexo())
                {
                    Console.WriteLine("O grafo é conexo. ");
                }
                else
                {
                    Console.WriteLine("O grafo não é conexo. ");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 I
        public static void isEuleriano()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo euleriano -----*");
            try
            {
                if (dirigido.isEuleriano())
                {
                    Console.WriteLine("O grafo é euleriano.");
                }
                else
                {
                    Console.WriteLine("O grafo não é euleriano.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 J
        public static void isUnicursal()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo unicursal -----*");
            try
            {
                if (dirigido.isUnicursal())
                {
                    Console.WriteLine("O grafo é unicursal.");
                }
                else
                {
                    Console.WriteLine("O grafo não é unicursal.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 K
        public static void getComplementar()
        {
            Console.Clear();
            Console.WriteLine("*----- Grafo complementar -----*");
            try
            {
                if (dirigido.getComplementar() == null)
                {
                    Console.WriteLine("Não existe complementar para este grafo.");
                }
                else
                {
                    Console.WriteLine(dirigido.getComplementar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 L
        public static void getAGMPrim()
        {
            Console.Clear();
            Console.WriteLine("*----- Árvore geradora minima (Prim) -----*");
            try
            {
                Console.WriteLine("Digite o vértice inicial: ");
                int v1 = int.Parse(Console.ReadLine());

                if(dirigido.getAGMPrim(findVertice(v1)) == null && !dirigido.Conexo)
                {
                    Console.WriteLine("O grafo não é conexo, portanto não é possível retornar uma árvore geradora mínima");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 M
        public static void getAGMKruskal()
        {
            Console.Clear();
            Console.WriteLine("*----- Árvore geradora minima (Kruskal) -----*");
            try
            {
                Console.WriteLine("Digite o vértice inicial: ");
                int v1 = int.Parse(Console.ReadLine());

                if (dirigido.getAGMKruskal(findVertice(v1)) == null)
                {
                    Console.WriteLine("O grafo não é conexo, portanto não possível retornar uma árvore geradora mínima");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //1 N
        public static void getCutVertices()
        {
            Console.Clear();
            Console.WriteLine("*----- Cut vértices -----*");
            try
            {
                dirigido.convertArray(arrayV);
                Console.WriteLine("O número de cut-vértices é " + dirigido.getCutVertices());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //2 A
        public static void getGrauEntrada()
        {
            Console.Clear();
            Console.WriteLine("*----- Grau de entrada -----*");
            try
            {
                Console.WriteLine("Digite o vértice: ");
                int v1 = int.Parse(Console.ReadLine());

                Console.WriteLine("O grau de entrada é " + naoDirigido.getGrauEntrada(findVertice(v1)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //2 B
        public static void getGrauSaida()
        {
            Console.Clear();
            Console.WriteLine("*----- Grau de saída -----*");
            try
            {
                Console.WriteLine("Digite o vértice: ");
                int v1 = int.Parse(Console.ReadLine());

                Console.WriteLine("O grau de saída é " + naoDirigido.getGrauSaida(findVertice(v1)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //2 C
        public static void hasCiclo()
        {
            Console.Clear();
            Console.WriteLine("*----- Possui ciclo -----*");
            try
            {
                if (naoDirigido.hasCiclo())
                {
                    Console.WriteLine("O grafo possui ciclo.");
                }
                else
                {
                    Console.WriteLine("O grafo não possui ciclo.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void readFileGrafo(string path)
        {
            StreamReader arq = new StreamReader(path);
            int count = 0;
            string linha = "";
            string[] separador;
            linha = arq.ReadLine();
            bool read = false;
            while (linha != null)
            {
                separador = linha.Split(';');
                if (!read)
                {
                    arrayV = new Vertice[int.Parse(separador[0])];
                    read = true;
                }
                else
                {
                    int pos = verifyArray(new Vertice(int.Parse(separador[0])));
                    if (pos == -1)
                    {
                        //se nao existir o vertice
                        arrayV[count] = new Vertice(int.Parse(separador[0]));
                        arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                        Aresta a = new Aresta(new Vertice(int.Parse(separador[0])), new Vertice(int.Parse(separador[1])), int.Parse(separador[2]));
                        arrayA.Add(a);
                        count++;
                        pos = verifyArray(new Vertice(int.Parse(separador[1])));
                        if (pos == -1)
                        {
                            arrayV[count] = new Vertice(int.Parse(separador[1]));
                            arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                            //a = new Aresta(new Vertice(int.Parse(separador[1])), new Vertice(int.Parse(separador[0])), int.Parse(separador[2]));
                            //arrayA.Add(a);
                            count++;
                        }
                        else
                        {
                            arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                            a = new Aresta(new Vertice(int.Parse(separador[0])), new Vertice(int.Parse(separador[1])), int.Parse(separador[2]));
                            arrayA.Add(a);
                        }
                    }
                    else
                    {
                        //se o vertice ja existir no array
                        arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                        Aresta a = new Aresta(new Vertice(int.Parse(separador[0])), new Vertice(int.Parse(separador[1])), int.Parse(separador[2]));
                        arrayA.Add(a);
                        pos = verifyArray(new Vertice(int.Parse(separador[1])));
                        if (pos == -1)
                        {
                            arrayV[count] = new Vertice(int.Parse(separador[1]));
                            arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                            count++;
                        }
                        else
                        {
                            arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                        }
                    }
                }
                linha = arq.ReadLine();
            }
        }

            public static void readFileDigrafo(string path)
            {
                StreamReader arq = new StreamReader(path);
                int count = 0;
                string linha = "";
                string[] separador;
                linha = arq.ReadLine();
                bool read = false;
            while (linha != null)
            {
                separador = linha.Split(';');
                if (!read)
                {
                    arrayV = new Vertice[int.Parse(separador[0])];
                    read = true;
                }
                else
                {
                    int pos = 0;
                    if (int.Parse(separador[3]) > 0)
                    {
                        pos = verifyArray(new Vertice(int.Parse(separador[0])));
                        if (pos == -1)
                        {
                            arrayV[count] = new Vertice(int.Parse(separador[0]));
                            arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                            count++;
                        }
                        else
                        {
                            arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                        }
                    }
                    else
                    {
                        pos = verifyArray(new Vertice(int.Parse(separador[1])));
                        if (pos == -1)
                        {
                            arrayV[count] = new Vertice(int.Parse(separador[1]));
                            arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                            count++;
                        }
                        else
                        {
                            arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[0])));
                        }
                    }
                }
                linha = arq.ReadLine();
            }
                /*for (int i = 0; i < arrayV.Length; i++)
                {
                    Console.WriteLine(arrayV[i].Id + " vertice array \n");
                    foreach (var item in arrayV[i].Adjacente)
                    {
                        Console.WriteLine(item.Id + " adjacente");
                    }
                }
                Console.ReadKey();*/
            }

        public static void inputDataOfArray()
        {
            for (int i = 0; i < arrayV.Length; i++)
            {
                arrayV[i] = new Vertice(i);
            }
        }

        public static int verifyArray(Vertice v)
        {
            int count = 0;
            foreach (var vertice in arrayV)
            {
                if (vertice != null) { 
                    if (v.Id == vertice.Id) { return count; }
                }
                count++;
            }
            return -1;
        }

        public static Vertice findVertice(int id)
        {
            for (int i = 0; i < arrayV.Length; i++)
            {
                if (arrayV[i] != null)
                {
                    if (arrayV[i].Id == id) return arrayV[i];
                }
            }

            for (int i = 0; i < arrayV.Length; i++)
            {
                foreach (var item in arrayV[i].Adjacente)
                {
                    if (item.Id == id) return item;
                }
            }
            return null;
        }

        public static List<Vertice> normalizeV()
        {
            List<Vertice> vTemp = new List<Vertice>();
            List<Vertice> vFinal = new List<Vertice>();

            for (int i = 0; i < arrayV.Length; i++)
            {
                foreach (var item in arrayV[i].Adjacente)
                {
                    vTemp.Add(item);
                    //vTemp.
                    //TODO
                }
            }
            return vFinal;
        }
    }
}
