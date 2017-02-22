using AdventureWorks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data
{
    public class DbConnection : IConnection
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=AdvWorks;Persist Security Info=True;User ID=sa;Password=sa");
        }
    }
}
