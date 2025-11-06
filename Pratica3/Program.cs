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
                    "Digite: 4 na chave para mudar opção\n" +
                    "Digite: 5 - Sair\n" +
                    "-------------------------------"
                    );

                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                while (option == 1)
                {
                    Console.Write("Digite um nome: ");
                    nome = Console.ReadLine();
                    Console.Write("Digite um número como chave: ");
                    c = Convert.ToInt32(Console.ReadLine());

                        if (c == 4)
                        {
                            option = 0;
                        }
                        NoLista n = l.Pesquisar(c);
                        if (n == null)
                        {
                            if (c == 4)
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
                        
                        c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (c == 4)
                    {
                        option = 0;
                    }
                    else
                    {
                        NoLista n = l.Pesquisar(c);
                        if (n == null)
                            Console.WriteLine("Valor não encontrado!");
                        else
                            Console.WriteLine("Achou: " + n.chave);
                        Console.WriteLine();
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
                    while (option == 5)
                    {
                        Environment.Exit(0);
                    }
                option = 0;
                }
            }
        }
    }
