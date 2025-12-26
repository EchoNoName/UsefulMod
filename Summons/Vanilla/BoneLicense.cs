using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class BoneLicense : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.SkeletonMerchant;
        public override int ItemCost => Item.buyPrice(silver: 50);
        public override bool CanUseItem(Player player)
        {
            return player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddIngredient(ItemID.Torch, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}