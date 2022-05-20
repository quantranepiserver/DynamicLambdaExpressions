using Optimizely.NugetExplorer.Domain;
using System.Collections.Generic;

namespace Optimizely.NugetExplorer.Repository
{
    public interface INugetPackageRepository
    {
        public List<NugetPackage> Search(NugetPackageQuery query);
        public List<NugetPackage> GetAll();
    }
}
