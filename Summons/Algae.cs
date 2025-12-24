using Terraria;
using Terraria.ID;
using UsefulMod.Core;

namespace UsefulMod.Summons

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
                .AddRecipeGroup("Herbs", 10)
                .Register();
        }
    }
}