namespace Principios_SOLID
{
    public class CalculaDescontoFidelidade : ICalculaDescontoFidelidade
    {
        public decimal AplicarDescontoFidelidade(decimal preco, int tempoDeContaEmAnos)
        {
            decimal porcentangemDescontoPorFidelidade = tempoDeContaEmAnos > Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE ?
                  (decimal)Constantes.DESCONTO_MAXIMO_POR_FIDELIDADE / 100 :
                  (decimal)tempoDeContaEmAnos / 100;

            return preco - (porcentangemDescontoPorFidelidade * preco);
        }
    }
}