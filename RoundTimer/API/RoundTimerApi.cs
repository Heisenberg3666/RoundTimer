using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AdvancedHints.Components;
using Exiled.API.Features;
using MEC;

namespace RoundTimer.API
{
    public static class RoundTimerApi
    {
        private static TimeSpan _oldRoundTime = Round.ElapsedTime;
        internal static CoroutineHandle Coroutine;

        public static bool RoundTimeChanged
        {
            get
            {
                bool roundTimeChanged = _oldRoundTime != Round.ElapsedTime;
                _oldRoundTime = Round.ElapsedTime;

                return roundTimeChanged;
            }
        }

        public static IEnumerator<float> DisplayRoundTime()
        {
            while (true)
            {
                if (!RoundTimeChanged) continue;
                
                foreach (Player player in Player.List)
                {
                    HudManager.ShowHint(player, $"Round Time: {FormatTime(Round.ElapsedTime)}", 1f);
                }

                yield return Timing.WaitForOneFrame;
            }
        }

        private static string FormatTime(TimeSpan time) => 
            time.Minutes < 1 ? $"{time.Seconds}s" : $"{time.Minutes}m {time.Seconds}s";
    }
}