using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class HeadOfSnakes : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Medusa;
        public override int ItemCost => Item.buyPrice(silver: 10);
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 25)
                .AddIngredient(ItemID.SoulofLight, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}