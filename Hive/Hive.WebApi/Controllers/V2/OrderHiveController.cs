using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using System.Linq;
using System.Web.Http;

namespace Hive.WebApi.Controllers.V2
{
    /// <summary>
    /// Controller for methods aiming ordering of the bee hives.
    /// </summary>
    [RoutePrefix("GetHive")]
    public class OrderHiveController : ApiController
    {
        private readonly IGetHiveService _getHiveService;
        private readonly IDomainMapper _domainMapper;

        /// <summary>
        /// Constructor for the order hive controller.
        /// </summary>
        /// <param name="getHiveService">A hive getter service</param>
        /// <param name="domainMapper">Mapper to translate requests or responses to/from model entity bee objects.</param>
        public OrderHiveController(IGetHiveService getHiveService, IDomainMapper domainMapper)
        {
            _getHiveService = getHiveService;
            _domainMapper = domainMapper;
        }

        /// <summary>
        /// Endpint to get bees ordered by recollected pollen. Bees with LEAST recollected pollen go first.
        /// </summary>
        /// <returns>Collection of bees ordered by ascending recollected pollen.</returns>
        [HttpGet]
        [Route("OrderedByRecollected")]
        public IHttpActionResult OrderedByRecollected()
        {
            return Ok(_getHiveService.GetOrderedByAscending("Recollected")
                                     .Select(b => _domainMapper.ToBeeTotalCollected(b)));
        }

        /// <summary>
        /// Endpint to get bees ordered by recollected pollen. Bees with MOST recollected pollen go first.
        /// </summary>
        /// <returns>Collection of bees ordered by descendig recollected pollen.</returns>
        [HttpGet]
        [Route("OrderedByDescendingRecollected")]
        public IHttpActionResult OrderedByDescendingRecollected()
        {
            return Ok(_getHiveService.GetOrderedByDescending("Recollected")
                                     .Select(b => _domainMapper.ToBeeTotalCollected(b)));
        }
    }
}
