using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Mapeamento
{
    public class PessoaMap :  EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");

            Property(pessoa => pessoa.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(pessoa => pessoa.Nome).HasColumnType("varchar").HasMaxLength(80).IsRequired();
            Property(pessoa => pessoa.Matricula).HasColumnType("bigint");
            Property(pessoa => pessoa.DataNascimento).HasColumnType("datetime").IsRequired();
        }
    }
}
