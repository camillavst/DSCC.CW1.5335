using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Repositories
{
    public interface IRoomRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);
        void Create(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
