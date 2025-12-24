using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace UsefulMod.Core
{
	public class UsefulRecipes : ModSystem
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} " +  $"{Lang.GetItemNameValue(ItemID.HerbBag)} " +  $"{Language.GetTextValue("LegacyMisc.39")}",
                ItemID.Daybloom,
                ItemID.Moonglow,
                ItemID.Blinkroot,
                ItemID.Waterleaf,
                ItemID.Fireblossom,
                ItemID.Deathweed,
                ItemID.Shiverthorn
            );
			RecipeGroup.RegisterGroup("Herbs", group);
		}
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.GoldBird);
            recipe.AddRecipeGroup("Birds");
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.DyeVat);
            recipe.Register();

            Recipe recipe1 = Recipe.Create(ItemID.GoldBunny);
            recipe1.AddIngredient(ItemID.Bunny);
            recipe1.AddIngredient(ItemID.GoldBar, 10);
            recipe1.AddTile(TileID.DyeVat);
            recipe1.Register();

            Recipe recipe2 = Recipe.Create(ItemID.GoldButterfly);
            recipe2.AddRecipeGroup("Butterflies");
            recipe2.AddIngredient(ItemID.GoldBar, 10);
            recipe2.AddTile(TileID.DyeVat);
            recipe2.Register();

            Recipe recipe3 = Recipe.Create(ItemID.GoldFrog);
            recipe3.AddIngredient(ItemID.Frog);
            recipe3.AddIngredient(ItemID.GoldBar, 10);
            recipe3.AddTile(TileID.DyeVat);
            recipe3.Register();

            Recipe recipe4 = Recipe.Create(ItemID.GoldGrasshopper);
            recipe4.AddIngredient(ItemID.Grasshopper);
            recipe4.AddIngredient(ItemID.GoldBar, 10); 
            recipe4.AddTile(TileID.DyeVat);
            recipe4.Register();

            Recipe recipe5 = Recipe.Create(ItemID.GoldMouse);
            recipe5.AddIngredient(ItemID.Mouse);
            recipe5.AddIngredient(ItemID.GoldBar, 10);
            recipe5.AddTile(TileID.DyeVat);
            recipe5.Register();

            Recipe recipe6 = Recipe.Create(ItemID.GoldWorm);
            recipe6.AddIngredient(ItemID.Worm);
            recipe6.AddIngredient(ItemID.GoldBar, 10);
            recipe6.AddTile(TileID.DyeVat);
            recipe6.Register();

            Recipe recipe7 = Recipe.Create(ItemID.SquirrelGold);
            recipe7.AddRecipeGroup("Squirrels");
            recipe7.AddIngredient(ItemID.GoldBar, 10);
            recipe7.AddTile(TileID.DyeVat);
            recipe7.Register();

            Recipe recipe8 = Recipe.Create(ItemID.GoldGoldfish);
            recipe8.AddIngredient(ItemID.Goldfish);
            recipe8.AddIngredient(ItemID.GoldBar, 10);
            recipe8.AddTile(TileID.DyeVat);
            recipe8.Register();

            Recipe recipe9 = Recipe.Create(ItemID.GoldDragonfly);
            recipe9.AddRecipeGroup("Dragonflies");
            recipe9.AddIngredient(ItemID.GoldBar, 10);
            recipe9.AddTile(TileID.DyeVat);
            recipe9.Register();

            Recipe recipe10 = Recipe.Create(ItemID.GoldLadyBug);
            recipe10.AddIngredient(ItemID.LadyBug);
            recipe10.AddIngredient(ItemID.GoldBar, 10);
            recipe10.AddTile(TileID.DyeVat);
            recipe10.Register();

            Recipe recipe11 = Recipe.Create(ItemID.GoldWaterStrider);
            recipe11.AddIngredient(ItemID.WaterStrider);
            recipe11.AddIngredient(ItemID.GoldBar, 10);
            recipe11.AddTile(TileID.DyeVat);
            recipe11.Register();

            Recipe recipe12 = Recipe.Create(ItemID.GoldSeahorse);
            recipe12.AddIngredient(ItemID.Seahorse);
            recipe12.AddIngredient(ItemID.GoldBar, 10);
            recipe12.AddTile(TileID.DyeVat);
            recipe12.Register();

            Recipe recipe13 = Recipe.Create(ItemID.TruffleWorm);
            recipe13.AddIngredient(ItemID.Worm);
            recipe13.AddIngredient(ItemID.GlowingMushroom, 15);
            recipe13.AddIngredient(ItemID.SoulofNight, 10);
            recipe13.AddTile(TileID.DemonAltar);
            recipe13.Register();

            Recipe recipe14 = Recipe.Create(ItemID.TruffleWorm, 2);
            recipe14.AddIngredient(ItemID.TruffleWorm);
            recipe14.AddTile(TileID.DemonAltar);
            recipe14.Register();

            Recipe recipe15 = Recipe.Create(ItemID.EmpressButterfly);
            recipe15.AddIngredient(ItemID.PixieDust, 20);
            recipe15.AddIngredient(ItemID.SoulofLight, 5);
            recipe15.AddIngredient(ItemID.Ectoplasm, 5);
            recipe15.AddTile(TileID.DemonAltar);

            Recipe recipe16 = Recipe.Create(ItemID.EmpressButterfly, 2);
            recipe16.AddIngredient(ItemID.EmpressButterfly);
            recipe16.AddTile(TileID.DemonAltar);
            recipe16.Register();
        }
	}
}