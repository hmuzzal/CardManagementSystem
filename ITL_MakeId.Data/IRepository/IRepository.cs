using System.Collections.Generic;

namespace ITL_MakeId.Data.IRepository
{

    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        List<T> GetAll();
        bool Update(T entity);

        bool Delete(T entity);

        T GetById(int id);
    }
}
