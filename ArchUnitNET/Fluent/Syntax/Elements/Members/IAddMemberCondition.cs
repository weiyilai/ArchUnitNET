using System;
using System.Collections.Generic;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Syntax.Elements.Types;

namespace ArchUnitNET.Fluent.Syntax.Elements.Members
{
    public interface IAddMemberCondition<TReturnType, TRuleType>
        : IAddObjectCondition<TReturnType, TRuleType>
        where TRuleType : ICanBeAnalyzed
    {
        TReturnType BeDeclaredIn(IType firstType, params IType[] moreTypes);
        TReturnType BeDeclaredIn(Type firstType, params Type[] moreTypes);
        TReturnType BeDeclaredIn(IObjectProvider<IType> types);
        TReturnType BeDeclaredIn(IEnumerable<IType> types);
        TReturnType BeDeclaredIn(IEnumerable<Type> types);
        ShouldRelateToTypesThat<TReturnType, TRuleType> BeDeclaredInTypesThat();

        TReturnType BeStatic();
        TReturnType BeImmutable();

        //Negations
        TReturnType NotBeDeclaredIn(IType firstType, params IType[] moreTypes);
        TReturnType NotBeDeclaredIn(Type firstType, params Type[] moreTypes);
        TReturnType NotBeDeclaredIn(IObjectProvider<IType> types);
        TReturnType NotBeDeclaredIn(IEnumerable<IType> types);
        TReturnType NotBeDeclaredIn(IEnumerable<Type> types);
        ShouldRelateToTypesThat<TReturnType, TRuleType> NotBeDeclaredInTypesThat();

        TReturnType NotBeStatic();
        TReturnType NotBeImmutable();
    }
}
