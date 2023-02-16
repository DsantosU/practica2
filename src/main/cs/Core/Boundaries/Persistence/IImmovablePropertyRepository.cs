using RI.Novus.Core.Immovable.ImmovableProperties;
using System.Collections.Generic;

namespace RI.Novus.Core.Boundaries.Persistence
{
    public interface IImmovablePropertyRepository
    {
        void DeleteProperty(Guid id);

     
        void UpdateRepository(Immovable.ImmovableOwners.ImmovableOwner immovableOwner, Guid propertyId, ImmovableProperty property);
    }
}
