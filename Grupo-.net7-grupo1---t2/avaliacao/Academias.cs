using System;
using System.Collections.Generic;
using System.Dynamic;
using Pessoas;
using Planos;

namespace Academias
{
    public class Academia
    {
        private List<(object pessoa, string tipo)> cadastros = new List<(object, string)>(); // Inicializando list cadastros

        public List<(object pessoa, string tipo)> ObterCadastros()
        {
            return cadastros;
        }

        public void CadastrarCliente(string nome, DateTime dataNascimento, string cpf, double altura, double peso)
        {
            Cliente cliente = new Cliente
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CPF = cpf,
                Altura = altura,
                Peso = peso
            };

            cadastros.Add((cliente, "Cliente"));
        }

        public void CadastrarTreinador(string nome, DateTime dataNascimento, string cpf, string cref)
        {
            Treinador treinador = new Treinador
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                CPF = cpf,
                CREF = cref
            };

            cadastros.Add((treinador, "Treinador"));
        }

        public void ExibirCadastros()
        {
            foreach (var cadastro in cadastros)
            {
                Console.WriteLine($"Tipo: {cadastro.tipo}");

                if (cadastro.tipo == "Cliente")
                {
                    var cliente = (Cliente)cadastro.pessoa;
                    ExibirDetalhesCliente(cliente);
                }
                else if (cadastro.tipo == "Treinador")
                {
                    var treinador = (Treinador)cadastro.pessoa;
                    ExibirDetalhesTreinador(treinador);
                }

                Console.WriteLine();
            }
        }

        private void ExibirDetalhesCliente(Cliente cliente)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Console.WriteLine($"Altura: {cliente.Altura}");
            Console.WriteLine($"Peso: {cliente.Peso}");
        }

        private void ExibirDetalhesTreinador(Treinador treinador)
        {
            Console.WriteLine($"Nome: {treinador.Nome}");
            Console.WriteLine($"Data de Nascimento: {treinador.DataNascimento}");
            Console.WriteLine($"CPF: {treinador.CPF}");
            Console.WriteLine($"CREF: {treinador.CREF}");
        }

        public List<Plano> ListaPlanos { get; set; } = new List<Plano>();

        public void CadastrarPlano(string titulo, double valorPorMes)
        {
            Plano novoPlano = new Plano(titulo, valorPorMes);
            ListaPlanos.Add(novoPlano);
            Console.WriteLine("Plano cadastrado com sucesso!");
        }

        public void ListarPlanos()
        {
            Console.WriteLine("\n=== Lista de Planos ===");
            foreach (Plano plano in ListaPlanos)
            {
                Console.WriteLine($"Título: {plano.Titulo}, Valor por Mês: {plano.ValorPorMes:C}");
            }
        }
    }

    public class Exercicio
    {
        public string GrupoMuscular { get; set; }
        public int Series { get; set; }
        public int Repeticoes { get; set; }
        public int TempoIntervaloSegundos { get; set; }

        public static List<Exercicio> listaExercicios = new List<Exercicio>();

        public static void CadastrarExercicio(string grupoMuscular, int series, int repeticoes, int tempoIntervaloSegundos)
        {
            Exercicio novoExercicio = new Exercicio()
            {
                GrupoMuscular = grupoMuscular,
                Series = series,
                Repeticoes = repeticoes,
                TempoIntervaloSegundos = tempoIntervaloSegundos
            };

            listaExercicios.Add(novoExercicio);
        }
    }

    public class TreinoCliente
    {
        public string Tipo { get; set; }
        public string Objetivo { get; set; }
        public List<Exercicio> ListaExercicios { get; set; }
        public int DuracaoEstimadaMinutos { get; set; }
        public DateTime DataInicio { get; set; }
        public int VencimentoDias { get; set; }
        //estou decidindo se coloco cliente no treino ou treino no cliente
    }
}