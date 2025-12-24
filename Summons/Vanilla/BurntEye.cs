using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BurntEye : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Eyezor;

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.SuspiciousLookingEye)
                .AddIngredient(ItemID.Hellstone, 20)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}