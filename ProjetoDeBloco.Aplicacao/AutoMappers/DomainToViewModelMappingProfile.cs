using AutoMapper;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.AutoMappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Curso, CursoVM>();
            CreateMap<Bloco, BlocoVM>();
            CreateMap<Modulo, ModuloVM>();
            CreateMap<Professor, ProfessorVM>();
            CreateMap<Aluno, AlunoVM>();
            CreateMap<Turma, TurmaVM>();            
            CreateMap<Questao, QuestaoVM>();
            CreateMap<Avaliacao, AvaliacaoVM>();
			CreateMap<Usuario, UsuarioVM>();
        }
    }
}
