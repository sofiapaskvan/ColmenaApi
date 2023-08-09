using Hive.Infrastructure.Contracts.Contracts;
using Hive.Infrastructure.Contracts.Mapper;
using Hive.Library.Models;
using Hive.ServiceLibrary.Contracts.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Hive.ServiceLibrary.Implementations.Implementations
{
    /// <summary>
    /// A service for filtering bee collections.
    /// </summary>
    public class GetHiveService : IGetHiveService
    { 
        private readonly IBeeRepository _beeRepository;
        private readonly IInfrastructureMapper _infrastructureMapper;

        /// <summary>
        /// Constructor for the filtered bee getter service.
        /// </summary>
        /// <param name="beeRepository">Bee repository.</param>
        /// <param name="infrastructureMapper">Mapper to adapt infrastructure to/from entity models objects.</param>
        public GetHiveService(IBeeRepository beeRepository, IInfrastructureMapper infrastructureMapper)
        {
            _beeRepository = beeRepository;
            _infrastructureMapper = infrastructureMapper;
        }
        /// <summary>
        /// Filters a bee collection in order to return a new collection including just the bees whose Incidents value
        /// is comprehended between both given parameter values.
        /// </summary>
        /// <param name="minIncidents">Minimum incidents the returned bees must have.</param>
        /// <param name="maxIncidents">Maximum incidents the returned bees must have</param>
        /// <returns>A new collection of bee entities.</returns>
        public IEnumerable<BeeEntity> GetFilteredByIncidents(int minIncidents, int maxIncidents)
        {
            var result = GetBeeEntities().Where(b => (b.Incidents >= minIncidents && b.Incidents <= maxIncidents)).ToArray();
            return result;
        }
        /// <summary>
        /// Filters a bee collection in order to return a new collection including just the bees whose State value
        /// matches the given parameter value.
        /// </summary>
        /// <param name="searchedState">The state value the returned bees must have.</param>
        /// <returns>A new collection of bee entities.</returns>
        public IEnumerable<BeeEntity> GetFilteredByState(bool searchedState)
        {
            var result = GetBeeEntities().Where(b => (b.State == searchedState)).ToArray();
            return result;
        }

        /// <summary>
        /// Gets the bees from the repository ordered ascending by a given property name.
        /// </summary>
        /// <param name="factor">The property name to order by.</param>
        /// <returns>An ascendingly ordered by a property bee collection.</returns>
        public IEnumerable<BeeEntity> GetOrderedByAscending(string factor)
        {
            var result = GetBeeEntities().OrderBy(b => b.GetType().GetProperty(factor).GetValue(b)).ToArray();
            return result;
                            
        }

        /// <summary>
        /// Gets the bees from the repository ordered descending by a given property name.
        /// </summary>
        /// <param name="factor">The property name to order by.</param>
        /// <returns>A descendingly ordered by a property bee collection.</returns>
        public IEnumerable<BeeEntity> GetOrderedByDescending(string factor)
        {
            var result = GetBeeEntities().OrderByDescending(b => b.GetType().GetProperty(factor).GetValue(b)).ToArray();
            return result;                         
        }

        private IEnumerable<BeeEntity> GetBeeEntities()
        {
            var result = _beeRepository.GetBees().Select(b => _infrastructureMapper.ToBeeEntity(b));
            return result;
        }
    }
}
