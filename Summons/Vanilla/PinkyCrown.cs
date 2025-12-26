using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class PinkyCrown : SummonTemplate
	{
        public override int SummonedNPCType => NPCID.Pinky;
		public override int ItemCost => Item.buyPrice(gold: 2, silver: 85);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.GoldCrown)
				.AddIngredient(ItemID.Gel, 10)
				.AddIngredient(ItemID.PinkPaint)
				.AddTile(TileID.DyeVat)
				.Register();
            
            CreateRecipe()
				.AddIngredient(ItemID.PlatinumCrown)
				.AddIngredient(ItemID.Gel, 10)
				.AddIngredient(ItemID.PinkPaint)
				.AddTile(TileID.DyeVat)
				.Register();
		}
	}
}