using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PrismaticCore : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.HallowBoss;
        public override int ItemCost => Item.buyPrice(gold: 25);

        public override bool IsBoss => true;
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(SummonedNPCType);
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.EmpressButterfly, 1)
                .Register();
        }
    }
}