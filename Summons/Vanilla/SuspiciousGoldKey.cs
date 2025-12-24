using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class SuspiciousGoldKey : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DungeonSlime;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 30)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 30)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}