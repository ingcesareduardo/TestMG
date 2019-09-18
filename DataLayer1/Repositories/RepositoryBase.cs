using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Base;

namespace DataLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity, new()
    {
        public Task<IEnumerable<T>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
