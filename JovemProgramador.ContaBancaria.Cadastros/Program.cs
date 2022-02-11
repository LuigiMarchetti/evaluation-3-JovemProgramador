using System;
using System.Collections.Generic;
using System.Linq;

namespace JovemProgramador.ContaBancaria.Cadastros
{

    class Program
    {

        static void Main(string[] args)
        {
            int numeroDePessoas;

            do
            {
                Console.WriteLine("Digite o numero de pessoas que deseja cadastrar:");
                if (int.TryParse(Console.ReadLine(), out numeroDePessoas)) { break; }
                else { Console.WriteLine("Entrada invalida, tente novamente"); }
            } while (true);
            RegistrarPessoas(numeroDePessoas);
        }

        public static void RegistrarPessoas(int numeroDePessoas)
        {
            var listaDePessoas = new List<Pessoa>();
            DateTime dataNascimento, dataDeposito;
            string tipoConta;
            for (int index = 0; index < numeroDePessoas; index++)
            {
                Console.WriteLine("Digite o nome de uma pessoa:");
                string nome = Console.ReadLine();
                do
                {
                    Console.WriteLine("Digite a data de nascimento (dd/mm/yyyy):");
                    if (DateTime.TryParse(Console.ReadLine(), out dataNascimento) && dataNascimento < DateTime.Today)
                    {
                        int idade = dataNascimento.ObterDiferencaEmAnos(DateTime.Today);
                        if (idade <= 16 || idade >= 120)
                        {
                            Console.WriteLine("Não é permitido o seu cadastrado pela usa idade");
                            return;
                        }
                        // ex de data: 06/01/2004
                        break;
                    }
                    else { Console.WriteLine("Entrada invalida, tente novamente"); }
                } while (true);
                bool auxiliar = true;
                do
                {
                    do
                    {
                        Console.WriteLine("Digite a abreviação da conta bancaria desejada dentre as 3 opções: Conta Corrente(CC), Conta Poupança (CP) ou Conta Aplicação (CA)");
                        tipoConta = Console.ReadLine().ToUpper();
                        var siglas = new List<string>() { "CC", "CP", "CA" };
                        if (siglas.Contains(tipoConta)) { break; }
                        else { Console.WriteLine("Entrada invalida, tente novamente"); }
                    } while (true);

                    if (tipoConta == "CC")
                    {
                        var conta = new ContaCorrente();
                        listaDePessoas.Add(new Pessoa(nome, dataNascimento, conta));
                    }
                    else if (tipoConta == "CA")
                    {
                        do
                        {
                            Console.WriteLine("Digite a data de deposito");
                            if (DateTime.TryParse(Console.ReadLine(), out dataDeposito) && dataDeposito < DateTime.Today)
                            {
                                break;
                            }
                            else { Console.WriteLine("Entrada invalida, tente novamente"); }
                        } while (true);
                        var conta = new ContaAplicacao(dataNascimento, dataDeposito);
                        listaDePessoas.Add(new Pessoa(nome, dataNascimento, conta));
                    }
                    else // CP
                    {
                        do
                        {
                            Console.WriteLine("Digite a data de deposito");
                            if (DateTime.TryParse(Console.ReadLine(), out dataDeposito) && dataDeposito < DateTime.Today)
                            {
                                break;
                            }
                            else { Console.WriteLine("Entrada invalida, tente novamente"); }
                        } while (true);
                        var conta = new ContaPoupanca(dataDeposito);
                        listaDePessoas.Add(new Pessoa(nome, dataNascimento, conta));
                    }
                    while (true)
                    {
                        Console.WriteLine("Você deseja criar outra conta? (sim = 1 ou não = 2)");
                        if (int.TryParse(Console.ReadLine(), out int outraConta) && (outraConta == 1 || outraConta == 2))
                        {
                            if (outraConta == 1) { break; }
                            else 
                            {
                                auxiliar = false;
                                break; 
                            }
                        }
                        else { Console.WriteLine("Entrada invalida, tente novamente"); }
                    }
                } while (auxiliar);
                
            }
            MostrarDecrescenteContaAplicacao(listaDePessoas);
            MostrarCrescenteContaPoupanca(listaDePessoas);
            MostrarDecrescenteContaCorrente(listaDePessoas);
        }
        public static void MostrarDecrescenteContaAplicacao(List<Pessoa> listaDePessoas)
        {
            var contasAuxiliar = new List<Conta>();
            foreach (var pessoa in listaDePessoas)
            {
                foreach (var conta in pessoa.ListaDeContas)
                {
                    if (conta is ContaAplicacao)
                    {
                        ContaAplicacao contaAplicacao = (ContaAplicacao)conta;
                        var novaConta = new Conta(contaAplicacao.SaldoRentabilizado, pessoa.Nome);
                        contasAuxiliar.Add(novaConta);
                    }
                }
            }
            var total = contasAuxiliar.OrderByDescending(item => item.SaldoRentabilizado);
            Console.WriteLine("Sequencia decrescente de conta aplicação:") ;
            foreach (var conta in total)
            {
                Console.WriteLine($"Nome: {conta.Nome} Saldo: {conta.SaldoRentabilizado} ");
            }
        }
        public static void MostrarCrescenteContaPoupanca(List<Pessoa> listaDePessoas)
        {
            var contasAuxiliar = new List<Conta>();
            foreach (var pessoa in listaDePessoas)
            {
                foreach (var conta in pessoa.ListaDeContas)
                {
                    if (conta is ContaPoupanca)
                    {
                        ContaPoupanca contaPoupanca = (ContaPoupanca)conta;
                        var novaConta = new Conta(contaPoupanca.SaldoRentabilizado, pessoa.Nome);
                        contasAuxiliar.Add(novaConta);
                    }
                }
            }
            var total = contasAuxiliar.OrderBy(item => item.SaldoRentabilizado);
            Console.WriteLine("Sequencia crescente de conta poupanca:");
            foreach (var conta in total)
            {
                Console.WriteLine($"Nome: {conta.Nome} Saldo: {conta.SaldoRentabilizado} ");
            }
        }

        public static void MostrarDecrescenteContaCorrente(List<Pessoa> listaDePessoas)
        {
            var contasAuxiliar = new List<Conta>();
            foreach (var pessoa in listaDePessoas)
            {
                foreach (var conta in pessoa.ListaDeContas)
                {
                    if (conta is ContaCorrente)
                    {
                        ContaCorrente contaCorrente = (ContaCorrente)conta;
                        var novaConta = new Conta(pessoa.Nome, contaCorrente.Saldo);
                        contasAuxiliar.Add(novaConta);
                    }
                }
            }
            var total = contasAuxiliar.OrderByDescending(item => item.Saldo);
            Console.WriteLine("Sequencia decrescente de conta Corrente:");
            foreach (var conta in total)
            {
                Console.WriteLine($"Nome: {conta.Nome} Saldo: {conta.Saldo} ");
            }
        }
    }
}