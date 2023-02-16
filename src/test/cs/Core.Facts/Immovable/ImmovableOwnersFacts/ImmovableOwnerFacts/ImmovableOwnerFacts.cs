using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.Immovable.ImmovableOwners;
using RI.Novus.Core.Immovable.ImmovableProperties;
using System.Collections.ObjectModel;

namespace RI.Novus.Core.Facts.Immovable.ImmovableOwnersFacts.ImmovableOwnerFacts;

/// <summary>
/// Asegurado test
/// </summary>
public sealed class ImmovableOwnerFacts
{

    /// <summary>
    /// With Null Repository Throws Argument Exception Persists
    /// </summary>

    [Test]

    public void With_Null_Repository_Throws_Argument_Exception_Persists()
    {
        //Arrange
        string name = "Daniel";
        Guid id = Guid.NewGuid();
        string identificationNumber = "001-0000000-1";
        int codia = 18;
        ICollection<ImmovableProperty> ImmovableProperty;
        DateTimeOffset creationDate = DateTimeOffset.UtcNow;


        IImmovableOwnersRepository? immovableOwnersRepository = null;

        var immovable = new ImmovableOwner.Builder()
                                .WithName(Name.From(name))
                                .WithCodia(Codia.From(codia))
                                //.WithList(Core.Immovable.ImmovableOwners.List.From(list))
                                .WithIdentificationNumber(IdentificationNumber.From(identificationNumber))
                                .WithCreationDate(CreationDate.From(creationDate))
                                .WithId(Core.Immovable.ImmovableOwners.Id.From(id))
                                .Build();


        //Assert

        Assert.That(() =>
        {
            immovable.Persist(immovableOwnerRepository: immovableOwnersRepository);

        }, Throws.ArgumentNullException);
    }
}
