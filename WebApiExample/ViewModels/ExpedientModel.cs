using Optional.Unsafe;
using Triplex.Validations;

namespace WebApiExample.ViewModels
{
    /// <summary>
    /// Represents an expedient model.
    /// </summary>
    public class ExpedientModel
    {
        /// <summary>
        /// Indicates expedient's name.
        /// </summary>
        public string ExpedientName { get; set; }

        /// <summary>
        /// Indicates expedient's author name.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Converts to Expedient entity.
        /// </summary>
        /// <returns>An instance of <see cref="RI.Novus.Core.CadastralSurvey.Expedients.Expedient"/></returns>
        public RI.Novus.Core.CadastralSurvey.Expedients.Expedient ToEntity()
        {
            return new RI.Novus.Core.CadastralSurvey.Expedients.Expedient.Builder()
                  .WithExpedientName(RI.Novus.Core.CadastralSurvey.Expedients.ExpedientName.From(ExpedientName))
                  .WithAuthorName(RI.Novus.Core.CadastralSurvey.Expedients.AuthorName.From(AuthorName))
                  .Build();
        }

        public static ExpedientModel FromEntity(RI.Novus.Core.CadastralSurvey.Expedients.Expedient expedient)
        {
            Arguments.NotNull(expedient, nameof(expedient));

            return new ExpedientModel()
            {
                ExpedientName = expedient.ExpedientName.Value,
                AuthorName = expedient.AuthorName.ValueOrDefault().ToString(),
            };
            
           
        }
    }
}
