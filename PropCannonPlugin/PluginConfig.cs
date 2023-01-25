using BepInEx.Configuration;

namespace PluginConfigs
{
    public static class PluginConfig
    {
        public static void Initialize(ConfigFile cfg)
        {
            maxMass = cfg.Bind(
                section: "Propulsion Cannon Settings",
                key: "Cannon Max Pickup Mass",
                defaultValue: 1200f,
                new ConfigDescription(
                   description: "Set the max mass the cannon can pickup",
                   acceptableValues: new AcceptableValueRange<float>(1f, 10000f),
                   tags: new ConfigurationManagerAttributes { Order = 1 }
            )
        );
            pickupDistance = cfg.Bind(
                section: "Propulsion Cannon Settings",
                key: "Cannon Max Pickup Distance",
                defaultValue: 18f,
                new ConfigDescription(
                    description: "Set the max distance the cannon can pickup",
                    acceptableValues: new AcceptableValueRange<float>(1f, 1000f),
                    tags: new ConfigurationManagerAttributes { Order = 2 }
            )
        );
            shootForce = cfg.Bind(
                section: "Propulsion Cannon Settings",
                key: "Cannon Max Shoot Force",
                defaultValue: 50f,
                new ConfigDescription(
                    description: "Set the amount of shooting force",
                    acceptableValues: new AcceptableValueRange<float>(1f, 1000f),
                    tags: new ConfigurationManagerAttributes { Order = 3 }
            )
        );

        }

        internal static ConfigEntry<float> maxMass;
        internal static ConfigEntry<float> pickupDistance;
        internal static ConfigEntry<float> shootForce;
    }
}