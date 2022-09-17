using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RoundTimer.API;

namespace RoundTimer.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RoundTimer : ICommand, IUsageProvider
    {
        public string Command { get; } = nameof(RoundTimer);
        public string Description { get; } = "Allows players to enable/disable the round timer on their screen.";
        public string[] Aliases { get; } = new string[] { "rt" };
        public string[] Usage { get; } = new string[] { "Enable/Disable" };
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("roundtimer"))
            {
                response = "You lack the required permissions to complete this action.";
                return false;
            }

            Player player = Player.Get(sender);
            bool enable = arguments.At(0) == "enable";

            if (enable)
            {
                if (RoundTimerApi.BlacklistedPlayers.Contains(player))
                {
                    RoundTimerApi.BlacklistedPlayers.Remove(player);
                    response = "You have been unblacklisted.";
                    return true;
                }

                response = "You are already unblacklisted.";
                return false;
            }

            if (RoundTimerApi.BlacklistedPlayers.Contains(player))
            {
                response = "You are already blacklisted.";
                return false;
            }

            RoundTimerApi.BlacklistedPlayers.Add(player);
            response = "You have been blacklisted.";
            return true;
        }
    }
}