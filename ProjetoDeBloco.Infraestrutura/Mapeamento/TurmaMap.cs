<<<<<<< HEAD
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
                .HasForeignKey(x => x.IdProfessor)
                .WillCascadeOnDelete(false);
        }
    }
}
=======
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
                .HasForeignKey(x => new { x.ProfessorID});

            HasRequired(x => x.Modulo)
                .WithMany().HasForeignKey(x => new { x.ModuloID});                

            HasMany(x => x.Alunos).WithMany();
        }
    }
}
>>>>>>> 783aa6575c0558e368e19a68b44aeb2233109a24
