using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types.Attributes
{
    public interface IAddAttributePredicate<out TReturnType, TRuleType>
        : IAddTypePredicate<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed
    {
        TReturnType AreAbstract();
        TReturnType AreSealed();

        //Negations

        TReturnType AreNotAbstract();
        TReturnType AreNotSealed();
    }
}
