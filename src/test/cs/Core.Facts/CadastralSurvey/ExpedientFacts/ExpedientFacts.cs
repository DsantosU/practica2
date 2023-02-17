using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Facts.CadastralSurvey.ExpedientFacts
{
    /*
      Persist no debe recibir una instancia del repositorio vacia
     
     */
    [TestFixture]
    internal class ExpedientFacts
    {
        [Test]
        public void When_Using_Persist_With_Null_Repository_Throws_Argument_Exception()
        {
            //Arrange
            string expedientName = "Expedient1";

            IExpedientRepositoryDummy? expedientRepositoryDummy = null;

             var expedient = new RI.Novus.Core.CadastralSurvey.Expedients.Expedient.Builder()
              .WithExpedientName(RI.Novus.Core.CadastralSurvey.Expedients.ExpedientName.From(expedientName))
              .Build();


            // Assert
            Assert.That(() =>
            {
                expedient.Persist(expedientRepositoryDummy: expedientRepositoryDummy);

            }, Throws.ArgumentNullException);

        }
    }
}
