using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using Buttplug.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Log = Exiled.API.Features.Log;

// Most of the code was stolen from https://github.com/quasikyo/rumble-rain/blob/main/RumbleRain/DeviceManager.cs and https://github.com/bananasov/LethalVibrations/blob/master/LethalVibrations/Buttplug/DeviceManager.cs
namespace SCPSBP
{
    public class DeviceManager
    {
        public List<ButtplugClientDevice> ConnectedDevices { get; set; }
        public ButtplugClient ButtplugClient { get; set; }

        public DeviceManager(string clientName)
        {
            ConnectedDevices = new List<ButtplugClientDevice>();
            ButtplugClient = new ButtplugClient(clientName);
            Log.Info("BP client created for " + clientName);
            ButtplugClient.DeviceAdded += HandleDeviceAdded;
            ButtplugClient.DeviceRemoved += HandleDeviceRemoved;
        }
        public async void ConnectDevices()
        {
            if (ButtplugClient.Connected) return;

            try
            {
                Log.Debug($"Attempting to connect to Intiface server at {Plugin.Instance.Config.ServerUrl}");
                await ButtplugClient.ConnectAsync(new ButtplugWebsocketConnector(new Uri(Plugin.Instance.Config.ServerUrl)));
                Log.Debug("Connection successful. Beginning scan for devices");
                await ButtplugClient.StartScanningAsync();
            }
            catch (ButtplugException exception)
            {
                Log.Error($"There was an error while trying to connect. {exception}");
            }
        }

        public void VibrateConnectedDevicesWithDuration(double intensity, float time)
        {
            intensity += Plugin.Instance.Config.VibrateAmplifier;

            async void Action(ButtplugClientDevice device)
            {
                await device.VibrateAsync(Mathf.Clamp((float)intensity, 0f, 1.0f));
                await Task.Delay((int)(time * 1000f));
                await device.VibrateAsync(0.0f);
            }

            ConnectedDevices.ForEach(Action);
        }

        /// <summary>
        ///  This has to be manually stopped
        /// </summary>
        public void VibrateConnectedDevices(double intensity)
        {
            intensity += Plugin.Instance.Config.VibrateAmplifier;

            async void Action(ButtplugClientDevice device)
            {
                await device.VibrateAsync(Mathf.Clamp((float)intensity, 0f, 1.0f));
            }

            ConnectedDevices.ForEach(Action);
        }

        public void StopConnectedDevices()
        {
            ConnectedDevices.ForEach(async (ButtplugClientDevice device) => await device.Stop());
        }

        internal void CleanUp()
        {
            StopConnectedDevices();
        }

        private void HandleDeviceAdded(object sender, DeviceAddedEventArgs args)
        {
            if (!IsVibratableDevice(args.Device))
            {
                Log.Info($"{args.Device.Name} is detected, but it's not vibratable.");
                return;
            }

            Log.Info($"{args.Device.Name} connected {ButtplugClient.Name}");
            ConnectedDevices.Add(args.Device);
        }

        private void HandleDeviceRemoved(object sender, DeviceRemovedEventArgs args)
        {
            if (!IsVibratableDevice(args.Device)) return;

            Log.Info($"{args.Device.Name} disconnected {ButtplugClient.Name}");
            ConnectedDevices.Remove(args.Device);
        }


        private bool IsVibratableDevice(ButtplugClientDevice device)
        {
            return device.VibrateAttributes.Count > 0;
        }
    }
}