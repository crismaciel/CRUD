using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        
        List<Pessoa> listPessoa = new List<Pessoa>();

        public static void ExibirLista()
        {
            foreach (var item in listPessoa)
            {
                
            }
        }

        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();

            
            var input = 0;

            do
            {
            Console.WriteLine("1 - Add Pessoa + Idade");
            Console.WriteLine("2 - Mostrar lista");
            Console.WriteLine("9 - Sair");

            switch(input)
            {
                case 1:
                    Console.WriteLine("Digite o nome");
                    pessoa.Nome = Console.ReadLine();

                    Console.WriteLine("Digite a idade");
                    pessoa.Idade = Convert.ToInt32(Console.ReadLine());

                    listPessoa.Add(pessoa);

                break;

                case 2:
                    ExibirLista();
                break;
            }


            } while (input != 9);

        }

    }
}
