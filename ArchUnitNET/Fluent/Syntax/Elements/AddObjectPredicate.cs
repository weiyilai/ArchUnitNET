using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnitNET.Domain;
using ArchUnitNET.Domain.Extensions;
using ArchUnitNET.Fluent.Predicates;
using Attribute = ArchUnitNET.Domain.Attribute;

namespace ArchUnitNET.Fluent.Syntax.Elements
{
    public abstract class AddObjectPredicate<TGivenRuleTypeConjunction, TRelatedType, TRuleType>
        : SyntaxElement<TRelatedType>,
            IAddObjectPredicate<TGivenRuleTypeConjunction, TRuleType>
        where TRuleType : ICanBeAnalyzed
        where TRelatedType : ICanBeAnalyzed
    {
        internal AddObjectPredicate(IArchRuleCreator<TRelatedType> archRuleCreator)
            : base(archRuleCreator) { }

        // csharpier-ignore-start
        public TGivenRuleTypeConjunction FollowCustomPredicate(IPredicate<TRuleType> predicate) => CreateNextElement(predicate);
        public TGivenRuleTypeConjunction FollowCustomPredicate(Func<TRuleType, bool> predicate, string description) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.FollowCustomPredicate(predicate, description));

        public TGivenRuleTypeConjunction Are(params ICanBeAnalyzed[] objects) => Are(new ObjectProvider<ICanBeAnalyzed>(objects));
        public TGivenRuleTypeConjunction Are(IEnumerable<ICanBeAnalyzed> objects) => Are(new ObjectProvider<ICanBeAnalyzed>(objects));
        public TGivenRuleTypeConjunction Are(IObjectProvider<ICanBeAnalyzed> objects) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.Are(objects));

        public TGivenRuleTypeConjunction CallAny(params MethodMember[] methods) => CallAny(new ObjectProvider<MethodMember>(methods));
        public TGivenRuleTypeConjunction CallAny(IEnumerable<MethodMember> methods) => CallAny(new ObjectProvider<MethodMember>(methods));
        public TGivenRuleTypeConjunction CallAny(IObjectProvider<MethodMember> methods) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.CallAny(methods));

        public TGivenRuleTypeConjunction DependOnAny() => DependOnAny(new ObjectProvider<IType>());
        public TGivenRuleTypeConjunction DependOnAny(params IType[] types) => DependOnAny(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DependOnAny(params Type[] types) => DependOnAny(new SystemTypeObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DependOnAny(IObjectProvider<IType> types) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DependOnAny(types));
        public TGivenRuleTypeConjunction DependOnAny(IEnumerable<IType> types) => DependOnAny(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DependOnAny(IEnumerable<Type> types) => DependOnAny(new SystemTypeObjectProvider<IType>(types));

        public TGivenRuleTypeConjunction OnlyDependOn() => OnlyDependOn(new ObjectProvider<IType>());
        public TGivenRuleTypeConjunction OnlyDependOn(params IType[] types) => OnlyDependOn(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction OnlyDependOn(params Type[] types) => OnlyDependOn(new SystemTypeObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction OnlyDependOn(IObjectProvider<IType> types) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.OnlyDependOn(types));
        public TGivenRuleTypeConjunction OnlyDependOn(IEnumerable<IType> types) => OnlyDependOn(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction OnlyDependOn(IEnumerable<Type> types) => OnlyDependOn(new SystemTypeObjectProvider<IType>(types));

        public TGivenRuleTypeConjunction HaveAnyAttributes() => HaveAnyAttributes(new ObjectProvider<Attribute>());
        public TGivenRuleTypeConjunction HaveAnyAttributes(params Attribute[] attributes) => HaveAnyAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction HaveAnyAttributes(params Type[] attributes) => HaveAnyAttributes(new SystemTypeObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction HaveAnyAttributes(IObjectProvider<Attribute> attributes) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAnyAttributes(attributes));
        public TGivenRuleTypeConjunction HaveAnyAttributes(IEnumerable<Attribute> attributes) => HaveAnyAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction HaveAnyAttributes(IEnumerable<Type> attributes) => HaveAnyAttributes(new SystemTypeObjectProvider<Attribute>(attributes));

        public TGivenRuleTypeConjunction OnlyHaveAttributes() => OnlyHaveAttributes(new ObjectProvider<Attribute>());
        public TGivenRuleTypeConjunction OnlyHaveAttributes(params Attribute[] attributes) => OnlyHaveAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction OnlyHaveAttributes(params Type[] attributes) => OnlyHaveAttributes(new SystemTypeObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction OnlyHaveAttributes(IObjectProvider<Attribute> attributes) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.OnlyHaveAttributes(attributes));
        public TGivenRuleTypeConjunction OnlyHaveAttributes(IEnumerable<Attribute> attributes) => OnlyHaveAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction OnlyHaveAttributes(IEnumerable<Type> attributes) => OnlyHaveAttributes(new SystemTypeObjectProvider<Attribute>(attributes));

        public TGivenRuleTypeConjunction HaveAnyAttributesWithArguments(IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAnyAttributesWithArguments(argumentValues));
        public TGivenRuleTypeConjunction HaveAnyAttributesWithArguments(object firstArgumentValue, params object[] moreArgumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAnyAttributesWithArguments(new[] { firstArgumentValue }.Concat(moreArgumentValues)));

        public TGivenRuleTypeConjunction HaveAttributeWithArguments(Attribute attribute, IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAttributeWithArguments(attribute.FullName, _ => attribute, argumentValues));
        public TGivenRuleTypeConjunction HaveAttributeWithArguments(Type attribute, IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAttributeWithArguments(attribute.FullName, architecture => architecture.GetAttributeOfType(attribute), argumentValues));

        public TGivenRuleTypeConjunction HaveAnyAttributesWithNamedArguments(IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAnyAttributesWithNamedArguments(attributeArguments));
        public TGivenRuleTypeConjunction HaveAnyAttributesWithNamedArguments(params (string, object)[] attributeArguments) => HaveAnyAttributesWithNamedArguments((IEnumerable<(string, object)>)attributeArguments);

        public TGivenRuleTypeConjunction HaveAttributeWithNamedArguments(Attribute attribute, IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAttributeWithNamedArguments(attribute.FullName, _ => attribute, attributeArguments));
        public TGivenRuleTypeConjunction HaveAttributeWithNamedArguments(Attribute attribute, params (string, object)[] attributeArguments) => HaveAttributeWithNamedArguments(attribute, (IEnumerable<(string, object)>)attributeArguments);
        public TGivenRuleTypeConjunction HaveAttributeWithNamedArguments(Type attribute, IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAttributeWithNamedArguments(attribute.FullName, architecture => architecture.GetAttributeOfType(attribute), attributeArguments));
        public TGivenRuleTypeConjunction HaveAttributeWithNamedArguments(Type attribute, params (string, object)[] attributeArguments) => HaveAttributeWithNamedArguments(attribute, (IEnumerable<(string, object)>)attributeArguments);

        public TGivenRuleTypeConjunction HaveName(string name) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveName(name));
        public TGivenRuleTypeConjunction HaveNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveNameMatching(pattern));
        public TGivenRuleTypeConjunction HaveNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveNameStartingWith(pattern));
        public TGivenRuleTypeConjunction HaveNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveNameEndingWith(pattern));
        public TGivenRuleTypeConjunction HaveNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveNameContaining(pattern));

        public TGivenRuleTypeConjunction HaveFullName(string fullName) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveFullName(fullName));
        public TGivenRuleTypeConjunction HaveFullNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveFullNameMatching(pattern));
        public TGivenRuleTypeConjunction HaveFullNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveFullNameStartingWith(pattern));
        public TGivenRuleTypeConjunction HaveFullNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveFullNameEndingWith(pattern));
        public TGivenRuleTypeConjunction HaveFullNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveFullNameContaining(pattern));

        public TGivenRuleTypeConjunction HaveAssemblyQualifiedName(string assemblyQualifiedName) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAssemblyQualifiedName(assemblyQualifiedName));
        public TGivenRuleTypeConjunction HaveAssemblyQualifiedNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAssemblyQualifiedNameMatching(pattern));
        public TGivenRuleTypeConjunction HaveAssemblyQualifiedNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAssemblyQualifiedNameStartingWith(pattern));
        public TGivenRuleTypeConjunction HaveAssemblyQualifiedNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAssemblyQualifiedNameEndingWith(pattern));
        public TGivenRuleTypeConjunction HaveAssemblyQualifiedNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.HaveAssemblyQualifiedNameContaining(pattern));

        public TGivenRuleTypeConjunction ArePrivate() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.ArePrivate());
        public TGivenRuleTypeConjunction ArePublic() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.ArePublic());
        public TGivenRuleTypeConjunction AreProtected() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreProtected());
        public TGivenRuleTypeConjunction AreInternal() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreInternal());
        public TGivenRuleTypeConjunction AreProtectedInternal() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreProtectedInternal());
        public TGivenRuleTypeConjunction ArePrivateProtected() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.ArePrivateProtected());

        // Negations

        public TGivenRuleTypeConjunction AreNot(params ICanBeAnalyzed[] objects) => AreNot(new ObjectProvider<ICanBeAnalyzed>(objects));
        public TGivenRuleTypeConjunction AreNot(IEnumerable<ICanBeAnalyzed> objects) => AreNot(new ObjectProvider<ICanBeAnalyzed>(objects));
        public TGivenRuleTypeConjunction AreNot(IObjectProvider<ICanBeAnalyzed> objects) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNot(objects));

        public TGivenRuleTypeConjunction DoNotCallAny(params MethodMember[] methods) => DoNotCallAny(new ObjectProvider<MethodMember>(methods));
        public TGivenRuleTypeConjunction DoNotCallAny(IEnumerable<MethodMember> methods) => DoNotCallAny(new ObjectProvider<MethodMember>(methods));
        public TGivenRuleTypeConjunction DoNotCallAny(IObjectProvider<MethodMember> methods) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotCallAny(methods));

        public TGivenRuleTypeConjunction DoNotDependOnAny() => DoNotDependOnAny(new ObjectProvider<IType>());
        public TGivenRuleTypeConjunction DoNotDependOnAny(params IType[] types) => DoNotDependOnAny(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DoNotDependOnAny(params Type[] types) => DoNotDependOnAny(new SystemTypeObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DoNotDependOnAny(IObjectProvider<IType> types) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotDependOnAny(types));
        public TGivenRuleTypeConjunction DoNotDependOnAny(IEnumerable<IType> types) => DoNotDependOnAny(new ObjectProvider<IType>(types));
        public TGivenRuleTypeConjunction DoNotDependOnAny(IEnumerable<Type> types) => DoNotDependOnAny(new SystemTypeObjectProvider<IType>(types));

        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes() => DoNotHaveAnyAttributes(new ObjectProvider<Attribute>());
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes(params Attribute[] attributes) => DoNotHaveAnyAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes(params Type[] attributes) => DoNotHaveAnyAttributes(new SystemTypeObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes(IObjectProvider<Attribute> attributes) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAnyAttributes(attributes));
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes(IEnumerable<Attribute> attributes) => DoNotHaveAnyAttributes(new ObjectProvider<Attribute>(attributes));
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributes(IEnumerable<Type> attributes) => DoNotHaveAnyAttributes(new SystemTypeObjectProvider<Attribute>(attributes));

        public TGivenRuleTypeConjunction DoNotHaveAnyAttributesWithArguments(IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAnyAttributesWithArguments(argumentValues));

        public TGivenRuleTypeConjunction DoNotHaveAttributeWithArguments(Attribute attribute, IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAttributeWithArguments(attribute.FullName, _ => attribute, argumentValues));
        public TGivenRuleTypeConjunction DoNotHaveAttributeWithArguments(Type attribute, IEnumerable<object> argumentValues) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAttributeWithArguments(attribute.FullName, architecture => architecture.GetAttributeOfType(attribute), argumentValues));

        public TGivenRuleTypeConjunction DoNotHaveAnyAttributesWithNamedArguments(IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAnyAttributesWithNamedArguments(attributeArguments));
        public TGivenRuleTypeConjunction DoNotHaveAnyAttributesWithNamedArguments(params (string, object)[] attributeArguments) => DoNotHaveAnyAttributesWithNamedArguments((IEnumerable<(string, object)>)attributeArguments);

        public TGivenRuleTypeConjunction DoNotHaveAttributeWithNamedArguments(Attribute attribute, IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAttributeWithNamedArguments(attribute.FullName, _ => attribute, attributeArguments));
        public TGivenRuleTypeConjunction DoNotHaveAttributeWithNamedArguments(Attribute attribute, params (string, object)[] attributeArguments) => DoNotHaveAttributeWithNamedArguments(attribute, (IEnumerable<(string, object)>)attributeArguments);
        public TGivenRuleTypeConjunction DoNotHaveAttributeWithNamedArguments(Type attribute, IEnumerable<(string, object)> attributeArguments) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAttributeWithNamedArguments(attribute.FullName, architecture => architecture.GetAttributeOfType(attribute), attributeArguments));
        public TGivenRuleTypeConjunction DoNotHaveAttributeWithNamedArguments(Type attribute, params (string, object)[] attributeArguments) => DoNotHaveAttributeWithNamedArguments(attribute, (IEnumerable<(string, object)>)attributeArguments);

        public TGivenRuleTypeConjunction DoNotHaveName(string name) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveName(name));
        public TGivenRuleTypeConjunction DoNotHaveNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveNameMatching(pattern));
        public TGivenRuleTypeConjunction DoNotHaveNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveNameStartingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveNameEndingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveNameContaining(pattern));

        public TGivenRuleTypeConjunction DoNotHaveFullName(string fullName) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveFullName(fullName));
        public TGivenRuleTypeConjunction DoNotHaveFullNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveFullNameMatching(pattern));
        public TGivenRuleTypeConjunction DoNotHaveFullNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveFullNameStartingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveFullNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveFullNameEndingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveFullNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveFullNameContaining(pattern));

        public TGivenRuleTypeConjunction DoNotHaveAssemblyQualifiedName(string assemblyQualifiedName) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAssemblyQualifiedName(assemblyQualifiedName));
        public TGivenRuleTypeConjunction DoNotHaveAssemblyQualifiedNameMatching(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAssemblyQualifiedNameMatching(pattern));
        public TGivenRuleTypeConjunction DoNotHaveAssemblyQualifiedNameStartingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAssemblyQualifiedNameStartingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveAssemblyQualifiedNameEndingWith(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAssemblyQualifiedNameEndingWith(pattern));
        public TGivenRuleTypeConjunction DoNotHaveAssemblyQualifiedNameContaining(string pattern) => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.DoNotHaveAssemblyQualifiedNameContaining(pattern));

        public TGivenRuleTypeConjunction AreNotPrivate() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotPrivate());
        public TGivenRuleTypeConjunction AreNotPublic() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotPublic());
        public TGivenRuleTypeConjunction AreNotProtected() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotProtected());
        public TGivenRuleTypeConjunction AreNotInternal() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotInternal());
        public TGivenRuleTypeConjunction AreNotProtectedInternal() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotProtectedInternal());
        public TGivenRuleTypeConjunction AreNotPrivateProtected() => CreateNextElement(ObjectPredicatesDefinition<TRuleType>.AreNotPrivateProtected());
        // csharpier-ignore-end

        protected abstract TGivenRuleTypeConjunction CreateNextElement(IPredicate<TRuleType> predicate);
    }
}
