using Hive.Infrastructure.Contracts.Models;
using Hive.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Infrastructure.Contracts.Mapper
{
    public interface IInfrastructureMapper
    {
        BeeEntity ToBeeEntity(BeeDTO dto);
        BeeDTO ToBeeDTO(BeeEntity ent);
    }
}
