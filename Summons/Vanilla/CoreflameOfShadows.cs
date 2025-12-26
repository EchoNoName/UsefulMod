using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class CoreflameOfShadows : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinSummoner;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 5)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}