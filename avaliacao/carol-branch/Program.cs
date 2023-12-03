using System;
using Pessoas;
using Academias;
using Relatorios;

class Program
{
    static void Main()
    {
        Academia academia = new Academia();
        Relatorio relatorio = new Relatorio();
        // Cadastros pré-definidos
        academia.CadastrarCliente("João", new DateTime(1990, 5, 15), "12345678900", 1.75, 70);
        academia.CadastrarCliente("Maria", new DateTime(1985, 10, 25), "98775832100", 1.60, 55);
        academia.CadastrarCliente("João", new DateTime(1990, 5, 15), "12345676800", 1.75, 70);
        academia.CadastrarCliente("Maria", new DateTime(1985, 10, 25), "98765473100", 1.60, 55);
        academia.CadastrarCliente("Carlos", new DateTime(1988, 7, 30), "11122239344", 1.80, 80);
        academia.CadastrarCliente("Juliana", new DateTime(1995, 12, 12), "55579677788", 1.65, 60);

        academia.CadastrarTreinador("Pedro", new DateTime(1980, 3, 8), "11122723344", "863001");
        academia.CadastrarTreinador("Ana", new DateTime(1975, 7, 12), "44632566677", "726892");
        academia.CadastrarTreinador("Ana", new DateTime(1975, 7, 12), "44456366677", "781902");
        academia.CadastrarTreinador("Mariana", new DateTime(1982, 9, 20), "99987577766", "624073");
        academia.CadastrarTreinador("Lucas", new DateTime(1978, 11, 5), "33329611100", "789084");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Selecione a operação desejada:");
            Console.WriteLine("1. Consultas/Relatórios");
            Console.WriteLine("2. Cadastros");
            Console.WriteLine("0. Sair");

            string opcaoPrincipal = Console.ReadLine();

            switch (opcaoPrincipal)
            {
                case "1":
                    bool menuConsultas = true;
                    while (menuConsultas)
                    {
                        Console.WriteLine("Selecione a operação desejada:");
                        Console.WriteLine("1. Relatório de Treinadores por Idade");
                        Console.WriteLine("2. Relatório de Clientes por Idade");
                        Console.WriteLine("3. Relatório de Clientes por IMC");
                        Console.WriteLine("4. Relatório de Clientes em Ordem Alfabética");
                        Console.WriteLine("5. Relatório de Clientes do Mais Velho para o Mais Novo");
                        Console.WriteLine("6. Relatório de Aniversariantes do Mês");
                        Console.WriteLine("0. Voltar ao Menu Principal");

                        string opcaoConsultas = Console.ReadLine();

                        switch (opcaoConsultas)
                        {
                            case "1":
                                Console.WriteLine("Digite a idade mínima:");
                                int idadeMinimaTreinadores = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Digite a idade máxima:");
                                int idadeMaximaTreinadores = Convert.ToInt32(Console.ReadLine());
                                relatorio.RelatorioTreinadoresPorIdade(idadeMinimaTreinadores, idadeMaximaTreinadores);
                                break;

                            case "2":
                                Console.WriteLine("Digite a idade mínima:");
                                int idadeMinimaClientes = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Digite a idade máxima:");
                                int idadeMaximaClientes = Convert.ToInt32(Console.ReadLine());
                                relatorio.RelatorioClientesPorIdade(idadeMinimaClientes, idadeMaximaClientes);
                                break;

                            case "3":
                                Console.WriteLine("Digite o valor do IMC:");
                                double valorIMC = Convert.ToDouble(Console.ReadLine());
                                relatorio.RelatorioClientesPorIMC(valorIMC);
                                break;

                            case "4":
                                relatorio.RelatorioClientesOrdemAlfabetica();
                                break;

                            case "5":
                                relatorio.RelatorioClientesPorIdade();
                                break;

                            case "6":
                                Console.WriteLine("Digite o mês desejado:");
                                int mesAniversariantes = Convert.ToInt32(Console.ReadLine());
                                relatorio.RelatorioAniversariantesDoMes(mesAniversariantes);
                                break;

                            case "0":
                                menuConsultas = false;
                                break;

                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                    }
                    break;

                case "2":
                    bool menuCadastros = true;
                    while (menuCadastros)
                    {
                        Console.WriteLine("Selecione a operação desejada:");
                        Console.WriteLine("1. Cadastrar Cliente");
                        Console.WriteLine("2. Cadastrar Treinador");
                        Console.WriteLine("3. Exibir Cadastros");
                        Console.WriteLine("0. Voltar ao Menu Principal");

                        string opcaoCadastros = Console.ReadLine();

                        switch (opcaoCadastros)
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

                            case "0":
                                menuCadastros = false;
                                break;

                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                    }
                    break;

                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
