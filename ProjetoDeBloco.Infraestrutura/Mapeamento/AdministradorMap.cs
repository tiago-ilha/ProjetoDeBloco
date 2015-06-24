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
    public class AdministradorMap : EntityTypeConfiguration<Administrador>
    {
        public AdministradorMap()
        {
            ToTable("Administrador");

            Property(administrador => administrador.IdAdministrador).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
