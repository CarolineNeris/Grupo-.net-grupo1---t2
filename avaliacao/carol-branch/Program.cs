using System;
using Pessoas; // Importando o namespace onde as classes Pessoa, Cliente e Treinador estão definidas
using Academias;
using Relatorios; // Importando o namespace onde a classe Metodos está definida

using System;

class Program
{
    static void Main()
    {
        Academia academia = new Academia();
        Relatorio relatorio = new Relatorio();

        bool sair = false;

        Console.WriteLine("Selecione a operação desejada:");
        Console.WriteLine("1. Cadastrar Cliente");
        Console.WriteLine("2. Cadastrar Treinador");
        Console.WriteLine("3. Exibir Cadastros");
        Console.WriteLine("4. Relatório de Treinadores por Idade");
        Console.WriteLine("5. Relatório de Clientes por Idade");
        Console.WriteLine("6. Relatório de Clientes por IMC");
        Console.WriteLine("7. Relatório de Clientes em Ordem Alfabética");
        Console.WriteLine("8. Relatório de Clientes do Mais Velho para o Mais Novo");
        Console.WriteLine("9. Relatório de Aniversariantes do Mês");
        Console.WriteLine("0. Sair");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("Digite o nome do cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Digite a data de nascimento do cliente (yyyy-MM-dd):");
                DateTime dataNascimentoCliente = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Digite o CPF do cliente:");
                string cpfCliente = Console.ReadLine();
                Console.WriteLine("Digite a altura do cliente:");
                double alturaCliente = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite o peso do cliente:");
                double pesoCliente = Convert.ToDouble(Console.ReadLine());
                academia.CadastrarCliente(nomeCliente, dataNascimentoCliente, cpfCliente, alturaCliente, pesoCliente);
                break;

            case "2":
                Console.WriteLine("Digite o nome do treinador:");
                string nomeTreinador = Console.ReadLine();
                Console.WriteLine("Digite a data de nascimento do treinador (yyyy-MM-dd):");
                DateTime dataNascimentoTreinador = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Digite o CPF do treinador:");
                string cpfTreinador = Console.ReadLine();
                Console.WriteLine("Digite o CREF do treinador:");
                string crefTreinador = Console.ReadLine();
                academia.CadastrarTreinador(nomeTreinador, dataNascimentoTreinador, cpfTreinador, crefTreinador);
                break;

            case "3":
                academia.ExibirCadastros();
                break;

            case "4":
                Console.WriteLine("Digite a idade mínima:");
                int idadeMinimaTreinadores = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a idade máxima:");
                int idadeMaximaTreinadores = Convert.ToInt32(Console.ReadLine());
                relatorio.RelatorioTreinadoresPorIdade(idadeMinimaTreinadores, idadeMaximaTreinadores);
                break;

            case "5":
                Console.WriteLine("Digite a idade mínima:");
                int idadeMinimaClientes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite a idade máxima:");
                int idadeMaximaClientes = Convert.ToInt32(Console.ReadLine());
                relatorio.RelatorioClientesPorIdade(idadeMinimaClientes, idadeMaximaClientes);
                break;

            case "6":
                Console.WriteLine("Digite o valor do IMC:");
                double valorIMC = Convert.ToDouble(Console.ReadLine());
                relatorio.RelatorioClientesPorIMC(valorIMC);
                break;

            case "7":
                relatorio.RelatorioClientesOrdemAlfabetica();
                break;

            case "8":
                relatorio.RelatorioClientesPorIdade();
                break;

            case "9":
                Console.WriteLine("Digite o mês desejado:");
                int mesAniversariantes = Convert.ToInt32(Console.ReadLine());
                relatorio.RelatorioAniversariantesDoMes(mesAniversariantes);
                break;
            case "0":
                sair = true;
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
        if (!sair)
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
