using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytebankEx
{
    class SaldoInsuficienteException : OperacaoFinanceiraException
    {

        public double Saldo { get;}
        public double ValorSaque { get;}

        public SaldoInsuficienteException(double saldo, double valorSaque) 
            : this ("Tentativa de saque do valor de " + Program.FormatDouble(valorSaque) + 
                    " em uma conta com saldo de " + Program.FormatDouble(saldo))
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException()
        {
        }

        public SaldoInsuficienteException(string message) 
            : base(message)
        {
        }

        public SaldoInsuficienteException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        
    }
}
