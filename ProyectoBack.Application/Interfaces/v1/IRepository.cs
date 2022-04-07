using ProyectoBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IRepository<T, IdType> where T : BaseEntity<IdType>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(IdType id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(IdType id);
        Task AddRange(ICollection<T> entity);
        void UpdateRange(ICollection<T> entity);
        Task Where(Func<object, object> p);
    }
}
