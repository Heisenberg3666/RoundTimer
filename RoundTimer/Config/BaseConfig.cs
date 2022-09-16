using Exiled.API.Interfaces;

namespace RoundTimer.Config
{
    public class BaseConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}