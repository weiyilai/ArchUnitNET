﻿using System.Collections.Generic;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Extensions;
using ArchUnitNETTests.Fluent.Extensions;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNETTests.Fluent.Syntax.Elements
{
    public class MemberSyntaxElementsTests
    {
        public MemberSyntaxElementsTests()
        {
            _members = Architecture.Members;
        }

        private static readonly Architecture Architecture = StaticTestArchitectures.ArchUnitNETTestArchitecture;
        private readonly IEnumerable<IMember> _members;

        [Fact]
        public void HaveBodyTypeMemberDependencies()
        {
            foreach (var member in _members)
            {
                foreach (var dependency in member.GetBodyTypeMemberDependencies())
                {
                    var memberHasDependency =
                        Members().That().Are(member).Should()
                            .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .OrShould().HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Target.Name);
                    var memberDoesNotHaveDependency = Members().That().Are(member).Should()
                        .NotHaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name).AndShould()
                        .NotHaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Target.Name);
                    var membersWithDependencyShouldExist =
                        Members().That().HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .Or()
                            .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Target.Name).Should()
                            .Exist();
                    var membersWithDependencyShouldBeOtherMembers = Members().That()
                        .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name).Or()
                        .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Target.Name).Should()
                        .NotBe(member);
                    var membersWithDependencyShouldHaveDependency = Members().That()
                        .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name).Should()
                        .HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name);
                    var membersWithDependencyExist =
                        Members().That().HaveBodyTypeMemberDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .Should().Exist();

                    Assert.True(memberHasDependency.HasNoViolations(Architecture));
                    Assert.False(memberDoesNotHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldExist.HasNoViolations(Architecture));
                    Assert.False(membersWithDependencyShouldBeOtherMembers.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyExist.HasNoViolations(Architecture));
                }

                var memberHasBodyTypeMemberDependencies =
                    Members().That().Are(member).Should().HaveBodyTypeMemberDependencies();
                var memberDoesNotHaveBodyTypeMemberDependencies =
                    Members().That().Are(member).Should().NotHaveBodyTypeMemberDependencies();
                var membersWithBodyTypeMemberDependenciesDoNotIncludeMember =
                    Members().That().HaveBodyTypeMemberDependencies().Should().NotBe(member);
                var membersWithoutBodyTypeMemberDependenciesDoNotIncludeMember =
                    Members().That().DoNotHaveBodyTypeMemberDependencies().Should().NotBe(member);

                Assert.Equal(member.HasBodyTypeMemberDependencies(),
                    memberHasBodyTypeMemberDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasBodyTypeMemberDependencies(),
                    memberDoesNotHaveBodyTypeMemberDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasBodyTypeMemberDependencies(),
                    membersWithBodyTypeMemberDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
                Assert.Equal(member.HasBodyTypeMemberDependencies(),
                    membersWithoutBodyTypeMemberDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
            }

            var membersWithBodyTypeMemberDependenciesHaveBodyTypeMemberDependencies = Members().That()
                .HaveBodyTypeMemberDependencies().Should().HaveBodyTypeMemberDependencies();
            var membersWithBodyTypeMemberDependenciesDoNotHaveBodyTypeMemberDependencies = Members().That()
                .HaveBodyTypeMemberDependencies().Should().NotHaveBodyTypeMemberDependencies().AndShould().Exist();
            var membersWithoutBodyTypeMemberDependenciesHaveBodyTypeMemberDependencies = Members().That()
                .DoNotHaveBodyTypeMemberDependencies().Should().HaveBodyTypeMemberDependencies().AndShould().Exist();
            var membersWithoutBodyTypeMemberDependenciesDoNotHaveBodyTypeMemberDependencies = Members().That()
                .DoNotHaveBodyTypeMemberDependencies().Should().NotHaveBodyTypeMemberDependencies();

            Assert.True(
                membersWithBodyTypeMemberDependenciesHaveBodyTypeMemberDependencies.HasNoViolations(Architecture));
            Assert.False(
                membersWithBodyTypeMemberDependenciesDoNotHaveBodyTypeMemberDependencies.HasNoViolations(Architecture));
            Assert.False(
                membersWithoutBodyTypeMemberDependenciesHaveBodyTypeMemberDependencies.HasNoViolations(Architecture));
            Assert.True(
                membersWithoutBodyTypeMemberDependenciesDoNotHaveBodyTypeMemberDependencies
                    .HasNoViolations(Architecture));
        }

        [Fact]
        public void HaveFieldTypeDependencies()
        {
            foreach (var member in _members)
            {
                foreach (var dependency in member.GetFieldTypeDependencies())
                {
                    var memberHasDependency =
                        Members().That().Are(member).Should()
                            .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .OrShould().HaveFieldTypeDependenciesWithFullNameContaining(dependency.Target.Name);
                    var memberDoesNotHaveDependency = Members().That().Are(member).Should()
                        .NotHaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name).AndShould()
                        .NotHaveFieldTypeDependenciesWithFullNameContaining(dependency.Target.Name);
                    var membersWithDependencyShouldExist =
                        Members().That().HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name).Or()
                            .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Target.Name).Should().Exist();
                    var membersWithDependencyShouldBeOtherMembers = Members().That()
                        .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name).Or()
                        .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Target.Name).Should().NotBe(member);
                    var membersWithDependencyShouldHaveDependency = Members().That()
                        .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name).Should()
                        .HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name);
                    var membersWithDependencyExist =
                        Members().That().HaveFieldTypeDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .Should()
                            .Exist();

                    Assert.True(memberHasDependency.HasNoViolations(Architecture));
                    Assert.False(memberDoesNotHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldExist.HasNoViolations(Architecture));
                    Assert.False(membersWithDependencyShouldBeOtherMembers.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyExist.HasNoViolations(Architecture));
                }

                var memberHasFieldTypeDependencies =
                    Members().That().Are(member).Should().HaveFieldTypeDependencies();
                var memberDoesNotHaveFieldTypeDependencies =
                    Members().That().Are(member).Should().NotHaveFieldTypeDependencies();
                var membersWithFieldTypeDependenciesDoNotIncludeMember =
                    Members().That().HaveFieldTypeDependencies().Should().NotBe(member);
                var membersWithoutFieldTypeDependenciesDoNotIncludeMember =
                    Members().That().DoNotHaveFieldTypeDependencies().Should().NotBe(member);

                Assert.Equal(member.HasFieldTypeDependencies(),
                    memberHasFieldTypeDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasFieldTypeDependencies(),
                    memberDoesNotHaveFieldTypeDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasFieldTypeDependencies(),
                    membersWithFieldTypeDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
                Assert.Equal(member.HasFieldTypeDependencies(),
                    membersWithoutFieldTypeDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
            }

            var membersWithFieldTypeDependenciesHaveFieldTypeDependencies = Members().That()
                .HaveFieldTypeDependencies().Should().HaveFieldTypeDependencies();
            var membersWithFieldTypeDependenciesDoNotHaveFieldTypeDependencies = Members().That()
                .HaveFieldTypeDependencies().Should().NotHaveFieldTypeDependencies().AndShould().Exist();
            var membersWithoutFieldTypeDependenciesHaveFieldTypeDependencies = Members().That()
                .DoNotHaveFieldTypeDependencies().Should().HaveFieldTypeDependencies().AndShould().Exist();
            var membersWithoutFieldTypeDependenciesDoNotHaveFieldTypeDependencies = Members().That()
                .DoNotHaveFieldTypeDependencies().Should().NotHaveFieldTypeDependencies();

            Assert.True(membersWithFieldTypeDependenciesHaveFieldTypeDependencies.HasNoViolations(Architecture));
            Assert.False(membersWithFieldTypeDependenciesDoNotHaveFieldTypeDependencies.HasNoViolations(Architecture));
            Assert.False(membersWithoutFieldTypeDependenciesHaveFieldTypeDependencies.HasNoViolations(Architecture));
            Assert.True(
                membersWithoutFieldTypeDependenciesDoNotHaveFieldTypeDependencies.HasNoViolations(Architecture));
        }

        [Fact]
        public void HaveMethodCallDependencies()
        {
            foreach (var member in _members)
            {
                foreach (var dependency in member.GetMethodCallDependencies())
                {
                    var memberHasDependency =
                        Members().That().Are(member).Should()
                            .HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .OrShould().HaveMethodCallDependenciesWithFullNameContaining(dependency.Target.Name);
                    var memberDoesNotHaveDependency = Members().That().Are(member).Should()
                        .NotHaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name).AndShould()
                        .NotHaveMethodCallDependenciesWithFullNameContaining(dependency.Target.Name);
                    var membersWithDependencyShouldExist =
                        Members().That().HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name).Or()
                            .HaveMethodCallDependenciesWithFullNameContaining(dependency.Target.Name).Should().Exist();
                    var membersWithDependencyShouldBeOtherMembers = Members().That()
                        .HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name).Or()
                        .HaveMethodCallDependenciesWithFullNameContaining(dependency.Target.Name).Should()
                        .NotBe(member);
                    var membersWithDependencyShouldHaveDependency = Members().That()
                        .HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name).Should()
                        .HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name);
                    var membersWithDependencyExist =
                        Members().That().HaveMethodCallDependenciesWithFullNameContaining(dependency.Origin.Name)
                            .Should()
                            .Exist();

                    Assert.True(memberHasDependency.HasNoViolations(Architecture));
                    Assert.False(memberDoesNotHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldExist.HasNoViolations(Architecture));
                    Assert.False(membersWithDependencyShouldBeOtherMembers.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyShouldHaveDependency.HasNoViolations(Architecture));
                    Assert.True(membersWithDependencyExist.HasNoViolations(Architecture));
                }

                var memberHasMethodCallDependencies =
                    Members().That().Are(member).Should().HaveMethodCallDependencies();
                var memberDoesNotHaveMethodCallDependencies =
                    Members().That().Are(member).Should().NotHaveMethodCallDependencies();
                var membersWithMethodCallDependenciesDoNotIncludeMember =
                    Members().That().HaveMethodCallDependencies().Should().NotBe(member);
                var membersWithoutMethodCallDependenciesDoNotIncludeMember =
                    Members().That().DoNotHaveMethodCallDependencies().Should().NotBe(member);

                Assert.Equal(member.HasMethodCallDependencies(),
                    memberHasMethodCallDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasMethodCallDependencies(),
                    memberDoesNotHaveMethodCallDependencies.HasNoViolations(Architecture));
                Assert.Equal(!member.HasMethodCallDependencies(),
                    membersWithMethodCallDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
                Assert.Equal(member.HasMethodCallDependencies(),
                    membersWithoutMethodCallDependenciesDoNotIncludeMember.HasNoViolations(Architecture));
            }

            var membersWithMethodCallDependenciesHaveMethodCallDependencies = Members().That()
                .HaveMethodCallDependencies().Should().HaveMethodCallDependencies();
            var membersWithMethodCallDependenciesDoNotHaveMethodCallDependencies = Members().That()
                .HaveMethodCallDependencies().Should().NotHaveMethodCallDependencies().AndShould().Exist();
            var membersWithoutMethodCallDependenciesHaveMethodCallDependencies = Members().That()
                .DoNotHaveMethodCallDependencies().Should().HaveMethodCallDependencies().AndShould().Exist();
            var membersWithoutMethodCallDependenciesDoNotHaveMethodCallDependencies = Members().That()
                .DoNotHaveMethodCallDependencies().Should().NotHaveMethodCallDependencies();

            Assert.True(membersWithMethodCallDependenciesHaveMethodCallDependencies.HasNoViolations(Architecture));
            Assert.False(
                membersWithMethodCallDependenciesDoNotHaveMethodCallDependencies.HasNoViolations(Architecture));
            Assert.False(membersWithoutMethodCallDependenciesHaveMethodCallDependencies.HasNoViolations(Architecture));
            Assert.True(
                membersWithoutMethodCallDependenciesDoNotHaveMethodCallDependencies.HasNoViolations(Architecture));
        }
    }
}