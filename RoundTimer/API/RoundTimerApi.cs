using System;
using System.Collections.Generic;
using AdvancedHints.Components;
using Exiled.API.Features;
using MEC;

namespace RoundTimer.API
{
    public static class RoundTimerApi
    {
        internal static CoroutineHandle Coroutine;
        
        private static TimeSpan _oldRoundTime = Round.ElapsedTime;
        private static bool _roundTimeChanged
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
                if (!_roundTimeChanged) continue;
                
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