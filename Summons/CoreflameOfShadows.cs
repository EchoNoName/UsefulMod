using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class CoreflameOfShadows : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinSummoner;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 10)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}