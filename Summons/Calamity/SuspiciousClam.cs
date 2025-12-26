
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class SuspiciousClam : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "GiantClam").Type;
        public override int ItemCost => Item.buyPrice(gold: 4);

        public override bool CanUseItem(Player player)
        {
            bool inSunkenSea = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inSunkenSea = (bool)calamity.Call("GetInZone", player, "sunkensea");
            }
            return !NPC.AnyNPCs(SummonedNPCType) && inSunkenSea;
        }

        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.Seashell, 10)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "SeaPrism"), 30)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "PearlShard"), 1)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}