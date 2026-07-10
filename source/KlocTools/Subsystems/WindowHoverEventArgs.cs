using System;

namespace Klocman.Subsystems
{
    public sealed class WindowHoverEventArgs : EventArgs
    {
        public WindowHoverEventArgs(WindowHoverSearcher.WindowInfo targetWindow)
        {
            TargetWindow = targetWindow;
        }

        public WindowHoverSearcher.WindowInfo TargetWindow { get; }
    }
}
