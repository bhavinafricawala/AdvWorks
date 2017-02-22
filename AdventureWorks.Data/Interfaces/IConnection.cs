using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace AdventureWorks.Data.Interfaces
{
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
