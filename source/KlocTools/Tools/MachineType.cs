using Klocman.Localising;
using Klocman.Resources;

namespace Klocman.Tools
{
    public enum MachineType
    {
        [LocalisedName(typeof(CommonStrings), nameof(CommonStrings.Unknown))]
        Unknown,
        X86,
        X64,
        Ia64,
        ARM64
    }
}
