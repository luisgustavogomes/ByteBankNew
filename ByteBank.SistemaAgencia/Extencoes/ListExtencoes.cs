using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extencoes
{
    public static class ListExtencoes<T> 
    {
        public static void AddValues(this List<T> lista, params T[] itens)
        {
            foreach (var item in itens)
            {
                lista.Add(item);
            }
        }

    }
}
