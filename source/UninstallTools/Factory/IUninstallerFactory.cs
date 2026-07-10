using System.Collections.Generic;

namespace UninstallTools.Factory
{
    public interface IIndependantUninstallerFactory : IUninstallerFactory
    {
        bool IsEnabled();
        string DisplayName { get; }
    }

    public interface IUninstallerFactory
    {
        IList<ApplicationUninstallerEntry> GetUninstallerEntries(ListGenerationProgress.ListGenerationCallback progressCallback);
    }
}
