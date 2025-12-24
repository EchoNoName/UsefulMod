using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class HyjackedSignal : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.MartianProbe;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneSkyHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Wire, 50)
                .AddIngredient(ItemID.BeetleHusk, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}