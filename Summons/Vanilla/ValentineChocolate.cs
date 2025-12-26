using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ValentineChocolate : SummonTemplate
    {
        public override int SummonedNPCType => Main.hardMode ? NPCID.Nymph : NPCID.LostGirl;
        public override int ItemCost => Item.buyPrice(gold: 5);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddRecipeGroup("Fruit", 10)
                .AddTile(TileID.CookingPots)
                .Register();
        }
    }
}