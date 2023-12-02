using System;
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
static void AdicionarTreinador(Academia academia)
    {
        Console.WriteLine("Informe o nome do treinador:");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe a data de nascimento do treinador (dd-MM-yyyy):");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

        Console.WriteLine("Informe o CPF do treinador:");
        string cpf = Console.ReadLine();

        Console.WriteLine("Informe o CREF do treinador:");
        string cref = Console.ReadLine();

        Treinador treinador = new Treinador(nome, dataNascimento, cpf, cref);
        academia.AdicionarTreinador(treinador);

        Console.WriteLine("Treinador adicionado com sucesso!");
        Console.ReadLine();
    }

    static void RemoverTreinador(Academia academia)
    {
        Console.WriteLine("Informe o CPF do treinador a ser removido:");
        string cpf = Console.ReadLine();

        Treinador treinador = academia.GetTreinadorPorCPF(cpf);

        if (treinador != null)
        {
            academia.RemoverTreinador(treinador);
            Console.WriteLine("Treinador removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Treinador não encontrado.");
        }

        Console.ReadLine();
    }
static void ListarTreinadores(Academia academia)
    {
        List<Treinador> treinadores = academia.ListarTreinadores();

        if (treinadores.Count > 0)
        {
            foreach (var treinador in treinadores)
            {
                Console.WriteLine($"Nome: {treinador.Nome}, CREF: {treinador.CREF}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum treinador cadastrado.");
        }

        Console.ReadLine();
    }

    static void GerenciarClientes(Academia academia)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Menu Clientes ====");
            Console.WriteLine("\n1. Adicionar Cliente");
            Console.WriteLine("2. Remover Cliente");
            Console.WriteLine("3. Listar Clientes");
            Console.WriteLine("0. Voltar");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarCliente(academia);
                    break;
                case "2":
                    RemoverCliente(academia);
                    break;
                case "3":
                    ListarClientes(academia);
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
static void AdicionarCliente(Academia academia)
    {
        Console.WriteLine("Informe o nome do cliente:");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe a data de nascimento do cliente (dd-MM-yyyy):");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

        Console.WriteLine("Informe o CPF do cliente:");
        string cpf = Console.ReadLine();

        Console.WriteLine("Informe a altura do cliente (em cm):");
        int altura = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o peso do cliente (em kg):");
        int peso = int.Parse(Console.ReadLine());

        Cliente cliente = new Cliente(nome, dataNascimento, cpf, altura, peso);
        academia.AdicionarCliente(cliente);

        Console.WriteLine("Cliente adicionado com sucesso!");
        Console.ReadLine();
    }

    static void RemoverCliente(Academia academia)
    {
        Console.WriteLine("Informe o CPF do cliente a ser removido:");
        string cpf = Console.ReadLine();

        Cliente cliente = academia.GetClientePorCPF(cpf);

        if (cliente != null)
        {
            academia.RemoverCliente(cliente);
            Console.WriteLine("Cliente removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }

        Console.ReadLine();
    }

}