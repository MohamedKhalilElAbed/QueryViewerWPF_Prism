﻿using Prism.Events;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Client.Core.Events
{
    public class ColumnRenameEvent : PubSubEvent<(object, string, string, DataGrid)>
    {
    }
}
