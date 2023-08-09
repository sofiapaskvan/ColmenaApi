using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hive.Infrastructure.Contracts.Models
{
    [XmlTypeAttribute]
    public class HiveDTO
    {
        [JsonProperty("colmena")]
        [XmlElement(ElementName = "abeja")]
        public List<BeeDTO> Bees { get; set; }
    }
}
