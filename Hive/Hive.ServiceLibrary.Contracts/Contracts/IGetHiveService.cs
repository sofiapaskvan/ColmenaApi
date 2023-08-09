using Hive.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.ServiceLibrary.Contracts.Contracts
{
    public interface IGetHiveService
    {
        IEnumerable<BeeEntity> GetFilteredByIncidents(int minIncidents, int maxIncidents);
        IEnumerable<BeeEntity> GetFilteredByState(bool searchedState);
        IEnumerable<BeeEntity> GetOrderedByAscending(string factor);
        IEnumerable<BeeEntity> GetOrderedByDescending(string factor);
    }
}
