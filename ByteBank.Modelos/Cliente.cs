using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente 
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, string profissao)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Profissao = profissao ?? throw new ArgumentNullException(nameof(profissao));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public bool Equals(Cliente other)
        {
            return other != null &&
                   Nome == other.Nome &&
                   Cpf == other.Cpf &&
                   Profissao == other.Profissao;
        }

        public override int GetHashCode()
        {
            var hashCode = 520494327;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cpf);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Profissao);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, CPF: {Cpf}, Profissão: {Profissao}";
        }
    }



}
