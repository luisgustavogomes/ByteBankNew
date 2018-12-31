using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Format
    {
        public static string FormatDouble(double valor)
        {
            return "R$ " + String.Format("{0:N}", valor);
        }
    }
}
