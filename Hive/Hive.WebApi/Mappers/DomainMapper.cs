using Hive.Library.Models;
using Hive.Models.Response;
using Hive.WebApi.Models;
using Hive.WebApi.Models.Response;
using System.Xml.Linq;

namespace Hive.Mappers
{
    /// <summary>
    /// Mapper to translate requests or responses to/from model entity bee objects.
    /// </summary>
    public class DomainMapper : IDomainMapper
    {
        /// <summary>
        /// Transforms a request to a entity bee object
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A bee entity object.</returns>
        public BeeEntity ToBeeEntity(BeeRequest request)
        {
            return new BeeEntity
            {
                Id = request.Id,
                Name = request.Name,
                Recollected = request.Recollected,
                Time = request.Time,
                State = request.State,
                Incidents = request.Incidents,
            };
            
        }

        /// <summary>
        /// Transforms a bee tntity to a model of hurly performance response.
        /// </summary>
        /// <param name="entity">A bee entity object.</param>
        /// <returns>A model of hourly performance response object.</returns>
        public BeeHourlyPerformance ToBeeHourlyPerformance(BeeEntity entity)
        {
            return new BeeHourlyPerformance
            {
                Id = entity.Id,
                Name = entity.Name,
                HourlyPollen = entity.HourlyPollen
            };
        }

        /// <summary>
        /// Transforms a bee entity to a total collected response.
        /// </summary>
        /// <param name="entity">A bee entity object.</param>
        /// <returns>A model of total collected response object.</returns>
        public BeeTotalCollected ToBeeTotalCollected(BeeEntity entity)
        {
            return new BeeTotalCollected
            {
                Id = entity.Id,
                Name = entity.Name,
                Recollected = entity.Recollected
            };
        }
    }
}
