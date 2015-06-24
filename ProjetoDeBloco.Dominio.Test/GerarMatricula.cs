using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Servicos;

namespace ProjetoDeBloco.Dominio.Test
{
    [TestClass]
    public class GerarMatricula
    {
        [TestMethod]
        public void GerarMatriculaParaPessoa()
        {
            Aluno aluno = new Aluno("Tiago", new DateTime(1990, 01, 16));

            ServicoGeradorDeMatricula.Gerar(aluno);
        }
    }
}
