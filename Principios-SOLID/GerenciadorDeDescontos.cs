using Principios_SOLID.Enum;
using System;

namespace Principios_SOLID
{
    public class GerenciadorDeDescontos
    {
        private readonly ICalculaDescontoFidelidade _calculaDescontoFidelidade;

        public GerenciadorDeDescontos(
            ICalculaDescontoFidelidade calculaDescontoFidelidade
            )
        {
            _calculaDescontoFidelidade = calculaDescontoFidelidade;
        }

        public decimal AplicarDesconto(decimal precoProduto, StatusContaClienteEnum statusContaCiente, int tempoDeContaEmAnos)
        {
            decimal precoAposDesconto;

            switch (statusContaCiente)
            {
                case StatusContaClienteEnum.NaoResgistrado:
                    precoAposDesconto = new ClienteNaoRegistrado().AplicarDescontoStatusConta(precoProduto);
                    break;

                case StatusContaClienteEnum.ClienteComum:
                    precoAposDesconto = new ClienteComum().AplicarDescontoStatusConta(precoProduto);
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                case StatusContaClienteEnum.CienteEspecial:
                    precoAposDesconto = new ClienteEspecial().AplicarDescontoStatusConta(precoProduto);
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                case StatusContaClienteEnum.ClienteVip:
                    precoAposDesconto = new ClienteVip().AplicarDescontoStatusConta(precoProduto);
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return precoAposDesconto;
        }
    }
}