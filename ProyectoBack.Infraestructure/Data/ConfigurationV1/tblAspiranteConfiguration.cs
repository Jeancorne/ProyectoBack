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
    class tblAspiranteConfiguration : IEntityTypeConfiguration<clsAspirante>
    {
        public void Configure(EntityTypeBuilder<clsAspirante> builder)
        {
            builder.ToTable("tblAspirante");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.nombre).HasColumnName("nombre");
            builder.Property(e => e.apellido).HasColumnName("apellido");
            builder.Property(e => e.identificacion).HasColumnName("identificacion");
            builder.Property(e => e.edad).HasColumnName("edad");
            builder.Property(e => e.idCasa).HasColumnName("idCasa");
            builder.Property(e => e.fechaModificacion).HasColumnName("fechaModificacion");
            builder.Property(e => e.fechaCreacion).HasColumnName("fechaCreacion");


            builder.HasOne(d => d.idCasaNavigation)
                 .WithMany(x => x.clsAspirante)
                 .HasForeignKey(d => d.idCasa);

        }
    }
}
