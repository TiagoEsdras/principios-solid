using Principios_SOLID.Enum;
using System;

namespace Principios_SOLID
{
    public class GerenciadorDeDescontos
    {
        public decimal AplicarDesconto(decimal precoProduto, StatusContaClienteEnum statusContaCiente, int tempoDeContaEmAnos)
        {
            decimal precoAposDesconto = 0;

            decimal descontoPorFidelidade = (tempoDeContaEmAnos > 5) ? (decimal)5 / 100 : (decimal)tempoDeContaEmAnos / 100;

            switch (statusContaCiente)
            {
                case StatusContaClienteEnum.NaoResgistrado:
                    precoAposDesconto = precoProduto;
                    break;
                case StatusContaClienteEnum.ClienteComum:
                    precoAposDesconto = (precoProduto - (0.1m * precoProduto)) - descontoPorFidelidade * (precoProduto - (0.1m * precoProduto));
                    break;
                case StatusContaClienteEnum.CienteEspecial:
                        precoAposDesconto = (0.7m * precoProduto) - descontoPorFidelidade * (0.7m * precoProduto);
                    break;
                case StatusContaClienteEnum.ClienteVip:
                    precoAposDesconto = (precoProduto - (0.5m * precoProduto)) - descontoPorFidelidade * (precoProduto - (0.5m * precoProduto));
                    break;

                default:
                    throw new NotImplementedException();
            }
           
            return precoAposDesconto;
        }
    }
}