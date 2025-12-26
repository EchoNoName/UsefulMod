using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class CoreflameOfShadows : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinSummoner;
        public override int ItemCost => Item.buyPrice(gold: 3);
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 5)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}