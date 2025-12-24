using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UsefulMod.Core;

namespace UsefulMod.Items
{
	public class LuckGod : ModItem
	{
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.rare = ItemRarityID.Master;
			Item.width = 24;
			Item.height = 50;
		}
		
		public override bool CanUseItem(Player player) {
        	return true;
    	}
		public override bool? UseItem(Player player) {
            if (player.GetModPlayer<UsefulPlayer>().LuckGod) {
                return null;
			}
			player.GetModPlayer<UsefulPlayer>().LuckGod = true;
            return true;
        }


        public override void AddRecipes() {
			// Gold version
			CreateRecipe()
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Amethyst)
				.AddIngredient(ItemID.Topaz)
				.AddIngredient(ItemID.Sapphire)
				.AddIngredient(ItemID.Emerald)
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Anvils)
				.Register();

			// Platinum version
			CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(ItemID.Amethyst)
				.AddIngredient(ItemID.Topaz)
				.AddIngredient(ItemID.Sapphire)
				.AddIngredient(ItemID.Emerald)
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(ItemID.Diamond)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}