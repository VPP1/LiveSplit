using LiveSplit.Model;
using System;
using LiveSplit.UI.Components;
using LiveSplit.SerialSplitter;

[assembly: ComponentFactory(typeof(Factory))]


namespace LiveSplit.SerialSplitter
{
    public class Factory : IComponentFactory
    {
        public string ComponentName => "LiveSplit Serial splitter";

        public string Description => "Allows an external device to control and monitor LiveSplit's state through serial communication";

        public ComponentCategory Category => ComponentCategory.Control;

        public IComponent Create(LiveSplitState state) => new SerialComm(state);

        public string UpdateName => ComponentName;

        public string UpdateURL => "http://livesplit.org/update/";

        public Version Version => Version.Parse("1.7.2");

        public string XMLURL => "http://livesplit.org/update/Components/update.LiveSplit.Server.xml";
    }
}
