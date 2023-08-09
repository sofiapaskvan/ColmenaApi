using Hive.Infrastructure.Contracts.Contracts;
using Hive.Infrastructure.Contracts.Mapper;
using Hive.Library.Models;
using Hive.ServiceLibrary.Contracts.Contracts;

namespace Hive.ServiceLibrary.Implementations.Implementations
{
    /// <summary>
    /// Update bee service.
    /// </summary>
    public class UpdateBeeService : IUpdateBeeService
    {
        private readonly IBeeRepository _beeRepository;
        private readonly IInfrastructureMapper _infrastructureMapper;

        /// <summary>
        /// Constructor for the bee update service.
        /// </summary>
        /// <param name="beeRepository">The repository of the service.</param>
        /// <param name="infrastructureMapper">A mapper to translate DTO bees from/to bee entity objects.</param>
        public UpdateBeeService(IBeeRepository beeRepository, IInfrastructureMapper infrastructureMapper)
        {
            _beeRepository = beeRepository;
            _infrastructureMapper = infrastructureMapper;
        }

        /// <summary>
        /// Updates a bee from the repository.
        /// </summary>
        /// <param name="bee">A bee entity with the same id of the bee to be updated.</param>
        /// <returns>True i the operations is successfull, false if not.</returns>
        public bool UpdateBee(BeeEntity bee)
        {
            var result = _beeRepository.UpdateBee(_infrastructureMapper.ToBeeDTO(bee));
            return result;
        }
    }
}
