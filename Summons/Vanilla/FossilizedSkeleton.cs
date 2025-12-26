using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class FossilizedSkeleton : SummonTemplate
	{
        public override int SummonedNPCType => NPCID.DoctorBones;
		public override int ItemCost => Item.buyPrice(silver: 90);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.FossilOre, 8)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}