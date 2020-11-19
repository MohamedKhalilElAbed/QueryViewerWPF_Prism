using Prism.Events;

namespace Client.Core.Events
{
    public class ColumnRenameEvent : PubSubEvent<(object, string, string)>
    {
    }
}
