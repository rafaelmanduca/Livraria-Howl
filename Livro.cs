using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Livro
    {

        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }

        private static List<Livro> livros = new List<Livro>();
        private static int contadorId = 1;
        public Livro(string titulo, string autor, string editora, int preco, int quantidade)
        {
            IdLivro = contadorId++;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
            Quantidade = quantidade;

            livros.Add(this);
        }
        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }
        public void ExibirLivros()
        {
            Console.WriteLine($"IdLivro: {IdLivro}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Editora: {Editora}");
            Console.WriteLine($"Preco: {Preco}");
            Console.WriteLine($"Quantidade: {Quantidade}");
        }

       
        public static void CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("Adicionar Livro");

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Livro livroExistente = livros
                .FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (livroExistente != null)
            {
                Console.WriteLine("Já tem um livro cadastrado com esse nome!");

                Console.WriteLine("Digite quantos livros você quer adicionar:");
                int quantidadeParaAdicionar;

                while (!int.TryParse(Console.ReadLine(), out quantidadeParaAdicionar) || quantidadeParaAdicionar <= 0)
                {
                    Console.WriteLine("Por favor, digite um número válido maior que 0.");
                }

                AtualizarQuantidadeLivro(livroExistente, quantidadeParaAdicionar);

                Console.WriteLine($"A quantidade do livro '{livroExistente.Titulo}' foi atualizada para {livroExistente.Quantidade}.");
            }
            else
            {
                Console.WriteLine("Esse livro não está cadastrado. Vamos adicioná-lo!");

                Console.Write("Autor(a): ");
                string autor = Console.ReadLine();

                Console.Write("Editora: ");
                string editora = Console.ReadLine();

                Console.Write("Preço: ");
                int preco;

                while (!int.TryParse(Console.ReadLine(), out preco) || preco <= 0)
                {
                    Console.WriteLine("Por favor, digite um valor válido para o preço maior que 0.");
                }

                Console.Write("Quantidade: ");
                int quantidade;

                while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Por favor, digite um número válido para a quantidade maior que 0.");
                }

                livros.Add(new Livro(titulo, autor, editora, preco, quantidade));

                Console.WriteLine($"O livro '{titulo}' foi adicionado com sucesso!");
            }
        }
         
        public static void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado ainda.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Listagem de Livros");
                ExibirCabecalho();
                foreach (var livro in livros.Distinct().ToList())

                {
                    livro.ExibirLivros(); // Chama o método ExibirLivros para exibir as informações de cada livro
                }
            }
        }


        public static void AtualizarQuantidadeLivro(Livro livro, int quantidadeParaAdicionar)
        {
            livro.Quantidade += quantidadeParaAdicionar;
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
                        ListarLivros();
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
            return $"ID: {IdLivro}, Título: {Titulo}, Autor: {Autor}, Editora: {Editora}, Preço: {Preco}, Quantidade: {Quantidade}";
        }
    }
}  