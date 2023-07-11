using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.UnitOfWorks
{
    public interface IUnitOfWorkService
    {
        Task CommitAsync();
        void Commit();
    }
}
