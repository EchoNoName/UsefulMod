using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons
{
	public class TimsHat : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Tim;
		
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.Silk, 75)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}