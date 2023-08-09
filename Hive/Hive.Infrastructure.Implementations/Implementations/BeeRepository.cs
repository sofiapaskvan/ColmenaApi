using Hive.Infrastructure.Contracts.Contracts;
using Hive.Infrastructure.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Hive.Infrastructure.Implementations.Implementations
{
    /// <summary>
    /// A bee data repository
    /// </summary>
    public class BeeRepository : IBeeRepository
    {
        private readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory;
        private string PersistenceJsonFilePath => Path.Combine(_basePath, "../input.json");
        private string PersistenceXmlFilePath => Path.Combine(_basePath, "../input.xml");
        /// <summary>
        /// Adds a new bee to a persistence file.
        /// </summary>
        /// <param name="bee">Added bee.</param>
        /// <returns>True if operation is succesfull, false if not</returns>
        /// <exception cref="Exception">Could not add bee.</exception>
        public bool AddBee(BeeDTO bee)
        {
            bool result;
            try
            {
                var bees = GetJsonBees();
                bees = bees.Append(bee);
                result = WritteJsonBees(bees);
            }
            catch (Exception e) {
                throw new Exception(e.Message+" Could not add.");
            }
            return result;
        }

        /// <summary>
        /// Deletes a bee from the persistence file.
        /// </summary>
        /// <param name="id">Deleted bee id</param>
        /// <returns>True if operation is succesfull, false if not.</returns>
        /// <exception cref="Exception">Could not delete bee.</exception>
        public bool DeleteBee(int id)
        {
            var result = false;
            try
            {
                var bees = GetJsonBees().ToList();
                var bee = bees.FirstOrDefault(b => b.Id == id);
                if (bee != null) 
                {
                    bees.Remove(bees.FirstOrDefault(b => b.Id == id));
                    result = WritteJsonBees(bees);
                }                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " Could not delete.");
            }
            return result;
        }

        /// <summary>
        /// Updates a bee from the persistence file.
        /// </summary>
        /// <param name="bee">Bee to be updated..</param>
        /// <returns>True if operation is succesfull, false if not.</returns>
        /// <exception cref="Exception">Could not update bee.</exception>
        public bool UpdateBee(BeeDTO bee)
        {
            var result = false;
            try
            {
                var bees = GetJsonBees();
                var oldBee = bees.FirstOrDefault(b=> b.Id == bee.Id);
                if (oldBee != null)
                {
                    oldBee.Id = bee.Id;
                    oldBee.Name = bee.Name;
                    oldBee.Recollected = bee.Recollected;
                    oldBee.Time = bee.Time;
                    oldBee.State = bee.State;
                    oldBee.Incidents = bee.Incidents;
                    result = WritteJsonBees(bees);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " Could not update.");
            }
            return result;
        }

        /// <summary>
        /// Selects all the bee entities stored in the repository.
        /// </summary>
        /// <returns>A collection of bee entities.</returns>
        public IEnumerable<BeeDTO> GetBees()
        {
            var jsonHive = GetJsonBees();
            var xmlHive = GetXmlBees();
            return jsonHive.Concat(xmlHive);
        }

        private IEnumerable<BeeDTO> GetJsonBees()
        {
            string json = File.ReadAllText(PersistenceJsonFilePath);
            HiveDTO hive = JsonConvert.DeserializeObject<HiveDTO>(json);
            return hive.Bees;
        }

        private IEnumerable<BeeDTO> GetXmlBees()
        {
            string xml = File.ReadAllText(PersistenceXmlFilePath);
            XmlRootAttribute xRoot = new XmlRootAttribute
            {
                ElementName = "colmena",
                IsNullable = true
            };
            HiveDTO hive = new HiveDTO();
            XmlSerializer serializer = new XmlSerializer(hive.GetType(), xRoot);
            using (StringReader reader = new StringReader(xml))
            {
                hive = (HiveDTO)serializer.Deserialize(reader);
            }
            return hive.Bees;
        }

        private bool WritteJsonBees(IEnumerable<BeeDTO> bees)
        {
            var result = true;
            try
            {
                var hive = new HiveDTO { Bees = bees.ToList() };
                var json = JsonConvert.SerializeObject(hive, Formatting.Indented);
                File.WriteAllText(PersistenceJsonFilePath, json);
            }
            catch
            {
                result = false;
            }
            return result;
        }


    }
}
