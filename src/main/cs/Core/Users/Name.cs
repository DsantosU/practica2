namespace RI.Novus.Core.Users
{
    public sealed class Name: AbstractSimpleStringValue
    {
        private string rawName;

        /// <summary>
        /// Minimum allowed length.
        /// </summary>
        public const int MinLength = 5;

        /// <summary>
        /// Maximum allowed length.
        /// </summary>
        public const int MaxLength = 15;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawName"></param>
        public Name(string rawName)
        {
            Message genericMessage = new("Invalid value or format for Name.");
            ConfigurableString.Builder builder = new(genericMessage, useSingleMessage: true);

            InnerValue = builder.Build(rawName);

            this.rawName = rawName;
        }

        protected override ConfigurableString InnerValue {  get; }
    }
}
