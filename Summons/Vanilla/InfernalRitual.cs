using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class InfernalRitual : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DiabolistWhite;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 20)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}