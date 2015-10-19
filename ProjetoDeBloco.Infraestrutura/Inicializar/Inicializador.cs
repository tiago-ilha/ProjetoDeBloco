using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Inicializar
{
    public class Inicializador : DropCreateDatabaseAlways<ProjetoDeBlocoDataContext>
    {
        protected override void Seed(ProjetoDeBlocoDataContext context)
        {

            using (var contexto = new ProjetoDeBlocoDataContext())
            {
                var aluno = new Aluno("Tiago", new DateTime(1990, 01, 12), "tiago@gmail.com");
                contexto.Alunos.Add(aluno);

                var professor = new Professor("Vinicius", new DateTime(1985, 04, 16), "vinicius@gmail.com", "Analista de Sistemas", 2005);
                contexto.Professores.Add(professor);

                var curso = new Curso("0001", "MIT de Engenharia de Software");
                contexto.Cursos.Add(curso);

                contexto.SaveChanges();
            }

            
        }
    }
}
