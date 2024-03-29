﻿using Exiled.API.Features;
using System;

namespace SCPSBP
{
    internal class Plugin : Plugin<Config>
    {
        public override string Name => "SCPSBP";
        public override string Author => "ClaudioPanConQueso";
        public override Version Version => new Version(1, 0, 2);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);
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
            Exiled.Events.Handlers.Player.Died += handler.OnDied;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurt -= handler.OnDamage;
            Exiled.Events.Handlers.Player.Died -= handler.OnDied;
            handler = null;
        }
    }
}
