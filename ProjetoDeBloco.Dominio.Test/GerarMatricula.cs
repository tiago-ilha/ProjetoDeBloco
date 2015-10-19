using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Servicos;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;

namespace ProjetoDeBloco.Dominio.Test
{
    [TestClass]
    public class GerarMatricula
    {   

        [TestMethod]
        public void GerarMatriculaParaPessoa()
        {
            Aluno aluno = new Aluno("Tiago", new DateTime(1990, 01, 16));

            var utlimaMatricula = 201500000000001;

            var novaMatricula = ServicoGeradorDeMatricula.Gerar(aluno, utlimaMatricula);

            Assert.AreEqual(201500000000002, novaMatricula);
        }

        [TestMethod]
        public void GerarMatriculaParaPrimeiraPessoa()
        {
            Aluno aluno = new Aluno("Tiago", new DateTime(1990, 01, 16));

            long utlimaMatricula = 0;

            var novaMatricula = ServicoGeradorDeMatricula.Gerar(aluno, utlimaMatricula);

            Assert.AreEqual(201500000000001, novaMatricula);
        }
    }
}
