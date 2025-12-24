using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class BloodyEye : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.EyeballFlyingFish;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SuspiciousLookingEye)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}