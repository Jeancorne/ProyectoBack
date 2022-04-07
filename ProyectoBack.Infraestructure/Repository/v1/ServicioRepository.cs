using AppBack.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Repository.v1
{
    public class ServicioRepository : BaseRepository<clsUsuario, int>, IServicioRepository
    {
        public ServicioRepository(DBContext context) : base(context)
        {
        }

        public async Task<clsUsuario> obtenerUsuarios(string usuario)
        {
            var data = await _context.clsUsuario.Where(a => a.usuario == usuario.Trim()).FirstOrDefaultAsync();            
            return data;
        }
        public async Task<List<clsAspirante>> obtenerAspirantes()
        {
            var data = await _context.clsAspirante.Include(a => a.idCasaNavigation).ToListAsync();                                                
            return data;
        }

    }
}
