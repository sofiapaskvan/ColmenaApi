using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Library.Models
{
    /// <summary>
    /// Identifiable bee. 
    /// Encapsulates the bee pollen recollection preformance information.
    /// </summary>
    public class BeeEntity
    {
        /// <summary>
        /// Id of the bee.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the bee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The amaunt of pollen harvested by the bee.
        /// </summary>
        public decimal Recollected { get; set; }
        /// <summary>
        /// The total time the bee has been harvesting pollen.
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// True if the bee is harvesting, false if the bee is resting.
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// Counted incidents happened during the bee harvesting activity.
        /// </summary>
        public int Incidents { get; set; }
        /// <summary>
        /// Calculated pollen units recolleted per hour.
        /// </summary>
        public decimal HourlyPollen => Recollected / (Time / 60);

    }
}
