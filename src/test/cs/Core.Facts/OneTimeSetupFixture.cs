using NUnit.Framework.Internal;

namespace RI.Novus.Core.Facts;

[SetUpFixture]
[Parallelizable(scope: ParallelScope.All)]
internal class OneTimeSetupFixture
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests() { 
    
    }

    public static readonly char[] ControlCharacters = Enumerable.Range(char.MinValue, char.MaxValue).Select(c => (char)c).Where(char.IsControl).ToArray();


    [OneTimeTearDown]
    public void RunAfterAllTests()
    {
    }
}
