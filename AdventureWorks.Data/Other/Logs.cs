using AdventureWorks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Other
{
    public class Logs : ILogs
    {
        public void Handle(Exception ex)
        {
            File.AppendAllText(@"D:\Project\AdvWorks\Logs\Logs.txt", DateTime.Now.ToString() + ":" + ex.ToString());
        }
    }
}
