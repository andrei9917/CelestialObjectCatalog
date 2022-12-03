using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ObjectType
    {
        public int ObjectTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<CelestialObject> CelestialObjects { get; set; }
    }
}
