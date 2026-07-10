using Klocman.Localising;
using Klocman.Properties;

namespace Klocman
{
    public enum YesNoAsk
    {
        [LocalisedName(typeof (Localisation), nameof(Localisation.Enums_YesNoAsk_Ask))] Ask = 0,
        [LocalisedName(typeof (Localisation), nameof(Localisation.Yes))] Yes,
        [LocalisedName(typeof (Localisation), nameof(Localisation.No))] No
    }
}
