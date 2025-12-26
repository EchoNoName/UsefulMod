using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class RaggedCloak : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RaggedCaster;
        public override int ItemCost => Item.buyPrice(silver: 50);
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}