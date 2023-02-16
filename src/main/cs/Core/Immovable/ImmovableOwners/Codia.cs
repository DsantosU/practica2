namespace RI.Novus.Core.Immovable.ImmovableOwners
{

    /// <summary>
    /// Indicates Codia of Immovable Owner
    /// </summary>
    public sealed class Codia : AbstractPositiveIntegerPrimitive
    {
        /// <summary>Creates a new instance checking parameter for <see langword="null"/>.</summary>
        /// <param name="rawCodia"></param>
        /// <returns></returns>
        private Codia(PositiveInteger rawCodia) : base(rawCodia)
        {

        }

        /// <summary>Creates a new instance from the given integer.</summary>
        /// <param name="rawCodia">Must be greater than or equals to one: &gt;= 1</param>
        /// <returns></returns>
        public static Codia From(int rawCodia) => new(new PositiveInteger(rawCodia));
    
    }
}
