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
                .AddIngredient(ItemID.Chest, 5)
                .AddIngredient(ItemID.SoulofLight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}