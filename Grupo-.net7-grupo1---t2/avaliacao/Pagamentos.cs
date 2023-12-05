using System; 
using InterfacePagamento;
using Avaliacao;

namespace Pagamentos
{
    public class Pagamento : IPagamento
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public DateTime DataHora { get; set; }

        public Pagamento(string descricao, double valor, double desconto, DateTime dataHora)
        {
            Descricao = descricao;
            ValorPorMes = valor;
            Desconto = desconto;
            DataHora = dataHora;
        }

        public void RealizarPagamentoPlano(double valor)
        {
            Console.WriteLine($"Pagamento realizado no valor de R$ {valor}");
        }
    }
}
