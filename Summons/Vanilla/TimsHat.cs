using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class TimsHat : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Tim;
		public override int ItemCost => Item.buyPrice(gold: 1, silver: 10);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.Silk, 25)
				.AddIngredient(ItemID.Amethyst, 3)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}