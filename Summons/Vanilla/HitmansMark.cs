using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class HitmansMark : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SkeletonSniper;
        public override int ItemCost => Item.buyPrice(gold: 1);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.GoldCoin, 3)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}