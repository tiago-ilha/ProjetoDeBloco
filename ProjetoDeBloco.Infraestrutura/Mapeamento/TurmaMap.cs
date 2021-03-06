﻿using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            ToTable("Turma");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Identificador).HasColumnType("varchar").HasMaxLength(10).IsRequired();            

            HasRequired(x => x.Professor)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.ProfessorID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Alunos)
                .WithMany(x => x.Turmas).Map(x =>
                {
                    x.ToTable("TurmaAluno");
                    x.MapLeftKey("Turma_Id");
                    x.MapRightKey("Aluno_Id");
                });
        }
    }
}
