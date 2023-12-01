﻿using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static void Main()
    {
        Academia academia = new Academia();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu Principal ====");
            Console.WriteLine("\n1. Gerenciar Treinadores");
            Console.WriteLine("2. Gerenciar Clientes");
            Console.WriteLine("3. Gerar Relatórios");
            Console.WriteLine("0. Sair");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    GerenciarTreinadores(academia);
                    break;
                case "2":
                    GerenciarClientes(academia);
                    break;
                case "3":
                    GerarRelatorios(academia);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadLine();
                    break;
            }
        }
    }

static void GerenciarTreinadores(Academia academia)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu Treinadores ====");
            Console.WriteLine("\n1. Adicionar Treinador");
            Console.WriteLine("2. Remover Treinador");
            Console.WriteLine("3. Listar Treinadores");
            Console.WriteLine("0. Voltar");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarTreinador(academia);
                    break;
                case "2":
                    RemoverTreinador(academia);
                    break;
                case "3":
                    ListarTreinadores(academia);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadLine();
                    break;
            }
        }
    }


}