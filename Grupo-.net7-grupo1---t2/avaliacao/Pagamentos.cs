using InterfacePagamento;
using Plano;

namespace Pagamentos
{
    public class Pagamento : IPagamento
    {
        private readonly Plano plano; // Adicionando referência ao Plano

        public Pagamento(Plano plano)
        {
            this.plano = plano;
        }

        public void RealizarPagamentoPlano()
        {
            double valorPlano = plano.Valormensal; // Obtendo o valor mensal do plano
            // Aqui você pode realizar a lógica para o pagamento, como imprimir, enviar a transação para um serviço de pagamento, etc.
            Console.WriteLine($"Pagamento realizado no valor de R$ {valorPlano} para o plano {plano.Título}");
        }
    }
}
