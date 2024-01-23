using Exiled.API.Interfaces;

namespace SCPSBP
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float VibrateAmplifier { get; set; } = 0;
        public bool VibrateOnReceivingDamage { get; set; } = true;
        public float VibrateDurationOnReceivingDamage { get; set; } = 1;
        public float VibrateStrenghtOnReceivingDamage { get; set; } = 0.5f;
        public bool VibrateOnDoingDamage { get; set; } = true;
        public float VibrateDurationOnDoingDamage { get; set; } = 1;
        public float VibrateStrenghtOnDoingDamage { get; set; } = 0.5f;
    }
}