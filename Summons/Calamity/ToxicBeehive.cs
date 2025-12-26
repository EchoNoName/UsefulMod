using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class ToxicBeehive : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "PlaguebringerMiniboss").Type;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneJungle;
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.HoneyBlock, 20)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "PlagueCellCanister"), 10)
            .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}