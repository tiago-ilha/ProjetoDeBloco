using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class ModuloMap : EntityTypeConfiguration<Modulo>
    {
        public ModuloMap()
        {
            ToTable("Modulo");

            Property(modulo => modulo.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(modulo => modulo.Nome).HasColumnType("varchar").HasMaxLength(80).IsRequired();

            HasRequired(modulo => modulo.Bloco).WithMany().HasForeignKey(x => x.IdBloco);
            HasMany(modulo => modulo.Turmas).WithRequired(turma => turma.Modulo).HasForeignKey(x => x.IdModulo);
        }
    }
}
