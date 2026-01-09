using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(
    "ArchUnitNETTests, PublicKey=002400000480000094000000060200000024000052534131000400000100010061b41c9ec5575b4b70ba7feca6e64a865c64f15dfc76a057f7fb3b5a0bbecab64b0ad0ec04ea20fa0d370357c786bd80d1bf92ac91ef021ccd9394e08871eca28f9ad8ae58f18bb518707839f38a8e3a10f33e0a0525f3e4bae3e4da391efe7d0fb41cc03f63923065aa1efe6f440bd0669284668863f87284a8a40d3b604db9"
)]

namespace ArchUnitNET.Domain.PlantUml.Import
{
    internal class PlantUmlParsedDiagram
    {
        private PlantUmlComponents _plantUmlComponents;

        public PlantUmlParsedDiagram(PlantUmlComponents plantUmlComponents)
        {
            _plantUmlComponents =
                plantUmlComponents ?? throw new ArgumentNullException(nameof(plantUmlComponents));
        }

        public ISet<PlantUmlComponent> AllComponents
        {
            get { return _plantUmlComponents.AllComponents.ToImmutableHashSet(); }
        }

        public ISet<PlantUmlComponent> ComponentsWithAlias
        {
            get { return _plantUmlComponents.CompomenentsWithAlias.ToImmutableHashSet(); }
        }
    }
}
