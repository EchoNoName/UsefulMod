using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class FakeJellyfish : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Squid;

        public override int ItemCost => Item.buyPrice(silver: 10);
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Glowstick, 10)
                .Register();
        }
    }
}