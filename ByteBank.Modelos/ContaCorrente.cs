using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma conta conrrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }

        public Cliente Cliente { get; set; }

        public int ContadorSaqueNaoPermitidos { get; private set; }
        public int ContadorTransferenciaNaoPermitodas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instâncias de ContaCorrete com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"></see> deve possuir um valor maior que zero(0).</param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> deve possuir um valor maior que zero(0).</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("Agencia devem ser maior que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O número devem ser maior que 0.", nameof(numero));
            }
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e a atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <param name="valor">Representa o valor do saque, valor deve ser maior que zero (0) e não pode ser maior que o valor do <see cref="Saldo"/>.</param>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor menor ou igual a zero(0) é utilizado no argumento <paramref name="valor"/>.></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de saque é maior que o <see cref="Saldo"/>.</exception>
        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor " + Format.FormatDouble(valor) + " inválido para o saque.", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaqueNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            _saldo -= valor;
            return;

        }

        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                _saldo += valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Transferir(ContaCorrente contaCorrenteDestino, double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor " + Format.FormatDouble(valor) + " inválido para transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciaNaoPermitodas++;
                throw new OperacaoFinanceiraException("Operação sem saldo", e);
            }

            contaCorrenteDestino.Depositar(valor);
        }

    }

}
