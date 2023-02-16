using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Immovable.ImmovableProperties;
using Triplex.Validations;
using ImmovableProperty = Persistence.Models.ImmovableProperty;

namespace Persistence.Repositories
{
    public sealed class ImmovablePropertyRepository : IImmovablePropertyRepository
    {
        private readonly ApplicationDbContext _context;
        public ImmovablePropertyRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void DeleteProperty(Guid PropertyId)
        {

            var property = _context.ImmovableProperties.Find(PropertyId);

            Arguments.NotNull(property, nameof(property));

            _context.ImmovableProperties.Remove(property);

            _context.SaveChanges();


        }

    

        public void UpdateRepository(RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner immovableOwner, Guid propertyId, RI.Novus.Core.Immovable.ImmovableProperties.ImmovableProperty updateProperty)
        {
            var owner = ImmovableOwner.FromEntity(immovableOwner);
            var propertyUpdate =
                _context.ImmovableProperties.FirstOrDefault(x => x.Id == propertyId && x.ImmovableOwnerId == owner.Id);
            if (propertyUpdate != null)
            {
                var ownerProperty = ImmovableProperty.FromEntity(updateProperty);
                propertyUpdate.ImmovableOwnerId = ownerProperty.ImmovableOwnerId;
                propertyUpdate.Surface = ownerProperty.Surface;
                propertyUpdate.Type = ownerProperty.Type;
                propertyUpdate.Area = ownerProperty.Area;
                propertyUpdate.Region = ownerProperty.Region;
                _context.SaveChanges();
            }
        }
    }
}

