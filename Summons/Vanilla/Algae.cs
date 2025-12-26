using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla

{
    public class Algae : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SeaSnail;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddRecipeGroup("Herbs", 6)
                .Register();
        }
    }
}