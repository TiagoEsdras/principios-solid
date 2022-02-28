namespace Principios_SOLID
{
    public class CalculaDescontoFidelidade : ICalculaDescontoFidelidade
    {
        public decimal AplicarDescontoFidelidade(decimal preco, int tempoDeContaEmAnos)
        {
            decimal porcentangemDescontoPorFidelidade = tempoDeContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE ?
                  Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 :
                  tempoDeContaEmAnos / 100;

            return preco - (porcentangemDescontoPorFidelidade * preco);
        }
    }
}