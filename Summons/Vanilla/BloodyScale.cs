using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BloodyScale : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.ZombieMerman;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddRecipeGroup("IronBar")
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}