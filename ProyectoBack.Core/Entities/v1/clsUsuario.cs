using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsUsuario : BaseEntity<int>
    {
        public string usuario { get; set; }
        public string password { get; set; }
    }
}
