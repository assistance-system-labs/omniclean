using System.ComponentModel;

namespace Klocman.Events
{
    /// <summary>
    ///     Generic version of the System.ComponentModel.PropertyChangedEventArgs.
    ///     It might not contain a valid propertyName
    /// </summary>
    public class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public PropertyChangedEventArgs(T newValue) : this(newValue, string.Empty)
        {
        }

        public PropertyChangedEventArgs(T newValue, string propertyName) : base(propertyName)
        {
            NewValue = newValue;
        }

        public T NewValue { get; private set; }
    }
}
