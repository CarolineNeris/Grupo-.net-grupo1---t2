﻿﻿using System;
using Pessoas;
using Academias;
using Relatorios;
using Planos;


class Program
{
    static void Main(string[] args)
    {
        Academia academia = new Academia();
        Relatorio relatorio = new Relatorio();
            
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

        
        Exercicio.CadastrarExercicio("Ombros", 5, 12, 30);
        Exercicio.CadastrarExercicio("Glúteos", 4, 15, 60);
        Exercicio.CadastrarExercicio("Trapézio", 3, 8, 45);
        Exercicio.CadastrarExercicio("Bíceps", 5, 10, 30);
        Exercicio.CadastrarExercicio("Tríceps", 4, 12, 60);
        Exercicio.CadastrarExercicio("Panturrilhas", 3, 15, 45);
        Exercicio.CadastrarExercicio("Antebraços", 5, 8, 30);
        Exercicio.CadastrarExercicio("Cardio", 4, 10, 60);
        Exercicio.CadastrarExercicio("Yoga", 3, 12, 45);
        Exercicio.CadastrarExercicio("Alongamento", 5, 15, 30);
        Exercicio.CadastrarExercicio("Pilates", 4, 8, 60);
        Exercicio.CadastrarExercicio("Funcional", 3, 10, 45);
        Exercicio.CadastrarExercicio("HIIT", 5, 12, 30);
        Exercicio.CadastrarExercicio("Zumba", 4, 15, 60);
        Exercicio.CadastrarExercicio("Natação", 3, 8, 45);

        
        foreach (Exercicio ex in Exercicio.listaExercicios)
        {
            Console.WriteLine($"Grupo Muscular: {ex.GrupoMuscular}, Séries: {ex.Series}, Repetições: {ex.Repeticoes}, Intervalo: {ex.TempoIntervaloSegundos} segundos");
        }

        
        foreach (Exercicio ex in Exercicio.listaExercicios){}

            bool continuar = true;

        while (continuar)
        {
            Console.Clear();
                Console.WriteLine("ACADEMIA TECH FIT - Sistema de Gerenciamento.\n");
                Console.WriteLine("==== Menu Principal ====\n");
                Console.WriteLine("1. Cadastros");
                Console.WriteLine("2. Consultas/Relatórios");
                Console.WriteLine("3. Planos");
                Console.WriteLine("0. Sair");

            Console.Write("\nSelecione a operação desejada: ");
            string opcaoPrincipal = Console.ReadLine();            

            switch (opcaoPrincipal)
            {   
                case "1":
                    bool menuCadastros = true;
                    while (menuCadastros)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("\n==== Menu Cadastros ====\n");                    
                        Console.WriteLine("1. Cadastrar Cliente");
                        Console.WriteLine("2. Cadastrar Treinador");
                        Console.WriteLine("3. Exibir Cadastros");
                        Console.WriteLine("4. Cadastrar novo Exercício");
                        Console.WriteLine("0. Voltar ao Menu Principal");

                        Console.Write("\nSelecione a operação desejada: ");
                        string opcaoCadastros = Console.ReadLine();
                        
                        switch (opcaoCadastros)
                        {
                            case "1":
                                Console.WriteLine("\nDigite o nome do cliente:");
                                string nomeCliente = Console.ReadLine();
                                Console.WriteLine("Digite a data de nascimento do cliente (yyyy-MM-dd):");
                                DateTime dataNascimentoCliente = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Digite o CPF do cliente com 11 dígitos:");
                                string cpfCliente = Console.ReadLine();
                                Console.WriteLine("Digite a altura do cliente:");
                                double alturaCliente = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Digite o peso do cliente:");
                                double pesoCliente = Convert.ToDouble(Console.ReadLine());
                                academia.CadastrarCliente(nomeCliente, dataNascimentoCliente, cpfCliente, alturaCliente, pesoCliente);
                                break;

                            case "2":
                                Console.WriteLine("\nDigite o nome do treinador:");
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
                                Console.WriteLine("\nDigite o grupo muscular do exercício:");
                                string grupoMuscular = Console.ReadLine();

                                Console.WriteLine("Digite o número de séries do exercício:");
                                int series = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Digite o número de repetições do exercício:");
                                int repeticoes = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Digite o tempo de intervalo em segundos do exercício:");
                                int tempoIntervaloSegundos = Convert.ToInt32(Console.ReadLine());

                               
                                Exercicio.CadastrarExercicio(grupoMuscular, series, repeticoes, tempoIntervaloSegundos);
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
            

                case "2":
                    bool menuConsultas = true;
                    while (menuConsultas)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Menu Relatórios ====\n");
                        Console.WriteLine("1. Relatório de Treinadores por Idade");
                        Console.WriteLine("2. Relatório de Clientes por Idade");
                        Console.WriteLine("3. Relatório de Clientes por IMC");
                        Console.WriteLine("4. Relatório de Clientes em Ordem Alfabética");
                        Console.WriteLine("5. Relatório de Clientes do Mais Velho para o Mais Novo");
                        Console.WriteLine("6. Relatório de Aniversariantes do Mês");
                        Console.WriteLine("0. Voltar ao Menu Principal");

                        Console.Write("\nSelecione a operação desejada: ");
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

                case "3":
                        bool menuPlanos = true;
                        while (menuPlanos)
                        {
                            Console.Clear();
                            Console.WriteLine("==== Menu Planos ====\n");
                            Console.WriteLine("1. Cadastrar Plano");
                            Console.WriteLine("2. Listar Planos");
                            Console.WriteLine("0. Voltar ao Menu Principal");

                            Console.Write("\nSelecione a operação desejada: ");
                            string opcaoPlanos = Console.ReadLine();

                            switch (opcaoPlanos)
                            {
                                case "1":
                                    Console.WriteLine("\nDigite o título do plano:");
                                    string tituloPlano = Console.ReadLine();
                                    Console.WriteLine("Digite o valor por mês do plano:");
                                    double valorPorMes = Convert.ToDouble(Console.ReadLine());
                                    academia.CadastrarPlano(tituloPlano, valorPorMes);
                                    break;

                                case "2":
                                    academia.ListarPlanos();
                                    break;

                                case "0":
                                    menuPlanos = false;
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