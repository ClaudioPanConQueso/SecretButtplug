using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace SCPSBP
{
    public class EventHandlers
    {
        public List<Player> Buttplugers = new List<Player>();
        public void OnDamage(HurtEventArgs ev)
        {
            if (Plugin.DeviceManager.ButtplugClient.Connected)
            {
                if (Buttplugers.Contains(ev.Player) && Plugin.Instance.Config.VibrateOnReceivingDamage)
                    Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnReceivingDamage, Plugin.Instance.Config.VibrateDurationOnReceivingDamage);
                else if (Buttplugers.Contains(ev.Attacker) && Plugin.Instance.Config.VibrateOnDoingDamage)
                    Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnDoingDamage, Plugin.Instance.Config.VibrateDurationOnDoingDamage);
            }
        }
        public void OnDied(DiedEventArgs ev)
        {
            if (Plugin.DeviceManager.ButtplugClient.Connected)
            {
                if (Buttplugers.Contains(ev.Player) && Plugin.Instance.Config.VibrateOnDying)
                    Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnDying, Plugin.Instance.Config.VibrateDurationOnDying);
                else if (Buttplugers.Contains(ev.Attacker) && Plugin.Instance.Config.VibrateOnDoingKilling)
                    Plugin.DeviceManager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnKilling, Plugin.Instance.Config.VibrateDurationOnKilling);
            }
        }
    }
}
