using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsCasa : BaseEntity<int>
    {
        public string nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<clsAspirante> clsAspirante { get; set; }
    }
}
