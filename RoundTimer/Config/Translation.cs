using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RoundTimer.Config
{
    public class Translation : ITranslation
    {
        [Description("This is text that is displayed before the time. e.g. Round Time: 1m 32s")]
        public string RoundTime { get; set; } = "Round Time";

        [Description("This is the symbol that will be displayed next to the minutes.")]
        public string MinuteSymbol { get; set; } = "m";

        [Description("This is the symbol that will be displayed next to the seconds.")]
        public string SecondSymbol { get; set; } = "s";
    }
}