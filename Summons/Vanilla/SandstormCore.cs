using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Vanilla
{
    public class SandstormCore : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SandElemental;


        public override bool CanUseItem(Player player)
        {
            return player.ZoneDesert;
        }
        public override void AddRecipes() {  
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls)) {
                CreateRecipe()
                    .AddIngredient(ItemID.SandBlock, 100)
                    .AddIngredient(ItemID.GoldBar, 10)
                    .AddTile(TileID.Anvils)
                    .Register();

                CreateRecipe()
                    .AddIngredient(ItemID.SandBlock, 100)
                    .AddIngredient(ItemID.PlatinumBar, 10)
                    .AddTile(TileID.Anvils)
                    .Register();
            } else {
                CreateRecipe()
                    .AddIngredient(ItemID.SandBlock, 100)
                    .AddIngredient(ItemID.SoulofLight, 10)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
}