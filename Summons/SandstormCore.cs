using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class SandstormCore : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SandElemental;


        public override bool CanUseItem(Player player)
        {
            return player.ZoneDesert;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.SandBlock, 100)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}