using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Mail;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Api.Models;

namespace ProjetoDeBloco.Api.Controllers
{
    public class AvaliacaoController : ApiController
    {
        private IAvaliacaoRepositorio _repAvaliacao;
        private IProfessorRepositorio _repProfessor;
        private IQuestaoRepositorio _repQuestao;

        private HttpResponseMessage response;

        public AvaliacaoController(IAvaliacaoRepositorio repAvaliacao, IProfessorRepositorio repProfessor, IQuestaoRepositorio repQuestao)
        {
            _repAvaliacao = repAvaliacao;
            _repProfessor = repProfessor;
            _repQuestao = repQuestao;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            response = new HttpResponseMessage();

            try
            {
                var listaAvaliacoes = new List<Avaliacao>();

                foreach (var item in _repAvaliacao.ObterPor())
                {
                    var professor = _repProfessor.ObterPor(item.turma.ProfessorID);

                    item.turma.Professor = professor;

                    listaAvaliacoes.Add(item);
                }

                var listaDeAvaliacoes = from avaliacao in listaAvaliacoes
                                        select new
                                        {
                                            Id = avaliacao.Id,
                                            DataInicio = avaliacao.dtInicio,
                                            DataFim = avaliacao.dtFim,
                                            ObjetivoAvaliacao = avaliacao.objAvaliacao,
                                            IdentificadorTurma = avaliacao.turma.Identificador,
                                            NomeProfessor = avaliacao.turma.Professor.Nome,
                                            NomeDoModulo = avaliacao.turma.Modulo.Nome,
                                            NomeDoBloco = avaliacao.turma.Modulo.Bloco.Nome,
                                            NomeDoCurso = avaliacao.turma.Modulo.Bloco.Curso.Nome
                                        };

                if (listaDeAvaliacoes.Count() > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, listaDeAvaliacoes);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent, "Nenhum registro foi encontrado!");
                }
            }
            catch (DbException e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            var tarefa = new TaskCompletionSource<HttpResponseMessage>();
            tarefa.SetResult(response);

            return tarefa.Task;
        }

        // GET: api/Avaliacao/5
        [HttpGet]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            response = new HttpResponseMessage();

            try
            {
                var avaliacaoBase = _repAvaliacao.ObterPor(id);

                var professor = _repProfessor.ObterPor(avaliacaoBase.turma.ProfessorID);

                ProfessorModel professorModel = new ProfessorModel{
                    Nome = professor.Nome
                };

                AvaliacaoModel model = new AvaliacaoModel
                {
                    Id = avaliacaoBase.Id,
                    DataInicio = avaliacaoBase.dtInicio,
                    DataFim = avaliacaoBase.dtFim,
                    Objetivo = avaliacaoBase.objAvaliacao,
                    Turma = new TurmaModel
                    {
                        Identificador = avaliacaoBase.turma.Identificador,
                        Professor = professorModel,
                        Modulo = new ModuloModel
                        {
                            Nome = avaliacaoBase.turma.Modulo.Nome,
                            Bloco = new BlocoModel
                            {
                                Nome = avaliacaoBase.turma.Modulo.Bloco.Nome
                            }
                        }
                    }
                };

                if (model != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, avaliacaoBase);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent, "Registro não foi encontrado!");
                }
            }
            catch (DbException e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            var tarefa = new TaskCompletionSource<HttpResponseMessage>();
            tarefa.SetResult(response);

            return tarefa.Task;
        }

        [HttpPut]
        public HttpResponseMessage EnviarEmailsComAvaliacao(Guid Id)
        {
            response = new HttpResponseMessage();

            try
            {
                var avaliacaoBase = _repAvaliacao.ObterPor(Id);

                if (avaliacaoBase == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Avaliação não foi localizado!");
                }
                else
                {
                    foreach (var item in avaliacaoBase.turma.Alunos)
                    {
                        StringBuilder mensagem = new StringBuilder();
                        mensagem.Append("<p>Olá senhor " + item.Nome + "!</p>");
                        mensagem.Append("<p>Nossas avaliações já estão abertas, para que você possa nós avaliar.</p>");
                        mensagem.Append("<p>Gostariamos da sua ajuda para uma noção se estamos lhe proporcionando o conhecimento esperado.</p>");

                        EnviarEmail(item.Email, "Venha nos avaliar!", mensagem.ToString());
                    }
                }
            }
            catch (DbException e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        private void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            string conta = ConfigurationManager.AppSettings["email"];
            string senha = ConfigurationManager.AppSettings["senhaEmail"];
            string smtp = ConfigurationManager.AppSettings["smtp"];
            int porta = Convert.ToInt32(ConfigurationManager.AppSettings["Porta"]);

            MailMessage mensagemEmail = new MailMessage(conta, destinatario);

            mensagemEmail.Subject = assunto;
            mensagemEmail.Body = mensagem;

            SmtpClient configuracaoEmail = new SmtpClient(conta, porta);

            configuracaoEmail.EnableSsl = true;
            configuracaoEmail.Credentials = new NetworkCredential(conta, senha);
            configuracaoEmail.Send(mensagemEmail);
        }
    }
}
