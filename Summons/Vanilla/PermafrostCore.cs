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
                    .AddIngredient(ItemID.IceBlock, 100)
                    .AddIngredient(ItemID.GoldBar, 10)
                    .AddTile(TileID.Anvils)
                    .Register();

                CreateRecipe()
                    .AddIngredient(ItemID.IceBlock, 100)
                    .AddIngredient(ItemID.PlatinumBar, 10)
                    .AddTile(TileID.Anvils)
                    .Register();
            } else {
                CreateRecipe()
                    .AddIngredient(ItemID.IceBlock, 100)
                    .AddIngredient(ItemID.SoulofNight, 10)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
}