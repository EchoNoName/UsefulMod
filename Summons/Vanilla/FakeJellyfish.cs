using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class FakeJellyfish : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Squid;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Glowstick, 15)
                .Register();
        }
    }
}