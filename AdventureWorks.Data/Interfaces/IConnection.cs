using System.Data;

namespace AdventureWorks.Data.Interfaces
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
