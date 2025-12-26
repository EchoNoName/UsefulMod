using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class LoveLetter : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.TheGroom;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}