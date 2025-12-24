using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class HitmansMark : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SkeletonSniper;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.PlatinumCoin, 3)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}