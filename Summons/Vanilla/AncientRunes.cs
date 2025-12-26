using Terraria;
using Terraria.ID;


namespace UsefulMod.Summons.Vanilla
{
	public class AncientRunes : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.RuneWizard;
		
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.Diamond, 3)
				.AddIngredient(ItemID.RedPaint, 2)
				.Register();
		}
	}
}