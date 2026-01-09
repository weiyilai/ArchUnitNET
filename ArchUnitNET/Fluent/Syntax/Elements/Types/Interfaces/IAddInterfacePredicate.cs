using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Types.Interfaces
{
    public interface IAddInterfacePredicate<out TReturnType, TRuleType>
        : IAddTypePredicate<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed { }
}
