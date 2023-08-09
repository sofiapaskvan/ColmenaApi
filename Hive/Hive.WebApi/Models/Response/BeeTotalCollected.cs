using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace Hive.WebApi.Models.Response
{
    /// <summary>
    /// Model of a bee total collected response. 
    /// </summary>
    public class BeeTotalCollected
    {
        /// <summary>
        /// Ide of the bee.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the bee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amount of the be recollected pollen.
        /// </summary>
        public decimal Recollected { get; set; }
    }
}