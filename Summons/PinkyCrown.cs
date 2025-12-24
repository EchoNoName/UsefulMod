using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons
{
	public class PinkyCrown : SummonTemplate
	{
        public override int SummonedNPCType => NPCID.Pinky;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.GoldCrown, 5)
				.AddIngredient(ItemID.Gel, 75)
				.AddIngredient(ItemID.PinkPaint)
				.AddTile(TileID.DyeVat)
				.Register();
            
            CreateRecipe()
				.AddIngredient(ItemID.PlatinumCrown, 5)
				.AddIngredient(ItemID.Gel, 75)
				.AddIngredient(ItemID.PinkPaint)
				.AddTile(TileID.DyeVat)
				.Register();
		}
	}
}