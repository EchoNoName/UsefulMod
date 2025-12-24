using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PlunderedGoods : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.PirateShip;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Chest, 10)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}