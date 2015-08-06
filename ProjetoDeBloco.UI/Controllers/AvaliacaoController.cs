using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AvaliacaoController : Controller
    { 

        public IAvaliacaoServico _servicoAvaliacao;
        public ITurmaServico _servicoTurma;

        public AvaliacaoController()
        {

        }
        //
        // GET: /Avaliacao/
        public ActionResult Index()
        {
            return View();
        }
    }
}