using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BloodyMollusk : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BloodNautilus;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SoulofNight, 1)
                .AddIngredient(ItemID.Seashell, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}