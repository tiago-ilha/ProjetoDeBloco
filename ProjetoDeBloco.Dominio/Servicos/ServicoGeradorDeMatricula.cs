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
        public static long Gerar(Pessoa pessoa, long ultimaMatricula)
        {
            long matricula;

            if (pessoa.GetType() != typeof(Administrador))
            {
                if (ultimaMatricula == 0)
                    matricula = (DateTime.Now.Year * 100000000000) + 1;
                else
                    matricula = ultimaMatricula + 1;

                pessoa.Matricula = matricula;

                //Random codigo = new Random();

                //var ano = DateTime.Now.Year.ToString();
                //var numero = codigo.Next(999).ToString();

                //montarMatricula = ano + numero;

                //matricula = Convert.ToInt32(montarMatricula);
                //pessoa.Matricula = matricula;
            }

            return pessoa.Matricula;
        }
    }
}
