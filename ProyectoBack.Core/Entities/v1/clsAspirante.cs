using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsAspirante : BaseEntity<int>
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string identificacion { get; set; }
        public string edad { get; set; }
        public int idCasa { get; set; }
        public virtual clsCasa idCasaNavigation { get; set; }
    }
}
