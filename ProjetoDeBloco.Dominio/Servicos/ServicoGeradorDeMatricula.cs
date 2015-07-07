using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Servicos
{
    public static class ServicoGeradorDeMatricula
    {
        public static int Gerar(Pessoa pessoa)
        {
            var matricula = 0;
            string montarMatricula;

            if (pessoa.GetType() != typeof(Administrador))
            {
                Random codigo = new Random();

                var ano = DateTime.Now.Year.ToString();
                var numero = codigo.Next(999).ToString();

                montarMatricula = ano + numero;

                matricula = Convert.ToInt32(montarMatricula);
                pessoa.Matricula = matricula;
            }

            return matricula;
        }
    }
}
