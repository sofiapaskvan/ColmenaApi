using Hive.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.ServiceLibrary.Contracts.Contracts
{
    public interface IUpdateBeeService
    {
        bool UpdateBee(BeeEntity bee);
    }
}
