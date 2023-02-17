using Optional.Unsafe;
using Persistence.Models;
using RI.Novus.Core.Immovable.ImmovableOwners;
using Triplex.Validations;

namespace WebApiExample.ViewModels
{
    public sealed class ImmovableOwnerModel
    {

        /// <summary>
        /// Surrogate key.
        /// </summary>
        /// <value></value>
        
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Indicates Identification Number
        /// </summary>

        public string IdentificationNumber { get; set; } = null!;

        /// <summary>
        /// Indicates Codia
        /// </summary>
        public int Codia { get; set; }

        /// <summary>
        /// Indicates CreationDate
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Indicate list of immovable property
        /// </summary>

        public IEnumerable<ImmovablePropertyModel> ImmovableProperties { get; set; } 
        /// <summary>
        /// Converts to ImmovableOwner entity
        /// </summary>
        /// <returns>An instance of <see cref="ImmovableOwner"/></returns>

        public RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner ToEntity()
        {
            var ide = Guid.NewGuid();
            foreach (var entity in ImmovableProperties)
            {
                entity.ImmovableOwnerId = ide;
            }

            return new RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner.Builder()    
                   .WithId(RI.Novus.Core.Immovable.ImmovableOwners.Id.From(ide))
                   .WithName(RI.Novus.Core.Immovable.ImmovableOwners.Name.From(Name))
                   .WithCodia(RI.Novus.Core.Immovable.ImmovableOwners.Codia.From(Codia))
                   .WithList(ImmovableProperties.Select(i => i.ToEntity()).ToList())
                   .WithCreationDate(RI.Novus.Core.Immovable.ImmovableOwners.CreationDate.From(CreationDate))
                   .WithIdentificationNumber(RI.Novus.Core.Immovable.ImmovableOwners.IdentificationNumber.From(IdentificationNumber))
                   .Build();
        }

        public static ImmovableOwnerModel FromEntity(RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner immovableOwner)
        {
            Arguments.NotNull(immovableOwner, nameof(immovableOwner));

            return new ImmovableOwnerModel()
            {
                Id = immovableOwner.Id.Value,
                Name = immovableOwner.Name.AsPrimitive,
                Codia = immovableOwner.Codia.AsPrimitive,
                ImmovableProperties = immovableOwner.ImmovableProperties.Select(x => new ImmovablePropertyModel
                {
                    Id = x.Id.Value,
                    Surface = x.Surface.Value,
                    Type = x.Type,
                    Area = x.Area.ValueOrDefault().Value,
                    Region = x.Region.ValueOrDefault().Value,
                    ImmovableOwnerId= x.ImmovableOwnerId,
                }),
                CreationDate = immovableOwner.CreationDate.AsPrimitive,
                IdentificationNumber = immovableOwner.IdentificationNumber.AsPrimitive,

            };
        }
    }
}
