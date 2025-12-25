
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class RainstormCore : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "ThiccWaifu").Type;

        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.Cloud, 100)
            .AddIngredient(ItemID.RainCloud, 20)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}