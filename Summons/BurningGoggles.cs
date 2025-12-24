using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class BurningGoggles : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SkeletonCommando;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Lens, 10)
                .AddIngredient(ItemID.HellstoneBar, 10)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}