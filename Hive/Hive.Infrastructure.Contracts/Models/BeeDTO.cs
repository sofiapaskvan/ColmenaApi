using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Hive.Infrastructure.Contracts.Models
{
    public class BeeDTO
    {
        /// <summary>
        /// Id of the bee.
        /// </summary>
        [JsonProperty("id")]
        [XmlElement("id")]
        public int Id { get; set; }
        /// <summary>
        /// Name of the bee.
        /// </summary>

        [JsonProperty("nombre")]
        [XmlElement("nombre")]
        public string Name { get; set; }
        /// <summary>
        /// The amaunt of pollen harvested by the bee.
        /// </summary>

        [JsonProperty("recoleccion")]
        [XmlElement("recoleccion")]
        public decimal Recollected { get; set; }
        /// <summary>
        /// The total time the bee has been harvesting pollen.
        /// </summary>

        [JsonProperty("tiempo")]
        [XmlElement("tiempo")]
        public long Time { get; set; }
        /// <summary>
        /// True if the bee is harvesting, false if the bee is resting.
        /// </summary>

        [JsonProperty("estado")]
        [XmlElement("estado")]
        public bool State { get; set; }
        /// <summary>
        /// Counted incidents happened during the bee harvesting activity.
        /// </summary>

        [JsonProperty("incidentes")]
        [XmlElement("incidentes")]
        public int Incidents { get; set; }
    }
}
