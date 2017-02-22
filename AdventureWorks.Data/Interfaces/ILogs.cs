using System;

namespace AdventureWorks.Data.Interfaces
{
    public interface ILogs
    {
        void Handle(Exception ex);
    }
}
