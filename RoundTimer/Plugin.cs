using System;
using Exiled.API.Features;
using RoundTimer.Config;
using RoundTimer.Events;

namespace RoundTimer
{
    public class Plugin : Plugin<BaseConfig, Translation>
    {
        private ServerEvents _serverEvents;

        internal static Plugin Instance;
        
        public override string Name { get; } = nameof(RoundTimer);
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(1, 1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        public override void OnEnabled()
        {
            Instance = this;
            
            _serverEvents = new ServerEvents();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _serverEvents.Dispose();
            _serverEvents = null;

            Instance = null;
            
            base.OnDisabled();
        }
    }
}