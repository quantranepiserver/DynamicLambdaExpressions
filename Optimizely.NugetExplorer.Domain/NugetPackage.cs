using System;
using System.Collections.Generic;

namespace Optimizely.NugetExplorer.Domain
{
    public class NugetPackage
    {
        public NugetPackage()
        {
            Identifier = System.Guid.NewGuid();
            Tags = new List<string>();
        }

        public System.Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseNote { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool InternalOnly { get; set; }
        public DotnetFlavor NetFlavor { get; set; }
        public int TotalDownload { get; set; }

        public string InternalOnlyDisplay
        {
            get
            {
                return InternalOnly
                    ? "Yes"
                    : "No";
            }
        }
    }
}
