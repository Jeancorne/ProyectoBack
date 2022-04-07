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
    class clsUsuarioConfiguration : IEntityTypeConfiguration<clsUsuario>
    {
        public void Configure(EntityTypeBuilder<clsUsuario> builder)
        {
            builder.ToTable("tblUsuario");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");                        
            builder.Property(e => e.usuario).HasColumnName("usuario");
            builder.Property(e => e.password).HasColumnName("password");
        }
    }
}
