using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class InfernalRitual : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DiabolistWhite;
        public override int ItemCost => Item.buyPrice(silver: 40);
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 8)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}