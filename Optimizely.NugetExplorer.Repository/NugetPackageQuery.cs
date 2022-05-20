using Optimizely.NugetExplorer.Domain;
using System.Collections.Generic;

namespace Optimizely.NugetExplorer.Repository
{
    public class NugetPackageQuery
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public bool? InternalOnly { get; set; }
        public DotnetFlavor? NetFlavor { get; set; }
        public int? TotalDownload { get; set; }
        public string Tag { get; set; }
    }
}
