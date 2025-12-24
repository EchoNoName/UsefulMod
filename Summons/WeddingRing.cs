using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons
{
	public class WeddingRing : SummonTemplate
	{

        public override int SummonedNPCType => NPCID.TheBride;
		
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Anvils)
				.Register();
            
            CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}