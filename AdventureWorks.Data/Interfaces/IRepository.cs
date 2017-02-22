using System.Collections.Generic;

namespace AdventureWorks.Data.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();

        T GetById(int id);

        int Insert(T product);

        int Update(T product);

        int Delete(T product);

    }
}
