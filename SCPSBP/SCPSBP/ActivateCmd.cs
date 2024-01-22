using CommandSystem;
using Exiled.API.Features;
using System;

namespace SCPSBP
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ActivateCmd : ICommand
    {
        public string Command => "activatebuttplug";

        public string[] Aliases { get; } = { "buttplug", "abp" };

        public string Description => "Activates the buttplug and that shit.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            // idk if anything it's bugged, idc, chupame la pija.
            Plugin.Instance.handler.ButtplugersIDKfu.Add(Player.Get(sender));
            Plugin.DeviceManager.ConnectDevices();
            response = "Enjoy the buttplugIN!";
            return true;
        }
    }
}