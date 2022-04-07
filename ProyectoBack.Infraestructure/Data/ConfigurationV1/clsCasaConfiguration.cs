using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ProyectoBack.Core.Entities.v1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsCasaConfiguration : IEntityTypeConfiguration<clsCasa>
    {
        public void Configure(EntityTypeBuilder<clsCasa> builder)
        {
            builder.ToTable("tblCasa");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.nombre).HasColumnName("nombre");
            builder.Property(e => e.fechaModificacion).HasColumnName("fechaModificacion");
            builder.Property(e => e.fechaCreacion).HasColumnName("fechaCreacion");
        }
    }
}
