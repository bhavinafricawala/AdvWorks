using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Interfaces
{
    public interface ILogs
    {
        void Handle(Exception ex);
    }
}
