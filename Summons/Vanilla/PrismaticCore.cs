using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PrismaticCore : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.HallowBoss;

        public override bool IsBoss => true;
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(SummonedNPCType);
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.EmpressButterfly, 1)
                .AddIngredient(ItemID.UnicornHorn, 5)
                .AddIngredient(ItemID.PixieDust, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}