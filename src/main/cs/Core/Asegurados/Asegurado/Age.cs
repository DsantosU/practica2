namespace RI.Novus.Core.Asegurados.Asegurado;

/// <summary>
/// Indicate de age of asegurados
/// </summary>
public sealed class Age : AbstractPositiveIntegerPrimitive
{
    /// <summary>Creates a new instance checking parameter for <see langword="null"/>.</summary>
    /// <param name="rawAge"></param>
    /// <returns></returns>
    private Age(PositiveInteger rawAge) : base(rawAge)
    {

    }

    /// <summary>Creates a new instance from the given integer.</summary>
    /// <param name="rawAge">Must be greater than or equals to one: &gt;= 1</param>
    /// <returns></returns>
    public static Age From(int rawAge) => new(new PositiveInteger(rawAge));
}
