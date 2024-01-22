using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace SCPSBP
{
    public class EventHandlers
    {
        public List<Player> ButtplugersIDKfu = new List<Player>();
        public void OnDamage(HurtEventArgs ev)
        {
            if (ButtplugersIDKfu.Contains(ev.Player))
                if (Plugin.DeviceManager.ButtplugClient.Connected && Plugin.Instance.Config.VibrateOnReceivingDamage)
                    Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnReceivingDamage, Plugin.Instance.Config.VibrateDurationOnReceivingDamage);
                else if (ButtplugersIDKfu.Contains(ev.Attacker))
                    if (Plugin.DeviceManager.ButtplugClient.Connected && Plugin.Instance.Config.VibrateOnDoingDamage)
                        Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnDoingDamage, Plugin.Instance.Config.VibrateDurationOnDoingDamage);
        }
    }
}
