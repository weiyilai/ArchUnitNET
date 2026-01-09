using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types.Classes
{
    public interface IAddClassCondition<TReturnType, TRuleType>
        : IAddTypeCondition<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed
    {
        TReturnType BeAbstract();
        TReturnType BeSealed();
        TReturnType BeImmutable();

        //Negations

        TReturnType NotBeAbstract();
        TReturnType NotBeSealed();
        TReturnType NotBeImmutable();
    }
}
