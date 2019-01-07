
using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ByteBank.SistemaAgencia.Extencoes;
using Humanizer;
using ByteBank.SistemaAgencia.Comparadores;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(123,1234),
                new ContaCorrente(124,1235),
                new ContaCorrente(321,5432)
            };

            //contas.Sort(); --> Chamar a implementação IComparable
            contas.Sort(new ComparadorContaCorrentePorAgencia());

            contas.ForEach(c => Console.WriteLine(c));

            Console.ReadLine();
        }

        private static void TestaSortInteiros()
        {
            var listaInteiros = new List<int>();
            listaInteiros.AddValues(1, 3, 5, 7, 9, 11, 13, 15, 14, 12, 10, 8, 6, 4, 2);
            listaInteiros.ForEach(l => Console.WriteLine(l));

            Separador();

            listaInteiros.Sort();
            listaInteiros.ForEach(l => Console.WriteLine(l));
        }

        private static void TrabalhandoComMetodosExtencoes()
        {
            List<ContaCorrente> contas = new List<ContaCorrente>();
            ContaCorrente c1 = new ContaCorrente(agencia: 123, numero: 12345);
            ContaCorrente c2 = new ContaCorrente(agencia: 123, numero: 12346);
            contas.AddValues(c1, c2);

            foreach (var item in contas)
            {
                Console.WriteLine(item);
            }

        }

        private static void TrabalhandoComNullEmValores()
        {
            int? numero = null;
            Console.WriteLine(numero);
        }

        private static void TrabalhandoComListaManualmente()
        {
            List<ContaCorrente> contas = new List<ContaCorrente>
            {
                new ContaCorrente(123, 12345),
                new ContaCorrente(123, 12346),
                new ContaCorrente(123, 12347)
            };

            foreach (var item in contas)
            {
                Console.WriteLine(item);
            }

        }

        private static void TrabalhandoComArry2()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                        {
                new ContaCorrente(123, 12345),
                new ContaCorrente(123, 12346),
                new ContaCorrente(123, 12347)
                        };

            foreach (var item in contas)
            {
                Console.WriteLine(item);
            }
        }

        private static void TrabalhandoComArray()
        {
            int[] idades = new int[5];

            idades[0] = 10;
            idades[1] = 90;
            idades[2] = 45;
            idades[3] = 32;
            idades[4] = 18;

            foreach (var item in idades)
            {
                Console.WriteLine("Idade: " + item);

            }

            Separador();

            for (int i = 0; i < idades.Length; i++)
            {
                Console.WriteLine("Idade: " + idades[i]);
            }
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

        private static void GetDatas()
        {
            DateTime dataFimPagamento = new DateTime(2019, 1, 04);
            DateTime dataAtual = DateTime.Now;
            //TimeSpan diff = dataFimPagamento - dataAtual;
            TimeSpan diff = TimeSpan.FromMinutes(60 * 24);

            Console.WriteLine("Data fim pagamento: " + dataFimPagamento);
            Console.WriteLine("Data atual: " + dataAtual);
            Console.WriteLine("Diferença de datas: " + TimeSpanHumanizeExtensions.Humanize(diff));

            Console.ReadLine();
        }

        private static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        {
            if (timeSpan.Days > 30)
            {
                int quantidadeMeses = timeSpan.Days / 30;
                if (quantidadeMeses == 1)
                {
                    return quantidadeMeses + " mês";
                }
                return quantidadeMeses + " meses";
            }
            else if (timeSpan.Days > 7)
            {
                int quantidadeSemanas = timeSpan.Days / 7;
                if (quantidadeSemanas == 1)
                {
                    return quantidadeSemanas + " semana";
                }
                return quantidadeSemanas + " semanas";
            }
            return timeSpan.Days + " Dias";
        }
    }
}
