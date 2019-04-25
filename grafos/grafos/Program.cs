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
            Console.Write("1. para grafo não dirigido");
            Console.Write("2. para grafo dirigido");
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
            readFileGrafo(pathNaoDirigido);
            isAdjacente();
        }
        public static void callMethodNotDirigido()
        {
            //readFileDigrafo(pathDirigido);
        }
        public static void isAdjacente()
        {
            try
            {
                Console.Write("Digite o primeiro vértice: ");
                int v1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o segundo vértice: ");
                int v2 = int.Parse(Console.ReadLine());

                Console.WriteLine(dirigido.isAdjacente(new Vertice(v1), new Vertice(v2), arrayA));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                    Vertice v1 = new Vertice(int.Parse(separador[0]));
                    Vertice v2 = new Vertice(int.Parse(separador[1]));

                    arrayA.Add(new Aresta(v1, v2, int.Parse(separador[2])));
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
    }
}
