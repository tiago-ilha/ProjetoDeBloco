using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoDeBloco.Api.Controllers
{
    public class AvaliacaoController : ApiController
    {
        private IAvaliacaoServico _Servico;
        private HttpResponseMessage response;

        public AvaliacaoController(IAvaliacaoServico servico)
        {
            _Servico = servico;
        }

        public HttpResponseMessage Get()
        {
            response = new HttpResponseMessage();

            try
            {
                var listaDeAvaliacoes = _Servico.ListarTodos();

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

            return response;
        }

        // GET: api/Avaliacao/5
        public HttpResponseMessage Get(Guid id)
        {
            response = new HttpResponseMessage();

            try
            {
                var avaliacaoBase = _Servico.BuscarPorId(id);

                if (avaliacaoBase != null)
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

            return response;
        }

        // POST: api/Avaliacao
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Avaliacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Avaliacao/5
        public void Delete(int id)
        {
        }
    }
}
