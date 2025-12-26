using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class RainbowCrown : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RainbowSlime;
        public override int ItemCost => Item.buyPrice(silver: 35);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.UnicornHorn, 2)
                .AddIngredient(ItemID.PixieDust, 10)
                .AddTile(TileID.Anvils)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 10)
                .AddIngredient(ItemID.UnicornHorn, 2)
                .AddIngredient(ItemID.PixieDust, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}