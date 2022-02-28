using Principios_SOLID.Enum;

namespace Principios_SOLID.Factory
{
    public interface ICalculaDescontoStatusClienteFactory
    {
        ICalculaDescontoStatusConta ObterCalculoDescontoStatusConta(StatusContaClienteEnum statusContaCliente);
    }
}