using Terraria;
using Terraria.ID;

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
            CreateRecipe()
                .AddIngredient(ItemID.IceBlock, 100)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}