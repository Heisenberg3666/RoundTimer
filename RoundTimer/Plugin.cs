using System;
using Exiled.API.Features;
using RoundTimer.Events;

namespace RoundTimer
{
    public class Plugin : Plugin<Config>
    {
        private ServerEvents _serverEvents;
        
        public override string Name { get; } = nameof(RoundTimer);
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(1, 1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        public override void OnEnabled()
        {
            _serverEvents = new ServerEvents();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _serverEvents.Dispose();
            _serverEvents = null;
            
            base.OnDisabled();
        }
    }
}