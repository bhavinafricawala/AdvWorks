using AdventureWorks.Data.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace AdventureWorks.Data
{
    public class FakeConnection : IConnection
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection();
        }
    }
}
