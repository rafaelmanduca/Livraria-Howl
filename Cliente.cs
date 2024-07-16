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
            
            

     }     
    
}
