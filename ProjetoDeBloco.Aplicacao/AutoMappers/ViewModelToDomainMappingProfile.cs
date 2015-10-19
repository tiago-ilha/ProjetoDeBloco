using AutoMapper;
using ProjetoDeBloco.Aplicacao.ViewModels;
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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<CursoVM, Curso>();
            CreateMap<BlocoVM, Bloco>();
            CreateMap<ModuloVM, Modulo>();
            CreateMap<ProfessorVM, Professor>();
            CreateMap<AlunoVM, Aluno>();
            CreateMap<TurmaVM, Turma>();            
            CreateMap<QuestaoVM, Questao>();
            CreateMap<AvaliacaoVM, Avaliacao>();
        }
    }
}
