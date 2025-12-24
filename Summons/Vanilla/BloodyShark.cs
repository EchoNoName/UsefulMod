using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BloodyShark : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoblinShark;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SharkFin, 3)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}