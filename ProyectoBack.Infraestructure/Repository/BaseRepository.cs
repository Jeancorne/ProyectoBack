using Microsoft.EntityFrameworkCore;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities;
using ProyectoBack.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBack.Infraestructure.Repository
{
    public class BaseRepository<T, IdType> : IRepository<T, IdType> where T : BaseEntity<IdType>
    {
        protected readonly DBContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(DBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(IdType id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(IdType id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }


        public async Task AddRange(ICollection<T> entity)
        {
            await _entities.AddRangeAsync(entity);
        }

        public void UpdateRange(ICollection<T> entity)
        {
            _entities.UpdateRange(entity);
        }

        public Task Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }        
    }
}
