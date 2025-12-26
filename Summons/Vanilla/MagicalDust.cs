using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class MagicalDust : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BoundTownSlimeYellow;
        public override int ItemCost => Item.buyPrice(gold: 5);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Gel, 10)
                .AddIngredient(ItemID.YellowPaint)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}