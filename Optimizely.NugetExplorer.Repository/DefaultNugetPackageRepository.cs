using Optimizely.NugetExplorer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optimizely.NugetExplorer.Repository
{
    public class DefaultNugetPackageRepository : INugetPackageRepository
    {
        public List<NugetPackage> Search(NugetPackageQuery query)
        {
            if (query is null)
            {
                return GetAll();
            }

            var expressionBuilder = new NugetPackageExpressionBuilder();
            var searchExpression = expressionBuilder.BuildExpression(query);
            if (searchExpression is object)
            {
                // var searchFunc = searchExpression.Compile();
                // return GetAll().Where(searchFunc).ToList();
                return GetAll().AsQueryable().Where(searchExpression).ToList();
            }

            return GetAll();
        }

        public List<NugetPackage> GetAll()
        {
            var list = new List<NugetPackage>();

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Cms.Core",
                Version = "1.0.0.0",
                ReleaseDate = new DateTime(2000, 12, 12),
                ReleaseNote = "First release of EPiServer.Cms.Core",
                Tags = new[] {"EPiServer", "Cms Core", "Optimizely" , "First Release"},
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 1_000_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Cms.Core",
                Version = "2.0.0.0",
                ReleaseDate = new DateTime(2001, 12, 1),
                ReleaseNote = "EPiServer.Cms.Core version 2",
                Tags = new[] { "EPiServer", "Cms Core", "Optimizely" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 2_000_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Cms.UI",
                Version = "1.0.0.0",
                ReleaseDate = new DateTime(2000, 12, 12),
                ReleaseNote = "First release of EPiServer.Cms.UI",
                Tags = new[] { "EPiServer", "Cms UI", "Optimizely", "First Release" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 1_200_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Cms.UI",
                Version = "2.0.0.0",
                ReleaseDate = new DateTime(2001, 12, 1),
                ReleaseNote = "EPiServer.Cms.UI version 2",
                Tags = new[] { "EPiServer", "Cms UI", "Optimizely", "2nd Release" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 1_500_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Framework",
                Version = "1.0.0.0",
                ReleaseDate = new DateTime(2000, 12, 12),
                Tags = new[] { "EPiServer", "Cms" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 1_900_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.CMS.UI.Core",
                Version = "1.0.0.0",
                ReleaseDate = new DateTime(2000, 12, 12),
                Tags = new[] { "EPiServer", "Cms UI" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 1_600_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.CMS.TinyMce",
                Version = "1.0.0.0",
                ReleaseDate = new DateTime(2000, 12, 12),
                Tags = new[] { "EPiServer", "TinyMce" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 1_300_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.ServiceLocation.StructureMap",
                Version = "3.0.0.0",
                ReleaseDate = new DateTime(2010, 11, 11),
                Tags = new[] { "EPiServer", "TinyMce" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 1_800_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Logging.Log4Net",
                Version = "2.5.0.0",
                ReleaseDate = new DateTime(2011, 5, 5),
                Tags = new[] { "EPiServer", "Logging" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 1_900_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Find",
                Version = "3.5.0.0",
                ReleaseDate = new DateTime(2019, 5, 5),
                Tags = new[] { "EPiServer", "Find" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 2_100_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Azure",
                Version = "4.5.0.0",
                ReleaseDate = new DateTime(2019, 5, 5),
                Tags = new[] { "EPiServer", "Azure" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 2_200_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Forms.Core",
                Version = "4.5.0.0",
                ReleaseDate = new DateTime(2019, 5, 5),
                Tags = new[] { "EPiServer", "Forms" , "NetCore"},
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 2_300_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Forms.UI",
                Version = "4.5.0.0",
                ReleaseDate = new DateTime(2020, 6, 15),
                Tags = new[] { "EPiServer", "Forms.UI", "NetCore" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 2_300_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Addons.Helpers",
                Version = "4.5.0.0",
                ReleaseDate = new DateTime(2020, 6, 15),
                Tags = new[] { "EPiServer", "Addons", "NetCore" , "Helpers" },
                InternalOnly = false,
                NetFlavor = DotnetFlavor.NetCore,
                TotalDownload = 300_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Data.Analyzers.Core",
                Version = "2.0.0.0",
                ReleaseDate = new DateTime(2020, 6, 15),
                Tags = new[] { "EPiServer", "Internal", "NetFramework", "Analyzers" },
                InternalOnly = true,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 300_000
            });

            list.Add(new NugetPackage
            {
                Name = "EPiServer.Data.Analyzers.UI",
                Version = "2.0.0.0",
                ReleaseDate = new DateTime(2020, 6, 15),
                Tags = new[] { "EPiServer", "Internal", "NetFramework", "Analyzers" },
                InternalOnly = true,
                NetFlavor = DotnetFlavor.NetFramework,
                TotalDownload = 500_000
            });

            return list;
        }
    }
}
