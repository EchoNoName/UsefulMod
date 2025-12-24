using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ThePlank : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.PirateCaptain;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddRecipeGroup("Wood", 50)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}