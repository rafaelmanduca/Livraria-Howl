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

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        
        Console.Clear();
        Console.WriteLine("1 - Gerente ; 2 - Atendente ; 3 - Estoquista");
        Console.Write("ID do Cargo: ");
        int idCargo = int.Parse(Console.ReadLine());

        Console.Write("Data de Admissão (yyyy-mm-dd): ");
        DateTime dataAdmissao = DateTime.Parse(Console.ReadLine());

        Console.Write("Salário: ");
        decimal salario = decimal.Parse(Console.ReadLine());

        Console.Write("Carteira de Trabalho: ");
        string carteiraDeTrabalho = Console.ReadLine();

        new Funcionario(nome, idCargo, dataAdmissao, salario, carteiraDeTrabalho);
        Console.WriteLine($"Funcionário '{nome}' adicionado com sucesso!");
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
