using CommandSystem;
using Exiled.API.Features;
using System;

namespace SCPSBP
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Connect : ICommand
    {
        public string Command => "connectbuttplug";

        public string[] Aliases { get; } = { "buttplug", "cbp" };

        public string Description => "Connect your buttplug and that shit.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            // idk if anything is bugged, idc, chupame la pija.

            if (arguments.Count < 1)
            {
                response = "You must specify the Buttplug URL. Example: .connectbuttplug ws://localhost:12345";
                return true;
            }
         
            Plugin.Instance.handler.Buttplugers.Add(Player.Get(sender));
            Plugin.DeviceManager.ConnectDevices(arguments.At(0));
            response = "Enjoy the ButtplugIN!";
            return true;
        }
    }
}
