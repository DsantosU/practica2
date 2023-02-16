using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.CadastralSurvey.Expedients;
using Triplex.Validations;

namespace Persistence.Repositories
{
    /// <summary>
    /// Represents the dummy in memory implementation for Expedients
    /// </summary>
    public sealed class ExpedientRepositoryDummy : IExpedientRepositoryDummy
    {
        private static ICollection<Models.Expedient> expedients = new List<Models.Expedient> { 
            new Models.Expedient("Expedient1", "Gonzalo"),
            new Models.Expedient("Expedient2", null) 
        };
        /// <inheritdoc />
        public Expedient GetExpedientByName(string name)
        {
            Arguments.NotNull(name, nameof(name));
            Arguments.NotNull(expedients, nameof(expedients));

            Models.Expedient expedient = expedients.First(expedient => expedient.ExpedientName == name);

            return expedient.ToEntity();
        }

        /// <inheritdoc />

        public void Save(Expedient expedient)
        {
            var expedientDatabaseModel = Models.Expedient.FromEntity(expedient);

            expedients.Add(expedientDatabaseModel);
        }
    }
}
