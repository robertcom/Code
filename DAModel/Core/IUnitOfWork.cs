using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAModel.Core.Repositories;

namespace DAModel.Core
{
    public interface IUnitOfWork
    {
        IProfileRepository Profiles { get; }
        int Complete();
    }
}
