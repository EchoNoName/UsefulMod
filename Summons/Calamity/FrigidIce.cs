using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class FrigidIce : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "IceClasper").Type;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneSnow;
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.IceBlock, 100)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "EssenceofEleum"), 5)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}