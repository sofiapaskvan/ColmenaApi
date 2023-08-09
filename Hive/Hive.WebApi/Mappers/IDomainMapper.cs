using Hive.Library.Models;
using Hive.Models.Response;
using Hive.WebApi.Models;
using Hive.WebApi.Models.Response;

namespace Hive.Mappers
{
    /// <summary>
    /// Mapper to translate requests or responses to/from model entity bee objects.
    /// </summary>
    public interface IDomainMapper
    {
        /// <summary>
        /// Transforms a request to a entity bee object
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A bee entity object.</returns>
        BeeEntity ToBeeEntity(BeeRequest request);
        /// <summary>
        /// Transforms a bee tntity to a model of hurly performance response.
        /// </summary>
        /// <param name="entity">A bee entity object.</param>
        /// <returns>A model of hourly performance response object.</returns>
        BeeHourlyPerformance ToBeeHourlyPerformance(BeeEntity entity);
        /// <summary>
        /// Transforms a bee entity to a total collected response.
        /// </summary>
        /// <param name="entity">A bee entity object.</param>
        /// <returns>A model of total collected response object.</returns>
        BeeTotalCollected ToBeeTotalCollected(BeeEntity entity);
    }
}
