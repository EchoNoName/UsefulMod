using Terraria;
using Terraria.ID;
namespace UsefulMod.Summons
{
    public class ClownForHire : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Clown;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.PlatinumCoin)
                .Register();
        }
    }
}