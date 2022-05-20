using System;

namespace Optimizely.NugetExplorer.Domain
{
    public static class Extensions
    {
        public static string DotNetFlavorName(this DotnetFlavor dotnetFlavor)
        {
            return Enum.GetName(typeof(DotnetFlavor), dotnetFlavor);
        }
    }
}
