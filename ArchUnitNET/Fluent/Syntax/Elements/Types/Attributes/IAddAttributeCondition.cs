using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types.Attributes
{
    public interface IAddAttributeCondition<TReturnType, TRuleType>
        : IAddTypeCondition<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed
    {
        TReturnType BeAbstract();
        TReturnType BeSealed();

        //Negations

        TReturnType NotBeAbstract();
        TReturnType NotBeSealed();
    }
}
