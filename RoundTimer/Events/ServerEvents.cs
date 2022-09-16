using System;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using MEC;
using RoundTimer.API;

namespace RoundTimer.Events
{
    internal class ServerEvents : IDisposable
    {
        public ServerEvents()
        {
            Server.RoundStarted += OnRoundStarted;
            Server.RoundEnded += OnRoundEnded;
        }
        
        public void Dispose()
        {
            Server.RoundStarted -= OnRoundStarted;
            Server.RoundEnded -= OnRoundEnded;
            
            GC.SuppressFinalize(this);
        }

        private void OnRoundStarted()
        {
            RoundTimerApi.Coroutine = Timing.RunCoroutine(RoundTimerApi.DisplayRoundTime());
        }

        private void OnRoundEnded(RoundEndedEventArgs e)
        {
            Timing.KillCoroutines(RoundTimerApi.Coroutine);
        }
    }
}