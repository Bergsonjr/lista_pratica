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
        static Vertice[] arrayV;
        static Grafos dirigido = new Grafos();
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
            Console.WriteLine("*----- Adjacência entre vétices -----*");
            try
            {
                Console.Write("Digite o primeiro vértice: ");
                int v1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o segundo vértice: ");
                int v2 = int.Parse(Console.ReadLine());

                Console.WriteLine(dirigido.isAdjacente(new Vertice(v1), new Vertice(v2)));
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

                Console.WriteLine(dirigido.getGrau(new Vertice(v1)));
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

                Console.WriteLine(dirigido.isIsolado(new Vertice(v1)));
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
                   inputDataOfArray();
                   read = true;
                }
                else
                {
                    if (verifyArray(new Vertice(int.Parse(separador[0]))) == -1) 
                    {
                        arrayV[count] = new Vertice(int.Parse(separador[0]));
                        arrayV[count].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                    }
                    else
                    {
                        arrayV[int.Parse(separador[0])].Adjacente.Add(new Vertice(int.Parse(separador[1])));
                    }
                    count++;
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
            for (int i = 0; i < arrayV.Length; i++)
            {
                if (v.Id == arrayV[i].Id){return v.Id;}
            }
            return -1;
        }
    }
}
