//using RI.Novus.Core.TitleRegistration;

//namespace RI.Novus.Core.Facts.TitleRegistration.TitleFacts.CadastralDesignationFacts;

//internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<CadastralDesignation>
//{
//    protected override Context BuildContext()
//    {
//        const string rawEmail = "309389908904 301";
//        CadastralDesignation subject = new(rawEmail);

//        return new Context(
//            lessThanSubject: new CadastralDesignation("309389908904 300"),
//            subject: subject,
//            subjectCopy: new CadastralDesignation(rawEmail),
//            otherSemanticallyEqualsToSubject: new CadastralDesignation("309389908904 301"),
//            greatherThanSubject: new CadastralDesignation("309389908904 302"),
//            testRelationalOperatorsOverload: true);
//    }

//    protected override bool ExecuteEqualsOperator(CadastralDesignation left, CadastralDesignation right)
//        => left == right;
//    protected override bool ExecuteNotEqualsOperator(CadastralDesignation left, CadastralDesignation right)
//        => left != right;
//    protected override bool ExecuteLessThanOperator(CadastralDesignation left, CadastralDesignation right)
//        => left < right;
//    protected override bool ExecuteLessThanOrEqualsToOperator(CadastralDesignation left, CadastralDesignation right)
//        => left <= right;
//    protected override bool ExecuteGreaterThanOperator(CadastralDesignation left, CadastralDesignation right)
//        => left > right;
//    protected override bool ExecuteGreaterThanOrEqualsToOperator(CadastralDesignation left, CadastralDesignation right)
//        => left >= right;
//}
