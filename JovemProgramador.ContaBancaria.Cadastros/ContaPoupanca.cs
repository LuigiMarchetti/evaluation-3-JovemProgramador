using System;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    sealed class ContaPoupanca : Conta
    {
        public ContaPoupanca(DateTime dataDeposito)
        {
            decimal rentabilidade = 0.03m;
            Console.WriteLine($"As contas Poupança possuem rentabilidade fixa de: {rentabilidade}\r");
            Depositar();
            CalcularRendimento(rentabilidade, dataDeposito);

        }
        private void CalcularRendimento(decimal rentabilidade, DateTime dataDeposito)
        {
            decimal rentabilidadeMensal = dataDeposito.ObterDiferencaEmMeses(DateTime.Today) * rentabilidade;
            decimal valorRenda = Saldo * rentabilidadeMensal;
            SaldoRentabilizado = Math.Round(Saldo + valorRenda, 2);
        }

        public void Depositar()
        {
            do
            {
                Console.WriteLine("Digite o valor para depositar:");
                if(decimal.TryParse(Console.ReadLine(), out valorDeposito)){ break; }
                else { Console.WriteLine("Entrada invalida, tente novamente"); }
            } while (true);
            while (true)
            {
                if (valorDeposito > 0m)
                {
                    Saldo += valorDeposito;
                    break;
                }
                else { Console.WriteLine("Entrada invalida, tente novamente"); }
            }
        }
    }
}
