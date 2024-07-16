using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int Preco { get; set; }

        private static List<Livro> livros = new List<Livro>();
        private static int contadorId = 1;
        public Livro(string titulo, string autor, string editora, int preco)
        {
            IdLivro = contadorId++;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
        }

        public void ExibirLivros()
        {
            Console.WriteLine($"IdLivro: {IdLivro}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Editora: {Editora}");
            Console.WriteLine($"Preco: {Preco}");
        }


        public static void CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("Adicionar Livro");

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor(a): ");
            string autor = Console.ReadLine();

            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Console.Write("Preco: ");
            int preco = int.Parse(Console.ReadLine());

            new Livro(titulo, autor, editora, preco);
            Console.WriteLine($"O livro '{titulo}' adicionado com sucesso!");
        }

        public static void ListarLivro()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado ainda.");
            }
            else
            {
                foreach (var livro in livros)
                {
                    Console.WriteLine(livros);
                }
            }
        }

        public static void SubmenuLivros()
        {
            int opcaoSubmenu = 0;

            while (opcaoSubmenu != 3)
            {
                Console.Clear();
                Console.WriteLine("Submenu Livros");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
                {
                    if (opcaoSubmenu == 1)
                    {
                        CadastrarLivro();
                    }
                    else if (opcaoSubmenu == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Listagem de Livros");
                        ListarLivro();
                    }
                    else if (opcaoSubmenu == 3)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public override string ToString()
        {
            return $"ID: {IdLivro}, Título: {Titulo}, Autor: {Autor}, Editora: {Editora}, Preço: {Preco}";
        }


    }
}
