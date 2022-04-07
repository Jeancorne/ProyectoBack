using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities
{
    public abstract class BaseEntity<IdType>
    {        
        public IdType id { get; set; }        
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }

    }
}
