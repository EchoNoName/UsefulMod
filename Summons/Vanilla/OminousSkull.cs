using Terraria;
using Terraria.ID;  

namespace UsefulMod.Summons.Vanilla
{
    public class OminousSkull : SummonTemplate
    {
        public override int SummonedNPCType => !Main.dayTime ? NPCID.SkeletronHead : NPCID.DungeonGuardian;

        public override bool IsBoss => true;
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(SummonedNPCType);
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Cobweb, 20)
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}