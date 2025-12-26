using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class WeddingRing : SummonTemplate
	{

        public override int SummonedNPCType => NPCID.TheBride;
		public override int ItemCost => Item.buyPrice(silver: 60);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.GoldBar, 3)
				.AddTile(TileID.Anvils)
				.Register();
            
            CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}