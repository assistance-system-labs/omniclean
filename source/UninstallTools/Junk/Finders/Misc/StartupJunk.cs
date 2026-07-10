using System.Collections.Generic;
using System.Linq;
using UninstallTools.Junk.Containers;
using UninstallTools.Properties;

namespace UninstallTools.Junk.Finders.Misc
{
    public sealed class StartupJunk : IJunkCreator
    {
        public void Setup(ICollection<ApplicationUninstallerEntry> allUninstallers)
        {
        }

        public string CategoryName => Localisation.Junk_Startup_GroupName;

        public IEnumerable<IJunkResult> FindJunk(ApplicationUninstallerEntry target)
        {
            if (target.StartupEntries == null)
                return Enumerable.Empty<IJunkResult>();

            return target.StartupEntries.Where(x => x.StillExists())
                .Select(x => (IJunkResult)new StartupJunkNode(x, target, this));
        }
    }
}
