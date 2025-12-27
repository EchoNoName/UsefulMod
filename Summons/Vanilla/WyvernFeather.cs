using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class WyvernFeather : SummonTemplate
	{

        public override int SummonedNPCType => NPCID.WyvernHead;
		public override int ItemCost => Item.buyPrice(gold: 2, silver: 75);
        public override bool CanUseItem(Player player)
        {
            return player.ZoneSkyHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.Feather, 8)
                .AddIngredient(ItemID.Cloud, 25)
                .AddIngredient(ItemID.Pearlwood)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}