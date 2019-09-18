using BusinessLayer.Base;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity, new()
    {
        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
