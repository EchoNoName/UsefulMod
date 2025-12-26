using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
	public class DeadMansPick : SummonTemplate
	{
        public override int SummonedNPCType => NPCID.UndeadMiner;


        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.IronPickaxe)
				.AddIngredient(ItemID.StoneBlock, 25)
				.AddTile(TileID.WorkBenches)
				.Register();
            
            CreateRecipe()
				.AddIngredient(ItemID.LeadPickaxe)
				.AddIngredient(ItemID.StoneBlock, 25)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}