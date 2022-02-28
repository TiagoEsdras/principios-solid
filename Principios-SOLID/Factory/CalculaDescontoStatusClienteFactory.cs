using Principios_SOLID.Enum;
using System;

namespace Principios_SOLID.Factory
{
    public class CalculaDescontoStatusClienteFactory : ICalculaDescontoStatusClienteFactory
    {
        public ICalculaDescontoStatusConta ObterCalculoDescontoStatusConta(StatusContaClienteEnum statusContaCliente)
        {
            ICalculaDescontoStatusConta calcular;
            switch (statusContaCliente)
            {
                case StatusContaClienteEnum.NaoResgistrado:
                    calcular = new ClienteNaoRegistrado();                    
                    break;

                case StatusContaClienteEnum.ClienteComum:
                    calcular = new ClienteComum();
                    break;

                case StatusContaClienteEnum.CienteEspecial:
                    calcular = new ClienteEspecial();
                    break;

                case StatusContaClienteEnum.ClienteVip:
                    calcular = new ClienteVip();
                    break;

                default:
                    throw new NotImplementedException();
            }

            return calcular;
        }
    }
}