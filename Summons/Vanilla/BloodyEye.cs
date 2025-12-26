using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BloodyEye : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.EyeballFlyingFish;
        public override int ItemCost => Item.buyPrice(silver: 3);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.Lens, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}