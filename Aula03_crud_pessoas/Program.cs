using System;
using System.Collections.Generic;
using Aula03_crud_pessoas;

namespace Aula03_crud_pessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Person person = new Person("Edilson", 27);

            Person person2 = new Person("JR",20);
            Person person3 = new Person("Scheila", 22);
            Person person4 = new Person ("Lucas", 22 ); 
            Person person5 = new Person("bernardo",23);

            List<Person> Persons = new List<Person>();

            Persons.Add(person);
            Persons.Add(person2);
            Persons.Add(person3);
            Persons.Add(person4);
            Persons.Add(person5);

            foreach (var p in Persons)
            {
                Console.WriteLine($"Nome: {p.Nome} - Idade: {p.Idade}");
            }

            Console.WriteLine("Digite 1-Criar Person\n2-Alterar\n0-Sair");

            int operador = Convert.ToInt32(Console.ReadLine());
            while(operador != 0)
            {
                switch (operador)
                {
                    case 1:
                        Criar();
                        break;
                    case 2:
                        Console.WriteLine("chamar função alterar");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Selecione uma das opções.");
                        break;
                }
                Console.WriteLine("Digite 1-Criar Person\n2-Alterar\n0-Sair");
                operador = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void Criar()
        {
            PersonRepository repository = new PersonRepository();
            Person person4 = new Person (  "Fulano", 30);
            repository.Adicionar(person4);
            Console.WriteLine("vamos criar uma Person,\npedir os dados e adicionar na lista");
        }
    }
}
