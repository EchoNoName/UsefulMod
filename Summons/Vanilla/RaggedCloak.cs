using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class RaggedCloak : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RaggedCaster;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}