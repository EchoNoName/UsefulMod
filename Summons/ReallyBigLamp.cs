using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class ReallyBigLamp : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Mothron;

        public override bool CanUseItem(Player player)
        {
            return Main.eclipse;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 100)
                .AddIngredient(ItemID.Torch, 50)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}