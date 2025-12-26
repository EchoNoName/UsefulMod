using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class HolyShield : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Paladin;
        public override int ItemCost => Item.buyPrice(gold: 12, silver: 80);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 10)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}