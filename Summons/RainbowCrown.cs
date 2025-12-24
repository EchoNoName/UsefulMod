using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class RainbowCrown : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RainbowSlime;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.UnicornHorn, 5)
                .AddIngredient(ItemID.PixieDust, 30)
                .AddTile(TileID.Anvils)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 10)
                .AddIngredient(ItemID.UnicornHorn, 5)
                .AddIngredient(ItemID.PixieDust, 30)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}