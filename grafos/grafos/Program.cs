using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathDirigido = "grafo_dirigido.txt";
            //string pathNaoDirigido = "grafo_nao_dirigido.txt";

            readFile(pathDirigido);
            //readFile(pathNaoDirigido);
            Console.ReadKey();
        }
        public static void readFile(string path)
        {
            StreamReader arq = new StreamReader(path);
            string linha = "";
            string[] separador; 
            while (!arq.EndOfStream)
            {
                linha = arq.ReadLine();
                separador = linha.Split(';');
                Console.Write(separador[0]);
            }
        }
    }
}
