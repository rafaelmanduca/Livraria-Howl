using System;
using System.Collections.Generic;

public class Funcionario
{
    public int IdFuncionario { get; set; }
    public string Nome { get; set; }
    public int IdCargo { get; set; }
    public DateTime DataAdmissao { get; set; }
    public decimal Salario { get; set; }
    public string CarteiraDeTrabalho { get; set; }
    public bool Registrado { get; set; }

    private static List<Funcionario> funcionarios = new List<Funcionario>();
    private static int contadorId = 1;

    public Funcionario(string nome, int idCargo, DateTime dataAdmissao, decimal salario, string carteiraDeTrabalho, bool registrado = true)
    {
        IdFuncionario = contadorId++;
        Nome = nome;
        IdCargo = idCargo;
        DataAdmissao = dataAdmissao;
        Salario = salario;
        CarteiraDeTrabalho = carteiraDeTrabalho;
        Registrado = registrado;

        funcionarios.Add(this);
    }

    public static void CadastrarFuncionario()
    {
        Console.Clear();
        Console.WriteLine("Adicionar Funcionário");

        string nome = string.Empty;
        bool nomeValido = false;

        while (!nomeValido)
        {
            try
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(nome))
                {
                    throw new Exception("Nome não pode estar vazio.");
                }
                else if (ContemNumeros(nome))
                {
                    throw new Exception("Nome não pode conter números.");
                }
                else
                {
                    nomeValido = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} Digite novamente.");
            }
        }

        int idCargo = 0;
        bool idCargoValido = false;
        while (!idCargoValido)
        {
            try
            {
                Console.Write("ID do Cargo: ");
                idCargo = int.Parse(Console.ReadLine());
                idCargoValido = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("ID do Cargo inválido. Digite novamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} Digite novamente.");
            }
        }

        DateTime dataAdmissao = DateTime.MinValue;
        bool dataValida = false;
        while (!dataValida)
        {
            try
            {
                Console.Write("Data de Admissão (DDMMYYYY): ");
                string input = Console.ReadLine().Trim();

                if (input.Length != 8 || !input.All(char.IsDigit))
                {
                    throw new Exception("Formato de data inválido. Use apenas números (DDMMYYYY).");
                }

                int dia = int.Parse(input.Substring(0, 2));
                int mes = int.Parse(input.Substring(2, 2));
                int ano = int.Parse(input.Substring(4, 4));

                dataAdmissao = new DateTime(ano, mes, dia);
                dataValida = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de data inválido. Digite novamente (DDMMYYYY).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} Digite novamente.");
            }
        }

        decimal salario = 0;
        bool salarioValido = false;
        while (!salarioValido)
        {
            try
            {
                Console.Write("Salário: ");
                salario = decimal.Parse(Console.ReadLine());
                salarioValido = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Salário inválido. Digite novamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} Digite novamente.");
            }
        }

        string carteiraDeTrabalho = string.Empty;
        bool carteiraDeTrabalhoValida = false;
        while (!carteiraDeTrabalhoValida)
        {
            try
            {
                Console.Write("Carteira de Trabalho (apenas números): ");
                carteiraDeTrabalho = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(carteiraDeTrabalho))
                {
                    throw new Exception("Carteira de Trabalho não pode estar vazia.");
                }

                if (!carteiraDeTrabalho.All(char.IsDigit))
                {
                    throw new Exception("Carteira de Trabalho deve conter apenas números.");
                }

                carteiraDeTrabalhoValida = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} Digite novamente.");
            }
        }

        Console.WriteLine($"Funcionário '{nome}' adicionado com sucesso!");
        
    }

    private static bool ContemNumeros(string texto)
    {
        foreach (char c in texto)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }



    public static void ListarFuncionarios()
    {
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        else
        {
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine(funcionario);
            }
        }
    }



    public static void SubmenuFuncionarios()
    {
        int opcaoSubmenu = 0;

        while (opcaoSubmenu != 3)
        {
            Console.Clear();
            Console.WriteLine("Submenu Funcionários");
            Console.WriteLine("1. Adicionar Funcionário");
            Console.WriteLine("2. Listar Funcionários");
            Console.WriteLine("3. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
            {
                if (opcaoSubmenu == 1)
                {
                    CadastrarFuncionario();
                }
                else if (opcaoSubmenu == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Listagem de Funcionários");
                    ListarFuncionarios();
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
        return $"ID: {IdFuncionario}, Nome: {Nome}, Cargo ID: {IdCargo}, Data de Admissão: {DataAdmissao.ToShortDateString()}, Salário: {Salario:C}, CTPS: {CarteiraDeTrabalho}, Registrado: {Registrado}";
    }
}
