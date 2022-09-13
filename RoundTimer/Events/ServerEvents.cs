using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using MEC;
using RoundTimer.API;

namespace RoundTimer.Events
{
    internal class ServerEvents
    {
        public ServerEvents()
        {
            Server.RoundStarted += OnRoundStarted;
            Server.RoundEnded += OnRoundEnded;
        }

        ~ServerEvents()
        {
            Server.RoundStarted -= OnRoundStarted;
            Server.RoundEnded -= OnRoundEnded;
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