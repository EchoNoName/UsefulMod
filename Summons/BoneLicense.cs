using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class BoneLicense : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SkeletonMerchant;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddIngredient(ItemID.Torch, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}