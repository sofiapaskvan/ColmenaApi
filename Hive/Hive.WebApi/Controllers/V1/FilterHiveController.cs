using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using System.Linq;
using System.Web.Http;

namespace Hive.WebApi.Controllers.V1
{
    /// <summary>
    /// Controller for endpoints aiming filtering of the bee hives.
    /// </summary>
    [RoutePrefix("GetHive")]
    public class FilterHiveController : ApiController
    {
        private readonly IGetHiveService _getFilteredHiveService;
        private readonly IDomainMapper _domainMapper;

        /// <summary>
        /// Constructor for the filtering controller.
        /// </summary>
        /// <param name="getFilteredHiveService"> </param>
        /// <param name="domainMapper"></param>
        public FilterHiveController(IGetHiveService getFilteredHiveService, IDomainMapper domainMapper)
        {
            _getFilteredHiveService = getFilteredHiveService;
            _domainMapper = domainMapper;
        }

        /// <summary>
        /// Gets bees filtered by minimum and maximum amount of incidents.
        /// </summary>
        /// <param name="minimum">The minimum incidents filter condition.</param>
        /// <param name="maximum">The maximum incidents filter condition.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHiveFilteredByIncidents")]
        public IHttpActionResult GetHiveFilteredByIncidents(int minimum, int maximum)
        {
            return Ok(_getFilteredHiveService.GetFilteredByIncidents(minimum, maximum)
                        .Select(b=> _domainMapper.ToBeeHourlyPerformance(b)));
        }

        /// <summary>
        /// Gets bees filtered by the state.
        /// </summary>
        /// <param name="state">The state filter condition.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHiveFilteredByState")]
        public IHttpActionResult GetHiveFilteredByState(bool state)
        {
            return Ok(_getFilteredHiveService.GetFilteredByState(state)
                       .Select(b => _domainMapper.ToBeeHourlyPerformance(b)));
        }
    }
}
