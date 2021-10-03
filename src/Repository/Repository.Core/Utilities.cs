using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core
{
    public static class Utilities
    {
        public static ImmutableHashSet<string> FilterableAdvertColumnNames { get; } = ImmutableHashSet.Create("year", "price","km");
    }
}
