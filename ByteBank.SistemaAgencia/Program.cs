
using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2019,1,04);
            DateTime dataAtual = DateTime.Now;
            //TimeSpan diff = dataFimPagamento - dataAtual;
            TimeSpan diff = TimeSpan.FromMinutes(60*24);

            Console.WriteLine("Data fim pagamento: " + dataFimPagamento);
            Console.WriteLine("Data atual: " + dataAtual);
            Console.WriteLine("Diferença de datas: " + TimeSpanHumanizeExtensions.Humanize(diff) );


            Console.ReadLine();
        }

        //public static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        //{
        //    if (timeSpan.Days > 30 )
        //    {
        //        int quantidadeMeses = timeSpan.Days / 30;
        //        if (quantidadeMeses == 1 )
        //        {
        //            return quantidadeMeses + " mês";
        //        }
        //        return quantidadeMeses + " meses";
        //    }
        //    else if (timeSpan.Days > 7)
        //    {
        //        int quantidadeSemanas = timeSpan.Days / 7;
        //        if (quantidadeSemanas == 1)
        //        {
        //            return quantidadeSemanas + " semana";
        //        }
        //        return quantidadeSemanas + " semanas";
        //    }
        //    return timeSpan.Days + " Dias";
        //}
    }
}
