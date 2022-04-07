using ProyectoBack.Application.DTOs.v1;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.PUT;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IServicio
    {
        Task<clsAspirante> crearAspirante(clsAspiranteDTO aspirante);
        Task<clsAspirante> actualizarAspirante(clsAspirantePUT aspirante);
        Task<List<clsAspirante>> obtenerAspirantes();
        Task<bool> eliminarAspirante(int id);
        Task<clsUsuario> obtenerUsuario(string usuario, string password);        
        Task<clsUsuario> crearUsuario(LoginModelDTO login);

    }
}
