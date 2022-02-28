using Principios_SOLID.Enum;
using Principios_SOLID.Factory;

namespace Principios_SOLID
{
    public class GerenciadorDeDescontos
    {
        private readonly ICalculaDescontoFidelidade _calculaDescontoFidelidade;
        private readonly ICalculaDescontoStatusClienteFactory _calculaDescontoStatusClienteFactory;

        public GerenciadorDeDescontos(
            ICalculaDescontoFidelidade calculaDescontoFidelidade,
            ICalculaDescontoStatusClienteFactory calculaDescontoStatusClienteFactory
            )
        {
            _calculaDescontoFidelidade = calculaDescontoFidelidade;
            _calculaDescontoStatusClienteFactory = calculaDescontoStatusClienteFactory;
        }

        public decimal AplicarDesconto(decimal precoProduto, StatusContaClienteEnum statusContaCiente, int tempoDeContaEmAnos)
        {
            decimal precoAposDesconto;

            precoAposDesconto = _calculaDescontoStatusClienteFactory.ObterCalculoDescontoStatusConta(statusContaCiente).AplicarDescontoStatusConta(precoProduto);

            precoAposDesconto = _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);

            return precoAposDesconto;
        }
    }
}