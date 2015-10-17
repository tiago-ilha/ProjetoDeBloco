﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Administrador : Pessoa
    {
        protected Administrador() { }

        public Administrador(string nome, DateTime dataNascimento, string email)
            : base(nome, dataNascimento, email)
        {

        }

        public Guid IdAdministrador { get; set; }
    }
}
