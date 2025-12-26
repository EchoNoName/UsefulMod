using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
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
                .AddIngredient(ItemID.Lens, 2)
                .AddIngredient(ItemID.HellstoneBar, 6)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}