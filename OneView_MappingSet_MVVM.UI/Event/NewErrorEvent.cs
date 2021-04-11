using System;

namespace OneView_MappingSet_MVVM.UI.Event
{
    public delegate void NewErrorEventHandler(Object sender, NewErrorEventArgs e);

    public class NewErrorEventArgs : EventArgs
    {
        public string errorMessage { get; set; }
    }
}
