using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class DeclarationofWar : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinScout;
        public override int ItemCost => Item.buyPrice(silver: 5, copper: 50);
        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}