using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using Hive.WebApi.Models;
using System.Linq;
using System.Web.Http;

namespace Hive.WebApi.Controllers.V2
{
    /// <summary>
    /// Controller for methods aiming new bees resgistration.
    /// </summary>
    [RoutePrefix("AddBee")]
    public class AddBeeController : ApiController
    {
        private readonly IAddBeeService _addBeeService;
        private readonly IDomainMapper _domainMapper;

        /// <summary>
        /// Constructor for the bee adder controller.
        /// </summary>
        /// <param name="addBeeService">Add bee service.</param>
        /// <param name="domainMapper">Mapper to translate requests or responses to/from model entity bee objects.</param>
        public AddBeeController(IAddBeeService addBeeService, IDomainMapper domainMapper)
        {
            _addBeeService = addBeeService;
            _domainMapper = domainMapper;
        }

        /// <summary>
        /// Endpoint to add a new bee.
        /// </summary>
        /// <param name="bee">The bee to be added.</param>
        /// <returns>True if operation is successfull, false if not.</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddBee(BeeRequest bee)
        {
            return Ok(_addBeeService.AddBee(_domainMapper.ToBeeEntity(bee)));
        }
    }
}
