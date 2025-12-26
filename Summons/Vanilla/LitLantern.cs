using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class LitLantern : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Moth;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddRecipeGroup("IronBar", 10)
                .AddIngredient(ItemID.Torch, 5)
                .AddIngredient(ItemID.SoulofFlight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}