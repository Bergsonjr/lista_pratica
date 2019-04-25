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
        static Aresta[] arrayA;
        static Vertice[] arrayV;
        static void Main(string[] args)
        {
            string pathNaoDirigido = "grafo_nao_dirigido.txt";
            string pathDirigido = "grafo dirigido.txt";
            readFileGrafo(pathNaoDirigido);
            Grafos dirigido = new Grafos();

            isAdjacente();
            //readFileDigrafo(pathDirigido);
            Console.ReadKey();
        }

        public static void isAdjacente()
        {
            try
            {
                Console.Write("Digite o primeiro vértice: ");
                int v1 = int.Parse(Console.ReadLine());
                Console.Write("Digite o segundo vértice: ");
                int v2 = int.Parse(Console.ReadLine());


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

                    arrayA[count] = new Aresta(v1, v2, int.Parse(separador[2]));
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
