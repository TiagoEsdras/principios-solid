namespace Principios_SOLID
{
    public class ClienteEspecial : ICalculaDescontoStatusConta
    {
        public decimal AplicarDescontoStatusConta(decimal preco)
        {
            return preco - (Constantes.DESCONTO_CLIENTE_ESPECIAL * preco);
        }
    }
}