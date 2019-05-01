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
        static List<Aresta> arrayA = new List<Aresta>();
        public static Vertice[] arrayV;
        static Grafos dirigido = new Grafos();
        static Grafos naoDirigido = new Grafos();
        //files
        const string pathNaoDirigido = "grafo_nao_dirigido.txt";
        const string pathDirigido = "grafo dirigido.txt";

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
                Console.WriteLine("Pressione ENTER para continuar");
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }        
        }

        public static void callMethodNotDirigido()
        {
            //readFileDigrafo(pathDirigido);
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

                Console.WriteLine(dirigido.isAdjacente(findVertice(v1), findVertice(v2)));
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

                Console.WriteLine(dirigido.getGrau(findVertice(v1)));
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

                Console.WriteLine(dirigido.isIsolado(findVertice(v1)));
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

                Console.WriteLine(dirigido.isPendente(findVertice(v1)));
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
                Console.WriteLine(dirigido.isRegular());
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
                Console.WriteLine(dirigido.isNulo());
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
                Console.WriteLine(dirigido.isCompleto());
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
                Console.WriteLine(dirigido.isConexo());
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
                Console.WriteLine(dirigido.isEuleriano());
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
                Console.WriteLine(dirigido.isUnicursal());
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
                Console.WriteLine(dirigido.getComplementar());
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

                Console.WriteLine(dirigido.getAGMPrim(findVertice(v1)));
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

                Console.WriteLine(dirigido.getAGMKruskal(findVertice(v1)));
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
                Console.WriteLine(dirigido.getCutVertices());
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

                Console.WriteLine(naoDirigido.getGrauEntrada(findVertice(v1)));
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

                Console.WriteLine(naoDirigido.getGrauSaida(findVertice(v1)));
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
                Console.WriteLine(naoDirigido.hasCiclo());
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
                        arrayV[count] = new Vertice(int.Parse(separador[0]));
                        arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                        count++;
                    }
                    else
                    { 
                        arrayV[pos].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                    } 
                }
                linha = arq.ReadLine();
            }
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
    }
}
