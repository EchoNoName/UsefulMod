using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace UsefulMod.Configs
{
    public class UsefulModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("NPCs")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableAnomaly;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableCollector;

        [Header("Items")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool NonConsSummons;
    }
}