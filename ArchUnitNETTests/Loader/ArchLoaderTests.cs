﻿//  Copyright 2019 Florian Gather <florian.gather@tngtech.com>
// 	Copyright 2019 Paula Ruiz <paularuiz22@gmail.com>
// 	Copyright 2019 Fritz Brandhuber <fritz.brandhuber@tngtech.com>
//
// 	SPDX-License-Identifier: Apache-2.0

using System.Linq;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using ArchUnitNETTests.Domain.Dependencies.Members;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ArchUnitNETTests.StaticTestArchitectures;

namespace ArchUnitNETTests.Loader
{
    public class ArchLoaderTests
    {
        [Fact]
        public void LoadAssemblies()
        {
            Assert.Equal(4, FullArchUnitNETArchitecture.Assemblies.Count());
            Assert.Single(ArchUnitNETTestArchitecture.Assemblies);
            Assert.Single(ArchUnitNETTestAssemblyArchitecture.Assemblies);
            Assert.NotEmpty(FullArchUnitNETArchitectureWithDependencies.Assemblies);
            Assert.NotEmpty(ArchUnitNETTestArchitectureWithDependencies.Assemblies);
            Assert.NotEmpty(ArchUnitNETTestAssemblyArchitectureWithDependencies.Assemblies);
        }

        [Fact]
        public void SameFullNameInMultipleAssemblies()
        {
            var types = LoaderTestArchitecture.Types.Where(type =>
                type.Namespace.FullName == "DuplicateClassAcrossAssemblies"
            );
            Assert.Equal(2, types.Count());
            Assert.Single(types, type => type.Assembly.Name.StartsWith("LoaderTestAssembly"));
            Assert.Single(types, type => type.Assembly.Name.StartsWith("OtherLoaderTestAssembly"));
        }

        [Fact]
        public void LoadAssembliesIncludingRecursiveDependencies()
        {
            var architecture = new ArchLoader()
                .LoadAssembliesIncludingDependencies(new[] { typeof(BaseClass).Assembly }, true)
                .Build();

            Assert.True(
                architecture.Assemblies.Count() > 100
            );

            // Check for well-known assemblies, that ReferencedAssemblyNames is not empty
            Assert.All(
                architecture.Assemblies.Where(x => x.Name.StartsWith("ArchUnit")),
                x => Assert.NotEmpty(x.ReferencedAssemblyNames)
            );
        }

        [Fact]
        public void LoadAssembliesRecursivelyWithCustomFilter()
        {
            FilterFunc filterFunc = assembly =>
                assembly.Name.Name.StartsWith("ArchUnit")
                    ? FilterResult.LoadAndContinue
                    : FilterResult.DontLoadAndStop;
            var loader = new ArchLoader();
            var architecture = loader
                .LoadAssembliesRecursively(new[] { typeof(BaseClass).Assembly }, filterFunc)
                .Build();

            Assert.Equal(3, architecture.Assemblies.Count());

            // Check that ReferencedAssemblyNames is not empty
            Assert.All(
                architecture.Assemblies,
                x => Assert.NotEmpty(x.ReferencedAssemblyNames)
            );
        }

        [Fact]
        public void LoadAssembliesRecursively_NestedDependencyOnly()
        {
            FilterFunc filterFunc = assembly =>
            {
                if (assembly.Name.Name == "ArchUnitNet")
                    return FilterResult.LoadAndStop;

                return FilterResult.SkipAndContinue;
            };
            var loader = new ArchLoader();
            var architecture = loader
                .LoadAssembliesRecursively(new[] { typeof(BaseClass).Assembly }, filterFunc)
                .Build();

            Assert.Single(architecture.Assemblies);
        }

        [Fact]
        public void TypesAreAssignedToCorrectAssemblies()
        {
            // https://github.com/TNG/ArchUnitNET/issues/302
            var architecture = FullArchUnitNETArchitecture;
            Types()
                .That()
                .ResideInAssembly(architecture.GetType().Assembly)
                .Should()
                .NotDependOnAnyTypesThat()
                .ResideInAssembly(GetType().Assembly)
                .Check(architecture);
        }
    }
}
