using Triplex.Validations;
using Persistence.Models;
using ImmovableProperty = RI.Novus.Core.Immovable.ImmovableProperties.ImmovableProperty;
using Optional.Unsafe;
using System.Collections.Generic;
using RI.Novus.Core.Immovable.ImmovableProperties;

namespace WebApiExample.ViewModels
{
    public sealed class ImmovablePropertyModel
    {

        public Guid Id { get; set; }
        public decimal Surface { get; set; }

        public decimal? Area { get; set; }

        public RI.Novus.Core.Immovable.ImmovableProperties.Type Type { get; set; }

        public decimal? Region { get; set; }

        public Guid ImmovableOwnerId { get; set; }


        public ImmovableProperty ToEntity()
        {
            return new ImmovableProperty.Builder()
                   .WithId(RI.Novus.Core.Immovable.ImmovableProperties.Id.From(Id))
                   .WithSurface(RI.Novus.Core.Immovable.ImmovableProperties.Surface.From(Surface))
                   .WithType(Type)
                   .WithRegion(RI.Novus.Core.Immovable.ImmovableProperties.Region.From((decimal)Region))
                   .WithArea(RI.Novus.Core.Immovable.ImmovableProperties.Area.From((decimal)Area))
                   .WithImmovableOwnerId(ImmovableOwnerId)
                   .Build();
        }

        public static ImmovablePropertyModel FromEntity(ImmovableProperty immovableProperty)
        {
            Arguments.NotNull(immovableProperty, nameof(immovableProperty));

            return new ImmovablePropertyModel()
            {
                Id = immovableProperty.Id.Value,
                Surface = immovableProperty.Surface.Value,
                Type = immovableProperty.Type,
                Area = immovableProperty.Area.ValueOrDefault().Value,
                Region = immovableProperty.Region.ValueOrDefault().Value,
                ImmovableOwnerId = immovableProperty.ImmovableOwnerId
            };

        }
    }

}
