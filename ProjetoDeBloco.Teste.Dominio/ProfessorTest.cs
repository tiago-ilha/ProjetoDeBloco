using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;

namespace ProjetoDeBloco.Teste.Dominio
{
    [TestClass]
    public class ProfessorTest
    {
        [TestMethod]
        public void Cadastrando_Um_Professor()
        {
            var professor = new Professor("Teste", new DateTime(1985,03,01), "Teste", 2011);

            //professor.Editar()

        }
    }
}
