using AdventureWorks.Business.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
