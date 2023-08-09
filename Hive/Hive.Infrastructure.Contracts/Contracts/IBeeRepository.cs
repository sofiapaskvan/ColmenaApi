using Hive.Infrastructure.Contracts.Models;
using Hive.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Infrastructure.Contracts.Contracts
{
    public interface IBeeRepository
    {
        IEnumerable<BeeDTO> GetBees();
        bool AddBee(BeeDTO bee);
        bool DeleteBee(int id);
        bool UpdateBee(BeeDTO bee);
    }
}
