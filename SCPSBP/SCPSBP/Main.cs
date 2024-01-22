using Exiled.API.Features;

namespace SCPSBP
{
    internal class Plugin : Plugin<Config>
    {
        internal static DeviceManager DeviceManager { get; private set; }
        public static Plugin Instance;
        public EventHandlers handler;
        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
            DeviceManager = new DeviceManager("SecretButtplug");
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Instance = null;
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            handler = new EventHandlers();
            Exiled.Events.Handlers.Player.Hurt += handler.OnDamage;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurt -= handler.OnDamage;
            handler = null;
        }
    }
}
