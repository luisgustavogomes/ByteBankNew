using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    /// <summary>
    /// Define a criação da classe Extrator para URL's
    /// </summary>
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;

        public string Url { get; }
        /// <summary>
        /// Criar instancia da classe com o argumento <see cref="Url"/>.
        /// </summary>
        /// <param name="url">Representa o valor da <paramref name="url"/> para extração.</param>
        /// <exception cref="ArgumentNullException">O parametro <paramref name="url"/> não pode ser nulo.</exception>
        /// <exception cref="ArgumentException">O parametro <paramref name="url"/> não pode ser vazio.</exception>
        public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser uma nulo ou vazia", nameof(url));
            }
            _argumentos = url.Substring(url.IndexOf('?') + 1);
            Url = url;
        }


        public string GetValor(string nomeParametro)
        {
            nomeParametro = (nomeParametro + "=").ToUpper();
            int indiceInicioParametro = _argumentos.ToUpper().IndexOf(nomeParametro);

            string resultado = _argumentos.Substring(indiceInicioParametro + nomeParametro.Length);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
            {
                return resultado;
            }
            return resultado.Remove(indiceEComercial);
        }

       
    }
}
