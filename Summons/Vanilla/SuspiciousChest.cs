using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class SuspiciousChest : SummonTemplate
	{
        public override int SummonedNPCType => Main.LocalPlayer.ZoneSnow ? NPCID.IceMimic : NPCID.Mimic;
		public override int ItemCost => Item.buyPrice(gold: 25);
		public override bool CanUseItem(Player player) {
        	return true;
    	}

        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.Chest, 1)
                .AddIngredient(ItemID.SoulofNight, 3)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}