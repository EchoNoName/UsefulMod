using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class ChaoticEnergy : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "OverloadedSoldier").Type;
        public override int ItemCost => Item.buyPrice(gold: 25);
        public override bool CanUseItem(Player player)
        {
            return player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.SoulofLight, 2)
            .AddIngredient(ItemID.SoulofNight, 2)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "EssenceofHavoc"), 2)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "EssenceofEleum"), 2)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "EssenceofSunlight"), 2)
            .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}