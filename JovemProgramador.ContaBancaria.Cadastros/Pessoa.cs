using System;
using System.Collections.Generic;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    class Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataDeDeposito { get; set; }
        public List<Conta> ListaDeContas { get; set; } = new List<Conta>();

        public Pessoa(string nome, DateTime dataNascimento, Conta conta)
        {
            ListaDeContas.Add(conta);
            Nome = nome;
            DataDeNascimento = dataNascimento;
        }
        
    }
}
