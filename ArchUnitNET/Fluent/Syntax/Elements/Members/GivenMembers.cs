﻿using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent.Syntax.Elements.Members
{
    public class GivenMembers
        : GivenObjects<
            GivenMembersThat<GivenMembersConjunction, IMember>,
            MembersShould<MembersShouldConjunction, IMember>,
            IMember
        >
    {
        public GivenMembers(IArchRuleCreator<IMember> ruleCreator)
            : base(ruleCreator) { }
    }
}
