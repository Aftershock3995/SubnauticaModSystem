using BepInEx.Configuration;

namespace KnifeDamageMod_SN
{
    public static class PluginConfig
    {
        public static void Initialize(ConfigFile cfg)
        {
            knifeDamage = cfg.Bind(
                section: "Knife Settings",
                key: "Knife Damage",
                defaultValue: 25f,
                new ConfigDescription(
                   description: "Set Knife Damage",
                   acceptableValues: new AcceptableValueRange<float>(1f, 100f),
                   tags: new ConfigurationManagerAttributes { Order = 1 }
            )
        );
            knifeDistance = cfg.Bind(
                section: "Knife Settings",
                key: "Knife Distance",
                defaultValue: 1f,
                new ConfigDescription(
                    description: "Set Knife Distance",
                    acceptableValues: new AcceptableValueRange<float>(1f, 100f),
                    tags: new ConfigurationManagerAttributes { Order = 2 }
            )
        );
            heatDamage = cfg.Bind(
                section: "Knife Settings",
                key: "Heat Knife Damage",
                defaultValue: 40f,
                new ConfigDescription(
                    description: "Set Heat Knife Damage",
                    acceptableValues: new AcceptableValueRange<float>(1f, 100f),
                    tags: new ConfigurationManagerAttributes { Order = 3 }
            )
        );
            heatDistance = cfg.Bind(
                section: "Knife Settings",
                key: "Heat Knife Distance",
                defaultValue: 1f,
                new ConfigDescription(
                    description: "Set Heat Knife Distance",
                    acceptableValues: new AcceptableValueRange<float>(1f, 100f),
                    tags: new ConfigurationManagerAttributes { Order = 4 }
             )
        );
    }

        internal static ConfigEntry<float> knifeDamage;
        internal static ConfigEntry<float> knifeDistance;
        internal static ConfigEntry<float> heatDistance;
        internal static ConfigEntry<float> heatDamage;
    }
}


