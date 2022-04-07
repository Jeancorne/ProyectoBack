using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Application.DTOs.v1.PUT
{
    public class clsAspirantePUT
    {
        [Required(ErrorMessage = "id es obligatorio")]
        public int id { get; set; }
        [Required(ErrorMessage = "nombre obligatorio"), StringLength(20)]
        public string nombre { get; set; }
        [Required(ErrorMessage = "apellido obligatorio"), StringLength(20)]
        public string apellido { get; set; }
        [Required(ErrorMessage = "identificacion obligatorio"), StringLength(20), RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string identificacion { get; set; }
        [Required(ErrorMessage = "edad obligatorio"), StringLength(2), RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public string edad { get; set; }
        [Required(ErrorMessage = "casa obligatorio")]
        public int idCasa { get; set; }
    }
}
