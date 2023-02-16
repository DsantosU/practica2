

using Optional.Unsafe;
using Triplex.Validations;

namespace Persistence.Models;

/// <summary>
/// Represents the database representation for an expedient.
/// </summary>
public class Expedient
{
    /// <summary>
    /// Creates an instance of <see cref="Expedient"/>
    /// </summary>
    /// <param name="expedientName"></param>
    public Expedient(string expedientName, string authorName)
    {
        this.ExpedientName = expedientName;
        this.AuthorName = authorName;
    }

    /// <summary>
    /// Indicates expedient name
    /// </summary>
    public string ExpedientName { get; set; } = string.Empty;

    /// <summary>
    /// Indicates author name
    /// </summary>
    public string? AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// Converts current model to Expedient entity.
    /// </summary>
    /// <returns>An instance of <see cref="RI.Novus.Core.CadastralSurvey.Expedients.Expedient"/></returns>
    public RI.Novus.Core.CadastralSurvey.Expedients.Expedient ToEntity()
    {
        return new RI.Novus.Core.CadastralSurvey.Expedients.Expedient.Builder()
                     .WithExpedientName(RI.Novus.Core.CadastralSurvey.Expedients.ExpedientName.From(ExpedientName))
                     .WithAuthorName(RI.Novus.Core.CadastralSurvey.Expedients.AuthorName.From(AuthorName))
                     .Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expedient"></param>
    /// <returns></returns>

    public static Expedient FromEntity(RI.Novus.Core.CadastralSurvey.Expedients.Expedient expedient)
    {
        Arguments.NotNull(expedient, nameof(expedient));

        return new Expedient(
            expedient.ExpedientName.Value, 
            expedient.AuthorName.ValueOrDefault().Value
            );
    }
}
