using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class MastersBelt : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BoneLee;
        public override int ItemCost => Item.buyPrice(silver: 75);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}