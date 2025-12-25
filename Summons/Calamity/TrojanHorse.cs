
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class TrojanHorse : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "Cnidrion").Type;

        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.Wood, 100)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}