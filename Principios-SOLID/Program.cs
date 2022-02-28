using Principios_SOLID.Enum;
using Principios_SOLID.Factory;
using System;

namespace Principios_SOLID
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICalculaDescontoFidelidade calculaDescontoFidelidade = new CalculaDescontoFidelidade();

            ICalculaDescontoStatusClienteFactory calculaDescontoStatusClienteFactory = new CalculaDescontoStatusClienteFactory();

            GerenciadorDeDescontos gerenciadorDeDescontos = new GerenciadorDeDescontos(calculaDescontoFidelidade, calculaDescontoStatusClienteFactory);

            Console.WriteLine("Valor da compra 1000 e fidelidade 10 anos (5%)\n");

            var resultado = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.ClienteComum, 10);
            Console.WriteLine($"Cliente tipo 2, 10 anos fidelidade,  = {resultado}");

            var resultado1 = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.CienteEspecial, 10);
            Console.WriteLine($"Cliente tipo 3 o valor do desconto é de : {resultado1}");

            var resultado2 = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.ClienteVip, 10);
            Console.WriteLine($"Cliente tipo 4 o valor do desconto é de : {resultado2}\n");

            Console.WriteLine("Valor da compra 1000 e fidelidade 4 anos (4%)\n");
            var resultado3 = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.ClienteComum, 4);
            Console.WriteLine($"Cliente tipo 2, 10 anos fidelidade,  = {resultado3}");

            var resultado4 = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.CienteEspecial, 4);
            Console.WriteLine($"Para Cliente tipo 3 o valor do desconto é de : {resultado4}");

            var resultado5 = gerenciadorDeDescontos.AplicarDesconto(1000, StatusContaClienteEnum.ClienteVip, 4);
            Console.WriteLine($"Para Cliente tipo 4 o valor do desconto é de : {resultado5}");

            Console.ReadLine();
        }
    }
}