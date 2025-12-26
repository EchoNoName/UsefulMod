using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Vanilla
{
    public class PermafrostCore : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.IceGolem;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneSnow;
        }
        public override void AddRecipes() { 
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls)) {
                CreateRecipe()
                    .AddIngredient(ItemID.IceBlock, 25)
                    .AddIngredient(ItemID.GoldBar, 5)
                    .AddTile(TileID.Anvils)
                    .Register();

                CreateRecipe()
                    .AddIngredient(ItemID.IceBlock, 25)
                    .AddIngredient(ItemID.PlatinumBar, 5)
                    .AddTile(TileID.Anvils)
                    .Register();
            } else {
                CreateRecipe()
                    .AddIngredient(ItemID.IceBlock, 25)
                    .AddIngredient(ItemID.SoulofNight, 3)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
}