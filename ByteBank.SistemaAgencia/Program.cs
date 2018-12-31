
using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(847, 847);
            new ContaCorrente(874, 876);
            Console.WriteLine("Número: " + conta.Numero + "\nAgencia: " + conta.Agencia);

            Console.ReadLine();
        }
    }
}
