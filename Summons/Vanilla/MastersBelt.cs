using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class MastersBelt : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BoneLee;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 30)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}