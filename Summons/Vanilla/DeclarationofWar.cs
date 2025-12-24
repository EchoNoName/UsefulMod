using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class DeclarationofWar : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinScout;
    
        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}