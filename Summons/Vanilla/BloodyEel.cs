using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BloodyEel : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BloodEelHead;
        public override int ItemCost => Item.buyPrice(gold: 1);

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.Worm)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}