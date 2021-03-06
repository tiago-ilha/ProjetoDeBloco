﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class AlunoVM
    {
        public Guid Id { get; set; }   
        public long? Matricula { get; set; }

        [Required(ErrorMessage = "Informe o nome do Aluno!")]
        [MinLength(5, ErrorMessage = "Informe o nome do Aluno com no mínimo 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Informe o nome do Aluno com no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Display(Name="E-mail")]
        [Required(ErrorMessage = "Informe um email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Data de nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }

    public class TurmaAlunoVM
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
