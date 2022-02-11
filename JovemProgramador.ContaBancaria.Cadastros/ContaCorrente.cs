using System;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    sealed class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            Depositar();
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
    }   
}
