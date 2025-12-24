using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class TruffleOil : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DukeFishron;

        public override bool CanUseItem(Player player) => !NPC.AnyNPCs(NPCID.DukeFishron) && player.ZoneBeach;
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.TruffleWorm, 1)
                .AddIngredient(ItemID.GlowingMushroom, 15)
                .AddTile(TileID.CookingPots)
                .Register();
        }
    }
}