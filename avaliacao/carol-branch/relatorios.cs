using System;
using System.Collections.Generic;
using System.Linq;
using Pessoas;
using Academias;

namespace Relatorios
{
    class Relatorio
    {
        private static Academia academia = new Academia(); // Correção: Adicionei os parênteses para inicialização do objeto

        public void RelatorioTreinadoresPorIdade(int idadeMinima, int idadeMaxima)
        {
            DateTime hoje = DateTime.Today;

            var treinadoresFiltrados = academia.ObterCadastros()
                .Where(cadastro => cadastro.tipo == "Treinador")
                .Select(cadastro => (Treinador)cadastro.pessoa)
                .Where(treinador =>
                    hoje.Year - treinador.DataNascimento.Year >= idadeMinima &&
                    hoje.Year - treinador.DataNascimento.Year <= idadeMaxima
                );

            Console.WriteLine($"Relatório de Treinadores com idade entre {idadeMinima} e {idadeMaxima} anos:");
            foreach (var treinador in treinadoresFiltrados)
            {
                ExibirDetalhesTreinador(treinador);
            }
        }

        public void RelatorioClientesPorIdade(int idadeMinima, int idadeMaxima)
        {
            Console.WriteLine("Relatório de Clientes por Idade:");
            DateTime dataAtual = DateTime.Today;

            var clientesFiltrados = academia.ObterCadastros()
                .Where(cadastro => cadastro.Item2 == "Cliente")
                .Select(cadastro => (Cliente)cadastro.Item1)
                .Where(cliente =>
                    (dataAtual - cliente.DataNascimento).Days / 365 >= idadeMinima &&
                    (dataAtual - cliente.DataNascimento).Days / 365 <= idadeMaxima);

            foreach (var cliente in clientesFiltrados)
            {
                ExibirDetalhesCliente(cliente);
            }
        }

        public void RelatorioClientesPorIMC(double valorIMC)
        {
            Console.WriteLine("Relatório de Clientes por IMC:");
            var clientesFiltrados = academia.ObterCadastros()
                .Where(cadastro => cadastro.Item2 == "Cliente")
                .Select(cadastro => (Cliente)cadastro.Item1)
                .Where(cliente =>
                {
                    if (cliente.Altura != 0)
                    {
                        double imc = cliente.Peso / (cliente.Altura * cliente.Altura);
                        return imc > valorIMC;
                    }
                    return false;
                })
                .OrderBy(cliente =>
                {
                    if (cliente.Altura != 0)
                    {
                        return cliente.Peso / (cliente.Altura * cliente.Altura);
                    }
                    return 0;
                });

            foreach (var cliente in clientesFiltrados)
            {
                ExibirDetalhesCliente(cliente);
            }
        }

        public void RelatorioClientesOrdemAlfabetica()
        {
            Console.WriteLine("Relatório de Clientes em Ordem Alfabética:");
            var clientesOrdenados = academia.ObterCadastros()
                .Where(cadastro => cadastro.Item2 == "Cliente")
                .Select(cadastro => (Cliente)cadastro.Item1)
                .OrderBy(cliente => cliente.Nome);

            foreach (var cliente in clientesOrdenados)
            {
                ExibirDetalhesCliente(cliente);
            }
        }

        public void RelatorioClientesPorIdade()
        {
            Console.WriteLine("Relatório de Clientes do Mais Velho para o Mais Novo:");
            var clientesFiltrados = academia.ObterCadastros()
                .Where(cadastro => cadastro.Item2 == "Cliente")
                .Select(cadastro => (Cliente)cadastro.Item1)
                .OrderByDescending(cliente => DateTime.Now.Year - cliente.DataNascimento.Year);

            foreach (var cliente in clientesFiltrados)
            {
                ExibirDetalhesCliente(cliente);
            }
        }

        public void RelatorioAniversariantesDoMes(int mes)
        {
            Console.WriteLine($"Relatório de Aniversariantes do Mês {mes}:");
            var aniversariantes = academia.ObterCadastros()
                .Where(cadastro => (cadastro.Item2 == "Cliente" || cadastro.Item2 == "Treinador") && cadastro.Item1 is Pessoa)
                .Select(cadastro => (Pessoa)cadastro.Item1)
                .Where(pessoa => pessoa.DataNascimento.Month == mes);

            foreach (var pessoa in aniversariantes)
            {
                if (pessoa is Cliente)
                {
                    ExibirDetalhesCliente((Cliente)pessoa);
                }
                else if (pessoa is Treinador)
                {
                    ExibirDetalhesTreinador((Treinador)pessoa);
                }
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
    }
}
