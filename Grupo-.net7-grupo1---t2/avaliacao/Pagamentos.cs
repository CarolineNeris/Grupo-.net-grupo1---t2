using InterfacePagamento; 
using Avaliacao; 
namespace Pagamentos
{
    public class Pagamento : IPagamento
    {
        private readonly double valorPlano; 

        public Pagamento(double valor)
        {
            valorPlano = valor; 
        }

        public void RealizarPagamentoPlano(double valor)
        {
            
            Console.WriteLine($"Pagamento realizado no valor de R$ {valor}");
        }
    }
}
