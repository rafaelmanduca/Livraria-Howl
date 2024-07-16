using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Venda
    {
        public int IdVenda { get; set; }
        public int IdFuncionario { get; set; }
        public int IdCliente { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        private static List<Venda> vendas = new List<Venda>();
        private static int contadorId = 1;

        public Venda(int idFuncionario, int idCliente, int idLivro, decimal valorTotal)
        {
            IdVenda = contadorId++;
            IdFuncionario = idFuncionario;
            IdCliente = idCliente;
            IdLivro = idLivro;
            DataVenda = DateTime.Now;
            ValorTotal = valorTotal;

            vendas.Add(this);
        }

        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }

        public static void ListarVendas()
        {
            if (vendas.Count == 0)
            {
                
                Console.WriteLine("Nenhuma venda registrada.");
            }
            else
            {
                foreach (var venda in vendas)
                {
                   Console.WriteLine(venda);
                }
            }
        }

        public static void CadastrarVenda()
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine("Cadastrar Venda");

            Console.Write("ID do Funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("ID do Cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            Console.Write("ID do Livro: ");
            int idLivro = int.Parse(Console.ReadLine());

            Console.Write("Valor Total: ");
            decimal valorTotal = decimal.Parse(Console.ReadLine());

            new Venda(idFuncionario, idCliente, idLivro, valorTotal);
            Console.WriteLine("Venda cadastrada com sucesso!");
        }

        public static void SubmenuVendas()
        {
            int opcaoSubmenu = 0;

            while (opcaoSubmenu != 3)
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine("Submenu Vendas");
                Console.WriteLine("1. Cadastrar Venda");
                Console.WriteLine("2. Listar Vendas");
                Console.WriteLine("3. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
                {
                    if (opcaoSubmenu == 1)
                    {
                        CadastrarVenda();
                    }
                    else if (opcaoSubmenu == 2)
                    {
                        Console.Clear();
                        ExibirCabecalho();
                        Console.WriteLine("Listagem de Vendas");
                        ListarVendas();
                    }
                    else if (opcaoSubmenu == 3)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                        return;

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
            return $"ID Venda: {IdVenda}, ID Funcionário: {IdFuncionario}, ID Cliente: {IdCliente}, ID Livro: {IdLivro}, Data da Venda: {DataVenda}, Valor Total: {ValorTotal:C}";
        }
    }

}

