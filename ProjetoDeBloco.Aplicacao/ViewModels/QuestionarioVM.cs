﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class QuestionarioVM
    {
        public Guid Id { get; set; }
        public string Pergunta { get; set; }

        public IList<RespostaVM> Respostas { get; set; }
    }
}
