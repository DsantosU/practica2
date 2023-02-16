using RI.Novus.Core.Immovable.ImmovableOwners;
using RI.Novus.Core.Immovable.ImmovableProperties;
using System.Collections.Generic;

namespace RI.Novus.Core.Boundaries.Persistence
{
    /// <summary>Repository to work with <see cref="ImmovableOwner"/>s.</summary>
    public interface IImmovableOwnersRepository
    {

        /// <summary>
        /// Gets Immovables Owner by name Id
        /// </summary>
        /// <param id="id">ImmovableOwner id</param>
        /// <returns>An instance of <see cref="ImmovableOwner"></returns>
        ImmovableOwner GetImmovableOwnerById(Guid id);

        /// <summary>
        /// Get all Immovable Owners
        /// </summary>
        /// <returns></returns>
        IList<ImmovableOwner> GetImmovableOwners();

        /// <summary>
        /// Persist a given Immovable owner
        /// </summary>
        /// <param name="immovableOwner">Asegurado to be persistent</param>
        void SaveImmovableOwner(ImmovableOwner immovableOwner);



    }


}