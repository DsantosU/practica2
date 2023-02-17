using Microsoft.EntityFrameworkCore;
using RI.Novus.Core.Boundaries.Persistence;
using Triplex.Validations;
using ImmovableOwner = RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner;
using ImmovableOwnerDbModel = Persistence.Models.ImmovableOwner;
using ImmovableProperty = Persistence.Models.ImmovableProperty;

namespace Persistence.Repositories
{
    public sealed class ImmovableOwnerRepository : IImmovableOwnersRepository
    {

        public ApplicationDbContext Context;

        public ImmovableOwnerRepository(ApplicationDbContext context)
        {
            Context = context;
        }


        /// <summary>
        /// Get immovable owner by id method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner GetImmovableOwnerById(Guid ownerId)
        {

            var immovableOwner = Context.ImmovableOwners.Include(x => x.ImmovableProperties).FirstOrDefault(x => x.Id == ownerId);

            Arguments.NotNull(immovableOwner, nameof(immovableOwner));

            var dbModels = Context.ImmovableOwners.AsNoTracking().Include(o => o.ImmovableProperties).FirstOrDefault(x => x.Id == ownerId);

           

            return dbModels.ToEntity();
        }
        

        /// <summary>
        /// Get immovable owners method
        /// </summary>
        /// <returns></returns>
        public IList<ImmovableOwner> GetImmovableOwners()
        {

            List<ImmovableOwner> owners = new List<ImmovableOwner>();
            List<ImmovableOwnerDbModel> ownersDatabaseModel = Context.ImmovableOwners.AsNoTracking().Include(x => x.ImmovableProperties).ToList();

            foreach (var i in ownersDatabaseModel)
            {
                owners.Add(i.ToEntity());
            }

            return owners;
        }

        /// <summary>
        /// save immovable owner method
        /// </summary>
        /// <param name="immovableOwner"></param>
        void IImmovableOwnersRepository.SaveImmovableOwner(ImmovableOwner immovableOwner)
        {
            Arguments.NotNull(immovableOwner, nameof(immovableOwner));

            ImmovableOwnerDbModel owners = ImmovableOwnerDbModel.FromEntity(immovableOwner);
            Context.ImmovableOwners.Add(owners);
            Context.ImmovableProperties.AddRange(immovableOwner.ImmovableProperties.Select(ImmovableProperty.FromEntity));

            Context.SaveChanges();

        }

        /// <summary>
        /// Delete immovable owner property
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="propertyId"></param>
        public void DeleteProperty(RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner owner, Guid propertyId)
        {
            var propertyOwner = ImmovableOwnerDbModel.FromEntity(owner);
            var propertyToDelete = Context.ImmovableProperties.FirstOrDefault(p => p.Id == propertyId && p.ImmovableOwnerId == propertyOwner.Id);

            if (propertyToDelete != null)
            {
                Context.ImmovableProperties.Remove(propertyToDelete);
            }

            Context.SaveChanges();

        }


    }
}
