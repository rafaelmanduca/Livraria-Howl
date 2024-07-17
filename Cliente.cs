using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

     public class Cliente
     {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public int Telefone { get; set; }
            public string Endereço { get; set; }
            public string CPF { get; set; }

            public Cliente() { }

            public Cliente(int id, string nome, string email, int telefone, string endereço, string cpf)
            {
                Id = id;
                Nome = nome;
                Email = email;
                Telefone = telefone;
                Endereço = endereço;
                CPF = cpf;
            }
            public void ExibirCliente()
            {
                Console.WriteLine($"id: {Id}");
                Console.WriteLine($"nome: {Nome}");
                Console.WriteLine($"email: {Email}");
                Console.WriteLine($"telefone:{Telefone}");
                Console.WriteLine($"endereço: {Endereço}");
                Console.WriteLine($"cpf: {CPF}");
            }

     public class ProgramaClientes
     {
        public static List<Cliente> clientes = new List<Cliente>();

        public static void CadastrarCliente()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Adicionar Cliente");

                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    throw new FormatException("Id deve ser um número inteiro.");
                }

                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                Console.Write("Email: ");
                string email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentException("Email não pode ser vazio.");
                }

                Console.Write("Telefone: ");
                if (!int.TryParse(Console.ReadLine(), out int telefone))
                {
                    throw new FormatException("Telefone deve ser um número inteiro.");
                }

                Console.Write("Endereço: ");
                string endereço = Console.ReadLine();
                if (string.IsNullOrEmpty(endereço))
                {
                    throw new ArgumentException("Endereço não pode ser vazio.");
                }

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();
                if (string.IsNullOrEmpty(cpf))
                {
                    throw new ArgumentException("CPF não pode ser vazio.");
                }

                Cliente novoCliente = new Cliente(id, nome, email, telefone, endereço, cpf);
                clientes.Add(novoCliente);
                Console.WriteLine($"O cliente '{nome}' foi cadastrado com sucesso!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formatação: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro de argumento: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public static void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda.");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    cliente.ExibirCliente();
                    Console.WriteLine("-------------------------");
                }
            }
        }

        public static void SubmenuClientes()
        {
            int opcaoSubmenu = 0;

            while (opcaoSubmenu != 3)
            {
                Console.Clear();
                Console.WriteLine("Submenu Clientes");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
                {
                    if (opcaoSubmenu == 1)
                    {
                        CadastrarCliente();
                    }
                    else if (opcaoSubmenu == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Listagem de Clientes");
                        ListarClientes();
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
     }


}     
    



