using System;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    sealed class ContaAplicacao : Conta
    {
        private decimal PercentualRentabilidade;
        public ContaAplicacao(DateTime dataNascimento, DateTime dataDeposito)
        {
            Depositar();
            CalcularPercentualDeRendimento(dataNascimento);
            int quantidadeDeMeses = dataDeposito.ObterDiferencaEmMeses(DateTime.Today);
            var valorRentabilizado = decimal.Round(Saldo * quantidadeDeMeses * PercentualRentabilidade, 2);
            decimal taxaInstantanea = (Saldo + valorRentabilizado) * 0.03m;
            SaldoRentabilizado = Math.Round(Saldo + valorRentabilizado + taxaInstantanea, 2);
        }
        public void Depositar()
        {
            do
            {
                Console.WriteLine("Digite o valor para depositar:");
                if (decimal.TryParse(Console.ReadLine(), out valorDeposito)) { break; }
                else { Console.WriteLine("Entrada invalida, tente novamente"); }
            } while (true);
            if (valorDeposito > 0m)
            {
                Saldo += valorDeposito;
            }
            else
            {
                throw new Exception($"O valor de depósito: '{valorDeposito}' era menor ou igual a R$ 0,00! Operação não permitida!");
            }
        }
        public void CalcularPercentualDeRendimento(DateTime dataNascimento)
        {
            int idade = dataNascimento.ObterDiferencaEmAnos(DateTime.Today);
            decimal taxa = (121 - idade) * 0.1m;
            PercentualRentabilidade = taxa;
        }
    }
}