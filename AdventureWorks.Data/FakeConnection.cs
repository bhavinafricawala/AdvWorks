using AdventureWorks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
