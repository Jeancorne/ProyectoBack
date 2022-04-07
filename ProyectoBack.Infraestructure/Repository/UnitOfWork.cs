
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using ProyectoBack.Infraestructure.Repository.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBack.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        //Context
        private readonly DBContext _context;

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }              
        private readonly IRepository<clsAspirante, int> _clsAspirante;
        private readonly IRepository<clsCasa, int> _clsCasa;
        private readonly IRepository<clsUsuario, int> _clsUsuario;

        //Instancias genérica
        public IRepository<clsUsuario, int> clsUsuario =>
            _clsUsuario ?? new BaseRepository<clsUsuario, int>(_context);
        public IRepository<clsAspirante, int> clsAspirante =>
            _clsAspirante ?? new BaseRepository<clsAspirante, int>(_context);

        public IRepository<clsCasa, int> clsCasa =>
            _clsCasa ?? new BaseRepository<clsCasa, int>(_context);

 
        //Repositorios manuales
        private readonly IServicioRepository _IServicioRepository;
        //Instancias manuales
        public IServicioRepository IServicioRepository =>
            _IServicioRepository ?? new ServicioRepository(_context);




    }
}
