using Hive.Infrastructure.Contracts.Contracts;
using Hive.ServiceLibrary.Contracts.Contracts;

namespace Hive.ServiceLibrary.Implementations.Implementations
{
    /// <summary>
    /// Delete bee service.
    /// </summary>
    public class DeleteBeeService : IDeleteBeeService
    {
        private readonly IBeeRepository _beeRepository;

        /// <summary>
        /// Constructor of the delete bee service.
        /// </summary>
        /// <param name="beeRepository">Respository of the service.</param>
        public DeleteBeeService(IBeeRepository beeRepository)
        {
            _beeRepository = beeRepository;
        }

        /// <summary>
        /// Method to remove a bee from the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBee(int id)
        {
            var result = _beeRepository.DeleteBee(id);
            return result;
        }
    }
}
