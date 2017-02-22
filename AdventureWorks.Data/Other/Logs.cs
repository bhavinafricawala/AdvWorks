using AdventureWorks.Data.Interfaces;
using System;
using System.IO;

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
