using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnitNET.Domain.Dependencies;

namespace ArchUnitNET.Domain.Extensions
{
    public static class MemberExtensions
    {
        public static bool IsDeclaredIn(this IMember member, string fullName)
        {
            return member.DeclaringType.FullNameEquals(fullName);
        }

        public static bool IsDeclaredInTypeMatching(this IMember member, string pattern)
        {
            return member.DeclaringType.FullNameMatches(pattern);
        }

        public static bool IsDeclaredIn(this IMember member, IType type)
        {
            return member.DeclaringType.Equals(type);
        }

        public static IEnumerable<BodyTypeMemberDependency> GetBodyTypeMemberDependencies(
            this IMember member,
            bool getBackwardsDependencies = false
        )
        {
            return getBackwardsDependencies
                ? member.MemberBackwardsDependencies.OfType<BodyTypeMemberDependency>()
                : member.MemberDependencies.OfType<BodyTypeMemberDependency>();
        }

        public static bool HasBodyTypeMemberDependencies(
            this IMember member,
            bool getBackwardsDependencies = false
        )
        {
            return member.GetBodyTypeMemberDependencies(getBackwardsDependencies).Any();
        }

        public static IEnumerable<MethodCallDependency> GetMethodCallDependencies(
            this IMember member,
            bool getBackwardsDependencies = false
        )
        {
            return getBackwardsDependencies
                ? member.MemberBackwardsDependencies.OfType<MethodCallDependency>()
                : member.MemberDependencies.OfType<MethodCallDependency>();
        }

        public static bool HasMethodCallDependencies(
            this IMember member,
            bool getBackwardsDependencies = false
        )
        {
            return member.GetMethodCallDependencies(getBackwardsDependencies).Any();
        }

        public static bool IsCalledByType(this MethodMember member, string fullName)
        {
            return member
                .GetMethodCallDependencies(true)
                .Any(dependency => dependency.Origin.FullNameEquals(fullName));
        }

        public static bool IsCalledByTypeMatching(this MethodMember member, string pattern)
        {
            return member
                .GetMethodCallDependencies(true)
                .Any(dependency => dependency.Origin.FullNameMatches(pattern));
        }

        public static IEnumerable<IType> GetCallingTypes(this MethodMember member)
        {
            return member
                .MemberBackwardsDependencies.OfType<MethodCallDependency>()
                .Select(dependency => dependency.Origin)
                .Distinct();
        }

        public static bool HasDependencyInMethodBodyToType(
            this MethodMember member,
            string fullName
        )
        {
            return member
                .GetBodyTypeMemberDependencies()
                .Any(dependency => dependency.Target.FullNameEquals(fullName));
        }

        public static bool HasDependencyInMethodBodyToTypeMatching(
            this MethodMember member,
            string pattern
        )
        {
            return member
                .GetBodyTypeMemberDependencies()
                .Any(dependency => dependency.Target.FullNameMatches(pattern));
        }

        public static bool HasFieldTypeDependencies(
            this IMember member,
            bool getBackwardsDependencies = false
        )
        {
            return member.GetFieldTypeDependencies(getBackwardsDependencies).Any();
        }

        public static Attribute GetAttributeFromMember(this IMember member, Class attributeClass)
        {
            return member.Attributes.FirstOrDefault(attribute =>
                attribute.FullName.Equals(attributeClass.FullName)
            );
        }

        public static bool HasMethodSignatureDependency(
            this IMember member,
            MethodSignatureDependency methodSignatureDependency,
            bool getBackwardsDependencies = false
        )
        {
            return getBackwardsDependencies
                ? member
                    .MemberBackwardsDependencies.OfType<MethodSignatureDependency>()
                    .Contains(methodSignatureDependency)
                : member
                    .MemberDependencies.OfType<MethodSignatureDependency>()
                    .Contains(methodSignatureDependency);
        }

        public static bool HasMemberDependency(
            this IMember member,
            IMemberTypeDependency memberDependency,
            bool getBackwardsDependencies = false
        )
        {
            return getBackwardsDependencies
                ? member.MemberBackwardsDependencies.Contains(memberDependency)
                : member.MemberDependencies.Contains(memberDependency);
        }

        public static bool HasDependency(
            this IMember member,
            IMemberTypeDependency memberDependency,
            bool getBackwardsDependencies = false
        )
        {
            return getBackwardsDependencies
                ? member.BackwardsDependencies.Contains(memberDependency)
                : member.Dependencies.Contains(memberDependency);
        }

        public static bool IsConstructor(this MethodMember methodMember)
        {
            return methodMember.MethodForm == MethodForm.Constructor;
        }
    }
}
