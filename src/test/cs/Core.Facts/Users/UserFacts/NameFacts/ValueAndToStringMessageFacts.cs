using RI.Novus.Core.Users;

namespace RI.Novus.Core.Facts.Users.UserFacts.NameFacts;

internal sealed class ValueAndToStringMessageFacts : AbstractPureStringWrapperTestFixture<Name>
{
    protected override (Name subject, string rawValue) CreateSubject()
    {
        const string rawName = "Pedro";


        return (new Name(rawName), rawName);
    }
}
