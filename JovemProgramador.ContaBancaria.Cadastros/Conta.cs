using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    public class Conta 
    {
        public decimal Saldo;
        public decimal SaldoRentabilizado;
        public decimal valorDeposito;
        public string Nome;

        public Conta()
        {

        }
        public Conta(string nome, decimal saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }
        public Conta(decimal saldoRentabilizado, string nome)
        {
            Nome = nome;
            SaldoRentabilizado = saldoRentabilizado;
        }
    }
}
