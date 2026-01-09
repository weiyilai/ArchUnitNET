using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Members.FieldMembers
{
    public interface IAddFieldMemberPredicate<out TReturnType, TRuleType>
        : IAddMemberPredicate<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed { }
}
