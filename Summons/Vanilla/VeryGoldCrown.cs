using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class VeryGoldCrown : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.GoldenSlime;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.Gel, 20)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBar, 10)
                .AddIngredient(ItemID.Gel, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}