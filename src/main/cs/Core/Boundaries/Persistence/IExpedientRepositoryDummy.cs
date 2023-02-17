using RI.Novus.Core.CadastralSurvey.Expedients;

namespace RI.Novus.Core.Boundaries.Persistence
{
    /// <summary>
    /// Provides the contract to provide methods to interact with expedients.
    /// </summary>
    public interface IExpedientRepositoryDummy
    {
        /// <summary>
        /// Gets expedient by name
        /// </summary>
        /// <param name="name">Expedient name</param>
        /// <returns>An instance of <see cref="Expedient"/></returns>
        Expedient GetExpedientByName(string name);

        /// <summary>
        /// Persist a given expedient.
        /// </summary>
        /// <param name="expedient">Expedient to be persisted.</param>
        void Save(Expedient expedient);
    }
}
