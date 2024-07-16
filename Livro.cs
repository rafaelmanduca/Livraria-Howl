using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Livro
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int Preco { get; set; }


        public Livro(string titulo, string autor, string editora, int preco)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
        }

        public void ExibirLivros()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Editora: {Editora}");
            Console.WriteLine($"Preco: {Preco}");
        }

        public void CadastrarLivro()
        { Console.WriteLine($)}



    }
}
