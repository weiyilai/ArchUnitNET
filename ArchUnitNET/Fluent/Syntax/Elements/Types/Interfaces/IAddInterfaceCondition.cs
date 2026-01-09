using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types.Interfaces
{
    public interface IAddInterfaceCondition<TReturnType, TRuleType>
        : IAddTypeCondition<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed { }
}
