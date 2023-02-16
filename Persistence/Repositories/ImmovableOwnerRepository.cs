using Microsoft.EntityFrameworkCore;
using Optional.Unsafe;
using Persistence.Models;
using RI.Novus.Core.Asegurados.Asegurado;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Immovable.ImmovableOwners;
using RI.Novus.Core.Immovable.ImmovableProperties;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using Triplex.Validations;
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
        public IList<RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner> GetImmovableOwners()
        {

            List<ImmovableOwnerDbModel> dbModels = Context.ImmovableOwners.AsNoTracking().Include(o => o.ImmovableProperties).ToList();

            return dbModels.Select(dbModel => dbModel.ToEntity()).ToList();
        }

        /// <summary>
        /// save immovable owner method
        /// </summary>
        /// <param name="immovableOwner"></param>
        void IImmovableOwnersRepository.SaveImmovableOwner(RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner immovableOwner)
        {
            Arguments.NotNull(immovableOwner, nameof(immovableOwner));
            
            Context.ImmovableOwners.AddRange(ImmovableOwnerDbModel.FromEntity(immovableOwner));

            Context.SaveChanges();

        }

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
