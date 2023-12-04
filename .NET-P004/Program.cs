using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
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

        
        academia.SalvarCadastroEmArquivo(treinador);

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
        
        string filePath = $"{treinador.CPF} - {treinador.Nome}.txt";
        File.Delete(filePath);

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

        
        academia.SalvarCadastroEmArquivo(cliente);

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
        
        string filePath = $"{cliente.CPF} - {cliente.Nome}.txt";
        File.Delete(filePath);

        Console.WriteLine("Cliente removido com sucesso!");
    }
    else
    {
        Console.WriteLine("Cliente não encontrado.");
    }

    Console.ReadLine();
}

    static void ListarClientes(Academia academia)
    {
        List<Cliente> clientes = academia.ListarClientes();

        if (clientes.Count > 0)
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
        }

        Console.ReadLine();
    }

    static void GerarRelatorios(Academia academia)
    {
        while (true)
    {
        Console.Clear();
        Console.WriteLine("==== Menu Relatórios ====");
        Console.WriteLine("\n1. Clientes Ordenados Por Nome");
        Console.WriteLine("2. Clientes Mais Velhos Para Mais Novos");
        Console.WriteLine("3. Treinadores Aniversariantes do Mês");
        Console.WriteLine("4. Gerar Relatório Geral em TXT");
        Console.WriteLine("0. Voltar");

        Console.Write("\nEscolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                academia.ExibirClientesOrdenadosPorNome();
                break;
            case "2":
                academia.ExibirClientesOrdenadosPorIdadeMaisVelhoParaMaisNovo();
                break;
            case "3":
                Console.WriteLine("Informe o número do mês:");
                int mes = Convert.ToInt32(Console.ReadLine());
                academia.ExibirTreinadoresAniversariantesDoMes(mes);
                break;
            case "4":  
                academia.GerarRelatorioGeral();                
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

class Academia
{
    private List<Treinador> treinadores = new List<Treinador>();
    private List<Cliente> clientes = new List<Cliente>();

    public void AdicionarTreinador(Treinador treinador)
    {
        treinadores.Add(treinador);
    }

    public void RemoverTreinador(Treinador treinador)
    {
        treinadores.Remove(treinador);
    }

    public List<Treinador> ListarTreinadores()
    {
        return treinadores;
    }

    public void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public void RemoverCliente(Cliente cliente)
    {
        clientes.Remove(cliente);
    }

    public List<Cliente> ListarClientes()
    {
        return clientes;
    }

    public Treinador GetTreinadorPorCPF(string cpf)
    {
        return treinadores.FirstOrDefault(t => t.CPF == cpf);
    }

    public Cliente GetClientePorCPF(string cpf)
    {
        return clientes.FirstOrDefault(c => c.CPF == cpf);
    }

    public void ExibirClientesOrdenadosPorNome(StreamWriter sw)
{
    var clientesOrdenados = clientes.OrderBy(c => c.Nome).ToList();

    Console.WriteLine("==== Clientes Ordenados Por Nome ====");

    if (clientesOrdenados.Count > 0)
    {
        foreach (var cliente in clientesOrdenados)
        {
            sw.WriteLine($"Nome: {cliente.Nome}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
        }
    }
    else
    {
        sw.WriteLine("Nenhum cliente cadastrado.");
    }
}


    public void ExibirClientesOrdenadosPorIdadeMaisVelhoParaMaisNovo(StreamWriter sw)
{
    var clientesOrdenados = clientes.OrderByDescending(c => GetIdade(c.DataNascimento)).ToList();

    if (clientesOrdenados.Count > 0)
    {
        foreach (var cliente in clientesOrdenados)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {GetIdade(cliente.DataNascimento)} anos");
        }
    }
    else
    {
        Console.WriteLine("Nenhum cliente cadastrado.");
    }
}

    private int GetIdade(DateTime dataNascimento)
{
    DateTime now = DateTime.Now;
    int idade = now.Year - dataNascimento.Year;

    if (now.Month < dataNascimento.Month || (now.Month == dataNascimento.Month && now.Day < dataNascimento.Day))
    {
        idade--;
    }

    return idade;
}


   public void ExibirTreinadoresAniversariantesDoMes(StreamWriter sw, int mes)
{
    var treinadoresAniversariantes = treinadores
        .Where(t => t.DataNascimento.Month == mes)
        .ToList();

    Console.WriteLine($"==== Treinadores Aniversariantes do Mês {mes} ====");

    if (treinadoresAniversariantes.Count > 0)
    {
        foreach (var treinador in treinadoresAniversariantes)
        {
            Console.WriteLine($"Nome: {treinador.Nome}, Data de Nascimento: {treinador.DataNascimento:dd-MM-yyyy}");
        }
    }
    else
    {
        Console.WriteLine("Nenhum treinador aniversariante neste mês.");
    }

}

    public void SalvarCadastroEmArquivo(Pessoa pessoa)
    {
        string nomeArquivo = new string(pessoa.Nome.Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c).ToArray());

        string filePath = $"{pessoa.CPF} - {nomeArquivo}.txt";

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            

            if (pessoa is Treinador treinador)
            {
                sw.WriteLine($"Ficha de Treinador\n");
                sw.WriteLine($"Nome: {pessoa.Nome}");
                sw.WriteLine($"Data de Nascimento: {pessoa.DataNascimento:dd-MM-yyyy}");
                sw.WriteLine($"CPF: {pessoa.CPF}");
                sw.WriteLine($"CREF: {treinador.CREF}");
            }
            else if (pessoa is Cliente cliente)
            {
                sw.WriteLine($"Ficha do Cliente\n");
                sw.WriteLine($"Nome: {pessoa.Nome}");
                sw.WriteLine($"Data de Nascimento: {pessoa.DataNascimento:dd-MM-yyyy}");
                sw.WriteLine($"CPF: {pessoa.CPF}");
                sw.WriteLine($"Altura: {cliente.Altura}");
                sw.WriteLine($"Peso: {cliente.Peso}");
            }
        }
    }

    // Adicione este método à classe Academia

public void GerarRelatorioGeral()
{
    string filePath = "RelatorioGeral.txt";

    using (StreamWriter sw = new StreamWriter(filePath))
    {
               
        sw.WriteLine("==== Relatório de Treinadores ====\n");
        List<Treinador> treinadoresList = ListarTreinadores();
        foreach (var treinador in treinadoresList)
        {
            sw.WriteLine($"Nome: {treinador.Nome}, Data de Nascimento: {treinador.DataNascimento:dd-MM-yyyy}, CREF: {treinador.CREF}");
        }
        
        sw.WriteLine("\n");
        
        sw.WriteLine("==== Relatório de Clientes ====\n");
        foreach (var cliente in clientes)
        {
            sw.WriteLine($"Nome: {cliente.Nome}, Altura: {cliente.Altura}, Peso: {cliente.Peso}");
            sw.WriteLine($"Idade: {GetIdade(cliente.DataNascimento)}\n");
        }
    }

    Console.WriteLine($"Relatório geral gerado com sucesso. Arquivo salvo em {filePath}");
    Console.ReadLine();
}


    internal void ExibirClientesOrdenadosPorNome()
    {
        throw new NotImplementedException();
    }

    internal void ExibirClientesOrdenadosPorIdadeMaisVelhoParaMaisNovo()
    {
        throw new NotImplementedException();
    }

    internal void ExibirTreinadoresAniversariantesDoMes(int mes)
    {
        throw new NotImplementedException();
    }
}

class Pessoa
{   
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }
}

class Treinador : Pessoa
{
    public string CREF { get; set; }

    public Treinador(string nome, DateTime dataNascimento, string cpf, string cref)
        : base(nome, dataNascimento, cpf)
    {
        CREF = cref;
    }
}


class Cliente : Pessoa
{
    public int Altura { get; set; }
    public int Peso { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, int altura, int peso)
        : base(nome, dataNascimento, cpf)
    {
        Altura = altura;
        Peso = peso;
    }
}
