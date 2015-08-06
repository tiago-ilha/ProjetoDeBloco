﻿using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos.Interfaces
{
    public interface IAlunoServico : IAplicacaoBase<AlunoVM>
    {
        AlunoVM BuscarPorNome(string nome);
    }
}
