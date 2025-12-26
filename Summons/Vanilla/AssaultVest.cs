using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class AssaultVest : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.TacticalSkeleton;

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime|| player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddIngredient(ItemID.ClayBlock, 10)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}