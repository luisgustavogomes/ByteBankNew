using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytebankEx
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {
        }

        public OperacaoFinanceiraException(string mensagem) 
            : base(mensagem)
        {
        }

        public OperacaoFinanceiraException(string mensagem, Exception exceptionInterna) 
            : base(mensagem, exceptionInterna)
        {
        }

    }
}
