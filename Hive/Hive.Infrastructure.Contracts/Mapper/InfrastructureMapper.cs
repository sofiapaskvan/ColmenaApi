using Hive.Infrastructure.Contracts.Models;
using Hive.Library.Models;

namespace Hive.Infrastructure.Contracts.Mapper
{
    public class InfrastructureMapper : IInfrastructureMapper
    {
        public BeeDTO ToBeeDTO(BeeEntity ent)
        {
            return new BeeDTO
            {
                Id = ent.Id,
                Name = ent.Name,
                Recollected = ent.Recollected,
                Time = ent.Time,
                State = ent.State,
                Incidents = ent.Incidents,
            };
        }

        public BeeEntity ToBeeEntity(BeeDTO dto)
        {
            return new BeeEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Recollected = dto.Recollected,
                Time = dto.Time,
                State = dto.State,
                Incidents = dto.Incidents,
            };
        }
    }
}