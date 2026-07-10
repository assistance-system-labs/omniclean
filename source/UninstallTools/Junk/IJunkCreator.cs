using System.Collections.Generic;
using UninstallTools.Junk.Containers;

namespace UninstallTools.Junk
{
    public interface IJunkCreator
    {
        void Setup(ICollection<ApplicationUninstallerEntry> allUninstallers);
        IEnumerable<IJunkResult> FindJunk(ApplicationUninstallerEntry target);
        string CategoryName { get; }
    }
}
