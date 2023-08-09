using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using Hive.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Web.Http;

namespace Hive.WebApi.Controllers.V2
{
    /// <summary>
    /// Controller for methods aiming bee removal.
    /// </summary>
    [RoutePrefix("DeleteBee")]
    public class DeleteBeeController : ApiController
    {
        private readonly IDeleteBeeService _deleteBeeService;

        /// <summary>
        /// Constructor for the bee remover controller.
        /// </summary>
        /// <param name="deleteBeeService">Removing bee service.</param>
        public DeleteBeeController(IDeleteBeeService deleteBeeService)
        {
            _deleteBeeService = deleteBeeService;
        }

        /// <summary>
        /// Endpoint to remove a bee by Id.
        /// </summary>
        /// <param name="id">The id of the bee to be removed.</param>
        /// <returns>True if operation is successfull, false if not.</returns>
        [HttpDelete]
        [Route("")]
        public IHttpActionResult DeleteBee(int id)
        {
            return Ok(_deleteBeeService.DeleteBee(id));
        }
    }
}