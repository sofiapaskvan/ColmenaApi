using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using Hive.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Hive.WebApi.Controllers.V2
{
    /// <summary>
    /// Controller for methods aiming bee information update.
    /// </summary>
    [RoutePrefix("UpdateBee")]
    public class UpdateBeeController : ApiController
    {
        private readonly IDomainMapper _domainMapper;
        private readonly IUpdateBeeService _updateBeeService;

        /// <summary>
        /// Constructo for the bee uppdater controller.
        /// </summary>
        /// <param name="updateBeeService">The update bee service.</param>
        /// <param name="domainMapper">Mapper to translate requests or responses to/from model entity bee objects.</param>
        public UpdateBeeController(IUpdateBeeService updateBeeService, IDomainMapper domainMapper)
        {
            _updateBeeService = updateBeeService;
            _domainMapper = domainMapper;
        }

        /// <summary>
        /// Endpoint to update a bee.
        /// </summary>
        /// <param name="bee">A bee request object</param>
        /// <returns>True if operation is successfull, false if not.</returns>
        [HttpPatch]
        [Route("")]
        public IHttpActionResult UpdateBee(BeeRequest bee)
        {
            return Ok(_updateBeeService.UpdateBee(_domainMapper.ToBeeEntity(bee)));
        }
    }
}