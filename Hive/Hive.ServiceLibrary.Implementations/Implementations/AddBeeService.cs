using Hive.Infrastructure.Contracts.Contracts;
using Hive.Infrastructure.Contracts.Mapper;
using Hive.Library.Models;
using Hive.ServiceLibrary.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.ServiceLibrary.Implementations.Implementations
{
    /// <summary>
    /// Service for adding bees.
    /// </summary>
    public class AddBeeService : IAddBeeService
    {   
        private readonly IBeeRepository _beeRepository;
        private readonly IInfrastructureMapper _infrastructureMapper;
        
        /// <summary>
        /// Constructor for the bee adding service.
        /// </summary>
        /// <param name="beeRepository">The repository to save the added bees.</param>
        /// <param name="infrastructureMapper">Mapper to translate DTO bees to/from entity model objects.</param>
        public AddBeeService(IBeeRepository beeRepository, IInfrastructureMapper infrastructureMapper)
        {
            _beeRepository = beeRepository;
            _infrastructureMapper = infrastructureMapper;
        }
        /// <summary>
        /// Method to add a bee in the service repository.
        /// </summary>
        /// <param name="bee">The bee to be added.</param>
        /// <returns>True if the operation is succesfull, false if not.</returns>
        public bool AddBee(BeeEntity bee)
        {
            var result = _beeRepository.AddBee(_infrastructureMapper.ToBeeDTO(bee));
            return result;
        }
    }
}
