using Principios_SOLID.Enum;
using System;

namespace Principios_SOLID
{
    public class GerenciadorDeDescontos
    {
        private readonly ICalculaDescontoFidelidade _calculaDescontoFidelidade;

        public GerenciadorDeDescontos(ICalculaDescontoFidelidade calculaDescontoFidelidade)
        {
            _calculaDescontoFidelidade = calculaDescontoFidelidade;
        }

        public decimal AplicarDesconto(decimal precoProduto, StatusContaClienteEnum statusContaCiente, int tempoDeContaEmAnos)
        {
            decimal precoAposDesconto;

            switch (statusContaCiente)
            {
                case StatusContaClienteEnum.NaoResgistrado:
                    precoAposDesconto = precoProduto;
                    break;

                case StatusContaClienteEnum.ClienteComum:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_COMUM * precoProduto));
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                case StatusContaClienteEnum.CienteEspecial:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_ESPECIAL * precoProduto));
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                case StatusContaClienteEnum.ClienteVip:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_VIP * precoProduto));
                    precoAposDesconto -= _calculaDescontoFidelidade.AplicarDescontoFidelidade(precoAposDesconto, tempoDeContaEmAnos);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return precoAposDesconto;
        }
    }
}