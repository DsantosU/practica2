using Optional.Unsafe;
using RI.Novus.Core.Immovable.ImmovableProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Triplex.Validations;

namespace Persistence.Models
{
    public sealed class ImmovableProperty
    {

        /// <summary>
        /// Surrogate key.
        /// </summary>
        /// <value></value>
        /// 
        [Key]
        public Guid Id { get; set; }

        public Guid ImmovableOwnerId { get; set; }

        /// <summary>
        /// Surface of immovable property
        /// </summary>
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Surface { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RI.Novus.Core.Immovable.ImmovableProperties.Type Type { get; set; }

        /// <summary>
        /// Area of immovable property
        /// </summary>

        [Range(0, (double)decimal.MaxValue)]

        public decimal? Area { get; set; }

        /// <summary>
        /// Region of immovable property
        /// </summary>

        [Range(0, (double)decimal.MaxValue)]
        public decimal? Region { get; set; }

        /// <summary>
        /// Immovable Owner Id
        /// </summary>
        /// 
        [ForeignKey(nameof(ImmovableOwnerId))]
        public ImmovableOwner ImmovableOwner { get; set; }
        public RI.Novus.Core.Immovable.ImmovableProperties.ImmovableProperty ToEntity()
        {
            var builder = new RI.Novus.Core.Immovable.ImmovableProperties.ImmovableProperty.Builder()
                           .WithId(RI.Novus.Core.Immovable.ImmovableProperties.Id.From(Id))
                           .WithType(Type)
                           .WithImmovableOwnerId(ImmovableOwnerId)
                           .WithSurface(RI.Novus.Core.Immovable.ImmovableProperties.Surface.From(Surface));

            if (Area != null)
            {
                builder.WithArea(RI.Novus.Core.Immovable.ImmovableProperties.Area.From((decimal)Area));
            }

            if (Region != null)
            {
                builder.WithRegion(RI.Novus.Core.Immovable.ImmovableProperties.Region.From((decimal)Region));

            }

            return builder.Build();

        }

        /// <summary>
        /// 
        /// </summary>asegurado
        /// <param name="immovableOwner"></param>
        /// <returns></returns>
        public static ImmovableProperty FromEntity(RI.Novus.Core.Immovable.ImmovableProperties.ImmovableProperty immovableProperty)
        {
            Arguments.NotNull(immovableProperty, nameof(immovableProperty));

            return new ImmovableProperty
            {
                Id = immovableProperty.Id.Value,
                Surface = immovableProperty.Surface.Value,
                Type = immovableProperty.Type,
                ImmovableOwnerId = immovableProperty.ImmovableOwnerId,
                Region = immovableProperty.Region.HasValue ? immovableProperty.Region.ValueOrFailure().Value : null,
                Area = immovableProperty.Area.HasValue ? immovableProperty.Area.ValueOrFailure().Value : null
            };

        }
    }
}

