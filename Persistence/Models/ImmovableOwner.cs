
using System.ComponentModel.DataAnnotations;
using Triplex.Validations;


namespace Persistence.Models
{
    /// <summary>
    /// Represents the database representation for an Immovable Owner/>.
    /// </summary>
    public sealed class ImmovableOwner
    {
        public ImmovableOwner(Guid id, string name, int codia, string identificationNumber) {
            Id = id;
            Name = name;
            Codia = codia;
      
            IdentificationNumber= identificationNumber;
        }

        /// <summary>
        /// Surrogate key.
        /// </summary>
        /// <value></value>
        /// 

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///  Name.
        /// </summary>
        /// <value></value>

        [Required]
        [MinLength(RI.Novus.Core.Immovable.ImmovableOwners.Name.MinLength)]
        [MaxLength(RI.Novus.Core.Immovable.ImmovableOwners.Name.MaxLength)]

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identification Number of Immovable Owner
        /// </summary>
        /// 
        [Required]
        [MinLength(RI.Novus.Core.Immovable.ImmovableOwners.Name.MinLength)]
        [MaxLength(RI.Novus.Core.Immovable.ImmovableOwners.Name.MaxLength)]
        public string IdentificationNumber { get; set; } = string.Empty;

        [Required]
        public IList<ImmovableProperty> ImmovableProperties { get; set; }
        /// <summary>
        /// Codia of immovable owner
        /// </summary>
        /// 

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Codia { get; set; }

        /// <summary>
        /// Creation Date of immovable codia
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Converts current model to Immovable entity
        /// </summary>
        /// <returns></returns>
        public RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner ToEntity()
        {
           
            return new RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner.Builder()
                            .WithId(RI.Novus.Core.Immovable.ImmovableOwners.Id.From(Id))
                            .WithName(RI.Novus.Core.Immovable.ImmovableOwners.Name.From(Name))
                            .WithList(ImmovableProperties.Select(i => i.ToEntity()).ToList())
                            .WithCreationDate(RI.Novus.Core.Immovable.ImmovableOwners.CreationDate.From(CreationDate))
                            .WithCodia(RI.Novus.Core.Immovable.ImmovableOwners.Codia.From(Codia))
                            .WithIdentificationNumber(RI.Novus.Core.Immovable.ImmovableOwners.IdentificationNumber.From(IdentificationNumber))
                            .Build();

        }

        /// <summary>
        /// Convert entity to model        
        /// /// </summary>
        /// <param name="immovableOwner"></param>
        /// <returns></returns>
        public static ImmovableOwner FromEntity(RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner immovableOwner)
        {
            Arguments.NotNull(immovableOwner, nameof(immovableOwner));

            return new
            (
                immovableOwner.Id.Value,
                immovableOwner.Name.AsPrimitive,
                immovableOwner.Codia.AsPrimitive,
                immovableOwner.IdentificationNumber.AsPrimitive
            );

            
        }


    }
}
