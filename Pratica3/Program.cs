using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiposAbstratosDeDados;

namespace Pratica3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista l = new Lista();

            int c;
            string nome;
            int option = 0;

            while (option == 0)
            {
                Console.WriteLine(
                    "-------------------------------\n" +
                    "Digite: 1 - Inserir \n" +
                    "Digite: 2 - Pesquisar\n" +
                    "Digite: 3 - Imprimir Lista\n" +
                    "Digite: 4 - Editar\n" +
                    "Digite: 5 - Sair\n" +
                    "Digite: 6 na chave - Para mudar opção\n" +
                    "-------------------------------"
                    );

                option = LerInt("Opção: ");
                Console.WriteLine();

                while (option == 1)
                {
                    Console.Write("Digite um nome: ");
                    nome = Console.ReadLine();
                    c = LerInt("Digite um número como chave: ");

                    if (c == 6)
                    {
                        option = 0;
                    }
                    NoLista n = l.Pesquisar(c);
                    if (n == null)
                    {
                        if (c == 6)
                        {
                            option = 0;
                        }
                        else
                        {
                            l.Inserir(new NoLista(c, nome));
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Valor já existente");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                while (option == 2)
                {
                    c = LerInt("Digite a chave para pesquisar (ou 6 para cancelar): ");
                    Console.WriteLine();
                    if (c == 6)
                    {
                        option = 0;
                    }
                    else
                    {
                        NoLista n = l.Pesquisar(c);
                        if (n == null)
                            Console.WriteLine("Valor não encontrado!");
                    }
                }

                while (option == 3)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Lista:");
                    l.Imprimir();
                    option = 0;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine();
                }

                // Nova opção 4 - Editar
                while (option == 4)
                {
                    c = LerInt("Digite a chave a ser editada (ou 6 para cancelar): ");
                    Console.WriteLine();
                    if (c == 6)
                    {
                        option = 0;
                    }
                    else
                    {
                        Console.Write("Digite o novo nome: ");
                        string novoNome = Console.ReadLine();
                        l.Editar(c, novoNome);
                        option = 0;
                    }
                }

                while (option == 5)
                {
                    Environment.Exit(0);
                }
                option = 0;
            }
        }

        // Lê um inteiro do Console, exibindo mensagem de erro e repetindo até entrada válida.
        private static int LerInt(string prompt)
        {
            int valor;
            while (true)
            {
                Console.Write(prompt);
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out valor))
                    return valor;
                Console.WriteLine("Entrada inválida: por favor digite um número inteiro.");
            }
        }
    }
}
