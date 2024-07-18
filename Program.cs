namespace ConsoleApp1
{
    internal class Program
    {
        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }
    
    static void Main(string[] args)
        {
            
            
            
            int opcao = 0;

            while (opcao != 4)
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine("Bem vindo a livraria Howl!");
                Console.WriteLine("Menu Principal");
                Console.WriteLine("1. Livros");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Funcionarios");
                Console.WriteLine("4. Vendas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                // Lê a entrada do usuário
                string entrada = Console.ReadLine();

                // Tenta converter a entrada para um número inteiro
                if (int.TryParse(entrada, out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Livro.SubmenuLivros();
                            break;
                        case 2:
                            //Função Clientes
                            break;
                        case 3:
                            Funcionario.SubmenuFuncionarios();
                            break;
                        case 4:
                            Venda.SubmenuVendas();
                            break;
                        case 5:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }

                // Espera o usuário pressionar uma tecla para continuar
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();





            }
    }
}
}
