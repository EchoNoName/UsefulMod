using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class BloodyMollusk : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BloodNautilus;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.RedPaint)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.Seashell, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}