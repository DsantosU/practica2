using RI.Novus.Core.Asegurados.Asegurado;
using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Facts.Asegurados.AseguradoFacts;

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
        string aseguradoName = "Daniel";
        Guid id = Guid.NewGuid();
        string identificationNumber = "001-0000000-1";
        int age = 18;
        DateTimeOffset birthday = DateTimeOffset.UtcNow;


        IAseguradoRepository? aseguradoRepository = null;

        var asegurado = new Asegurado.Builder()
                                .WithAseguradoName(AseguradoName.From(aseguradoName))
                                .WithAge(Age.From(age))
                                .WithIdentificationNumber(IdentificationNumber.From(identificationNumber))
                                .WithBirthday(Birthday.From(birthday))
                                .WithId(Id.From(id))
                                .Build();


        //Assert

        Assert.That(() =>
        {
            asegurado.Persist(aseguradoRepository: aseguradoRepository);

        }, Throws.ArgumentNullException);


    }
}
