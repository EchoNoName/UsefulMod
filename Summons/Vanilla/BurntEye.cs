using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BurntEye : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Eyezor;
        public override int ItemCost => Item.buyPrice(gold: 1);
        public override bool CanUseItem(Player player)
        {
            return Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Lens, 2)
                .AddIngredient(ItemID.Hellstone, 5)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}