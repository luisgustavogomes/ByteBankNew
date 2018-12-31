using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.Modelos
{
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
