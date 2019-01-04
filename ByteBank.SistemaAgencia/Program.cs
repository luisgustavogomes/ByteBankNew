
using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
           


            Console.ReadLine();
        }

        private static void TesteRegex()
        {
            string mensagem = "Meu nome é luis 99999 9999";
            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            Match resultado = Regex.Match(mensagem, padrao);

            Console.WriteLine(resultado.Value);
        }

        private static void TestandoExtratorUrl()
        {
            string url = "paginas?moedaOrigem=real&moedaDestino=dolar&quantidade=12.00";

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(url);

            string vlr1 = extrator.GetValor("MoedaOrigem");


            Console.WriteLine("Url: " + url);
            Separador();
            Console.WriteLine("Vlr1: " + vlr1);

            Separador();

            string vlr2 = extrator.GetValor("moedaDestino");
            Console.WriteLine("Vlr2: " + vlr2);

            Separador();

            string vlr3 = extrator.GetValor("quantidade");
            Console.WriteLine("Vlr3: " + vlr3);
        }

        private static void Separador()
        {
            Console.WriteLine("--------------------------------------");
        }

        //private static void GetDatas()
        //{
        //    DateTime dataFimPagamento = new DateTime(2019, 1, 04);
        //    DateTime dataAtual = DateTime.Now;
        //    //TimeSpan diff = dataFimPagamento - dataAtual;
        //    TimeSpan diff = TimeSpan.FromMinutes(60 * 24);
        //
        //    Console.WriteLine("Data fim pagamento: " + dataFimPagamento);
        //    Console.WriteLine("Data atual: " + dataAtual);
        //    Console.WriteLine("Diferença de datas: " + TimeSpanHumanizeExtensions.Humanize(diff));
        //
        //    Console.ReadLine();
        //}

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
