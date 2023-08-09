using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.ServiceLibrary.Contracts.Contracts
{
    public interface IDeleteBeeService
    {
        bool DeleteBee(int id);
    }
}
