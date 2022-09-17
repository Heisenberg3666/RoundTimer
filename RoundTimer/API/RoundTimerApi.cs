using System;
using System.Collections.Generic;
using AdvancedHints;
using AdvancedHints.Enums;
using Exiled.API.Features;
using MEC;
using RoundTimer.Config;

namespace RoundTimer.API
{
    public static class RoundTimerApi
    {
        internal static CoroutineHandle Coroutine;
        internal static List<Player> BlacklistedPlayers = new List<Player>();

        private static readonly Translation _translation = Plugin.Instance.Translation;
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
                    if (BlacklistedPlayers.Contains(player)) continue;
                    
                    player.ShowManagedHint(
                        $"<align=left>{_translation.RoundTime}: {FormatTime(Round.ElapsedTime)}</align>", 
                        1f, 
                        true, 
                        DisplayLocation.Bottom
                    );
                }

                yield return Timing.WaitForOneFrame;
            }
        }

        private static string FormatTime(TimeSpan time)
        {
            if (time.Minutes < 1)
                return $"{time.Seconds}{_translation.SecondSymbol}";
            return $"{time.Minutes}{_translation.MinuteSymbol} {time.Seconds}{_translation.SecondSymbol}";
            
        }
    }
}