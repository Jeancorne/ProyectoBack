
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProyectoBack.Application.DTOs.v1
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Contraseña obligatorio")]
        public string password { get; set; }
    }
}
