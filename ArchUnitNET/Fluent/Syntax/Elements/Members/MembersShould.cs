﻿using System;
using System.Collections.Generic;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Syntax.Elements.Types;
using static ArchUnitNET.Fluent.Syntax.ConjunctionFactory;

namespace ArchUnitNET.Fluent.Syntax.Elements.Members
{
    public class MembersShould<TRuleTypeShouldConjunction, TRuleType>
        : ObjectsShould<TRuleTypeShouldConjunction, TRuleType>,
            IComplexMemberConditions<TRuleTypeShouldConjunction, TRuleType>
        where TRuleType : IMember
        where TRuleTypeShouldConjunction : SyntaxElement<TRuleType>
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public MembersShould(IArchRuleCreator<TRuleType> ruleCreator)
            : base(ruleCreator) { }

        public TRuleTypeShouldConjunction BeDeclaredIn(IType firstType, params IType[] moreTypes)
        {
            _ruleCreator.AddCondition(
                MemberConditionsDefinition<TRuleType>.BeDeclaredIn(firstType, moreTypes)
            );
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeDeclaredIn(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddCondition(
                MemberConditionsDefinition<TRuleType>.BeDeclaredIn(firstType, moreTypes)
            );
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeDeclaredIn(IObjectProvider<IType> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeDeclaredIn(IEnumerable<IType> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeDeclaredIn(IEnumerable<Type> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeStatic()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeStatic());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeReadOnly()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeReadOnly());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction BeImmutable()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.BeImmutable());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        //Relation Conditions

        public ShouldRelateToTypesThat<
            TRuleTypeShouldConjunction,
            IType,
            TRuleType
        > BeDeclaredInTypesThat()
        {
            _ruleCreator.BeginComplexCondition(
                ArchRuleDefinition.Types(true),
                MemberConditionsDefinition<TRuleType>.BeDeclaredInTypesThat()
            );
            return new ShouldRelateToTypesThat<TRuleTypeShouldConjunction, IType, TRuleType>(
                _ruleCreator
            );
        }

        //Negations

        public TRuleTypeShouldConjunction NotBeDeclaredIn(IType firstType, params IType[] moreTypes)
        {
            _ruleCreator.AddCondition(
                MemberConditionsDefinition<TRuleType>.NotBeDeclaredIn(firstType, moreTypes)
            );
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeDeclaredIn(Type firstType, params Type[] moreTypes)
        {
            _ruleCreator.AddCondition(
                MemberConditionsDefinition<TRuleType>.NotBeDeclaredIn(firstType, moreTypes)
            );
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeDeclaredIn(IObjectProvider<IType> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeDeclaredIn(IEnumerable<IType> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeDeclaredIn(IEnumerable<Type> types)
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeDeclaredIn(types));
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeStatic()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeStatic());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeReadOnly()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeReadOnly());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        public TRuleTypeShouldConjunction NotBeImmutable()
        {
            _ruleCreator.AddCondition(MemberConditionsDefinition<TRuleType>.NotBeImmutable());
            return Create<TRuleTypeShouldConjunction, TRuleType>(_ruleCreator);
        }

        //Relation Condition Negations

        public ShouldRelateToTypesThat<
            TRuleTypeShouldConjunction,
            IType,
            TRuleType
        > NotBeDeclaredInTypesThat()
        {
            _ruleCreator.BeginComplexCondition(
                ArchRuleDefinition.Types(true),
                MemberConditionsDefinition<TRuleType>.NotBeDeclaredInTypesThat()
            );
            return new ShouldRelateToTypesThat<TRuleTypeShouldConjunction, IType, TRuleType>(
                _ruleCreator
            );
        }
    }
}
