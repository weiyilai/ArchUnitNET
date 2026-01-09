using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Members.FieldMembers
{
    public interface IAddFieldMemberCondition<TReturnType, TRuleType>
        : IAddMemberCondition<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed { }
}
