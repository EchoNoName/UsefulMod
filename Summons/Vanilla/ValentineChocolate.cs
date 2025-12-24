using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ValentineChocolate : SummonTemplate
    {
        public override int SummonedNPCType => Main.hardMode ? NPCID.Nymph : NPCID.LostGirl;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.LifeCrystal)
                .AddRecipeGroup("Fruit", 5)
                .AddTile(TileID.CookingPots)
                .Register();
        }
    }
}