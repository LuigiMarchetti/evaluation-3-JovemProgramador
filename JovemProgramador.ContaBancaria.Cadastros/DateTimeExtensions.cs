using System;

namespace JovemProgramador.ContaBancaria.Cadastros
{
    public static class DateTimeExtensions
    {
        public static int ObterDiferencaEmMeses(this DateTime dataInicial, DateTime dataFinal)
        {
            int quantidadeMeses = 0;
            var dataAuxiliar = new DateTime(dataInicial.Year, dataInicial.Month, 1);
            var dataComparativa = new DateTime(dataFinal.Year, dataFinal.Month, 1);

            while (dataAuxiliar < dataComparativa)
            {
                quantidadeMeses++;
                dataAuxiliar = dataAuxiliar.AddMonths(1);
            }

            return quantidadeMeses;
        }
        public static int ObterDiferencaEmAnos(this DateTime dataInicial, DateTime dataFinal)
        {
            int quantidadeAnos = 0;
            var dataAuxiliar = new DateTime(dataInicial.Year, dataInicial.Month, 1);
            var dataComparativa = new DateTime(dataFinal.Year, dataFinal.Month, 1);

            while (dataAuxiliar < dataComparativa)
            {
                quantidadeAnos++;
                dataAuxiliar = dataAuxiliar.AddYears(1);
            }

            return quantidadeAnos;
        }
    }
}
