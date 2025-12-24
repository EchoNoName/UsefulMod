using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class BloodyEel : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BloodEelHead;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.Worm)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}