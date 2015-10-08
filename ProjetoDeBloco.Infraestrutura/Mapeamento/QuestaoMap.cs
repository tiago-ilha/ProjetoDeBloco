using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class QuestaoMap: EntityTypeConfiguration<Questao>
    {
        public QuestaoMap()
        {
            ToTable("Questao");

            Property(avaliacao => avaliacao.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(questao => questao.PerguntaQuestao);

            Property(questao => questao.Resposta1);
            Property(questao => questao.Resposta2);
            Property(questao => questao.Resposta3);
            Property(questao => questao.Resposta4);
            Property(questao => questao.Resposta5);
        }       

    }
}
