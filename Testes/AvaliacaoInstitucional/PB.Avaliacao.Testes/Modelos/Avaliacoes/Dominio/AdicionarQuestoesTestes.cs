using NUnit.Framework;
using PB.Avaliacoes.Modelos.Avaliacoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Avaliacoes.Testes.Modelos.Avaliacoes.Dominio
{
    [TestFixture]
    public class AdicionarQuestoesTestes
    {
        [Test]
        public void DevePermitirIncluirUmaQuestao()
        {
            var listaDeQuestoes = new List<Questao>()
            {
                new Questao("Quantos anos você tem?")
            };

            var avaliacao = new PB.Avaliacoes.Modelos.Avaliacoes.Dominio.Avaliacao();
            avaliacao.AdicionarQuestoes(listaDeQuestoes);

            Assert.True(avaliacao.Questoes.Count == 1);
        }        

        [Test]
        public void DeveGerarErroAoIncluirQuestoesRepetidas()
        {
            var listaDeQuestoes = new List<Questao>()
            {
                new Questao("Quantos anos você vai fazer?"),
                new Questao("Quantos anos você vai fazer?")
            };

            var avaliacao = new PB.Avaliacoes.Modelos.Avaliacoes.Dominio.Avaliacao();

            Assert.Throws<Exception>(() =>
            {
                avaliacao.AdicionarQuestoes(listaDeQuestoes);
            });

            Assert.True(avaliacao.Questoes.Count == 1);
        }

        [Test]
        public void DeveGerarErroQuandoNenhumaQuestaoForInformada()
        {
            var listaDeQuestoes = new List<Questao>();

            var avaliacao = new PB.Avaliacoes.Modelos.Avaliacoes.Dominio.Avaliacao();

            Assert.Throws<Exception>(() =>
            {
                avaliacao.AdicionarQuestoes(listaDeQuestoes);
            });

            Assert.True(avaliacao.Questoes.Count == 0);
        }
    }
}
