using System;
using Principios_SOLID.Enum;

namespace Principios_SOLID
{
    public class GerenciadorDeDescontos
    {
        public decimal AplicarDesconto(decimal precoProduto, StatusContaClienteEnum statusContaCiente, int tempoDeContaEmAnos)
        {
            decimal precoAposDesconto = 0;
            
            decimal descontoPorFidelidade = (tempoDeContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE) ?
                (decimal)Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 :
                (decimal)tempoDeContaEmAnos / 100;

            switch (statusContaCiente)
            {
                case StatusContaClienteEnum.NaoResgistrado:
                    precoAposDesconto = precoProduto;
                    break;
                case StatusContaClienteEnum.ClienteComum:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_COMUM * precoProduto));
                    precoAposDesconto -= descontoPorFidelidade * (precoProduto - (0.1m * precoProduto));
                    break;
                case StatusContaClienteEnum.CienteEspecial:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_ESPECIAL * precoProduto));
                    precoAposDesconto -= descontoPorFidelidade * (precoProduto - (0.3m * precoProduto));
                    break;
                case StatusContaClienteEnum.ClienteVip:
                    precoAposDesconto = (precoProduto - (Constantes.DESCONTO_CLIENTE_VIP * precoProduto));
                    precoAposDesconto -= descontoPorFidelidade * (precoProduto - (0.5m * precoProduto));
                    break;

                default:
                    throw new NotImplementedException();
            }
           
            return precoAposDesconto;
        }
    }
}