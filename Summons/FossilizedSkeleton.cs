using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons
{
	public class FossilizedSkeleton : SummonTemplate
	{
        public override int SummonedNPCType => NPCID.DoctorBones;
		

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.FossilOre, 15)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}