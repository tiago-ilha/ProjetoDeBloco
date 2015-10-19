using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Enum;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Pessoa
    {
        protected Pessoa(){}

        public Pessoa(string nome, DateTime dataNascimento)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome!");
            if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (dataNascimento == null) throw new Exception("Informe uma data de nascimento!");

            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public Guid Id { get; protected set; }
        public long Matricula { get; set; }
        public string Nome { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public bool Ativo { get; protected set; }

        public void Ativar()
        {
            if (Ativo == true)
                throw new Exception("Essa pessoa está ativada!");

            Ativo = true;
        }

        public void Desativar()
        {
            if (Ativo == false)
                throw new Exception("Essa pessoa está desativada!");

            Ativo = false;
        }
    }
}
