using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla

{
    public class Algae : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SeaSnail;

        public override int ItemCost => Item.buyPrice(silver: 3);
        

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