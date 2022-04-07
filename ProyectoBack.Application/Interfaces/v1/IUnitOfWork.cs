
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IUnitOfWork : IDisposable
    {
        void saveChanges();
        Task SaveChangesAsync();
                
        IRepository<clsAspirante, int> clsAspirante { get; }
        IRepository<clsCasa, int> clsCasa { get; }
        IRepository<clsUsuario, int> clsUsuario { get; }
        //Repositorios manuales
        IServicioRepository IServicioRepository { get; }


    }
}
