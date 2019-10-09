﻿/*
 * Copyright 2019 Florian Gather <florian.gather@tngtech.com>
 * Copyright 2019 Paula Ruiz <paularuiz22@gmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Collections.Generic;
using JetBrains.Annotations;

namespace ArchUnitNET.Domain
{
    public interface IType : ICanBeAnalyzed
    {
        Namespace Namespace { get; }
        Assembly Assembly { get; }
        MemberList Members { get; }
        List<IType> GenericTypeParameters { get; }
        List<IType> GenericTypeArguments { get; }
        [CanBeNull] IType GenericType { get; }
        bool IsNested { get; }
        IEnumerable<IType> ImplementedInterfaces { get; }
        bool Implements(IType intf);
        bool ImplementsInterfacesWithFullNameMatching(string pattern);
        bool ImplementsInterfacesWithFullNameContaining(string pattern);
        bool IsAssignableTo(IType assignableToType);
        bool IsAssignableToTypesWithFullNameMatching(string pattern);
        bool IsAssignableToTypesWithFullNameContaining(string pattern);
    }
}