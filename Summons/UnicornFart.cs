using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class UnicornFart : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RainbowSlime;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.UnicornHorn, 5)
                .AddIngredient(ItemID.PixieDust, 35)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}