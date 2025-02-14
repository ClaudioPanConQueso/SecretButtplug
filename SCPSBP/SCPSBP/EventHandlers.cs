using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace SCPSBP
{
    public class EventHandlers
    {
        public readonly Dictionary<Player, DeviceManager> Buttplugers = new Dictionary<Player, DeviceManager>();
        public void OnDamage(HurtEventArgs ev)
        {
            if (!Buttplugers.TryGetValue(ev.Player, out DeviceManager manager))
                return;
            
            if (manager.ButtplugClient.Connected)
            {
                if (Plugin.Instance.Config.VibrateOnReceivingDamage)
                    manager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnReceivingDamage, Plugin.Instance.Config.VibrateDurationOnReceivingDamage);
                else if (Plugin.Instance.Config.VibrateOnDoingDamage)
                    manager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnDoingDamage, Plugin.Instance.Config.VibrateDurationOnDoingDamage);
            }
        }
        public void OnDied(DiedEventArgs ev)
        {
            if (!Buttplugers.TryGetValue(ev.Player, out DeviceManager manager))
                return;
            
            if (manager.ButtplugClient.Connected)
            {
                if (Plugin.Instance.Config.VibrateOnDying)
                    manager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnDying, Plugin.Instance.Config.VibrateDurationOnDying);
                else if (Plugin.Instance.Config.VibrateOnDoingKilling)
                    manager.VibrateConnectedDevicesWithDuration(Plugin.Instance.Config.VibrateStrenghtOnKilling, Plugin.Instance.Config.VibrateDurationOnKilling);
            }
        }
    }
}
