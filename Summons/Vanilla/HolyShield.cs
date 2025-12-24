using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class HolyShield : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Paladin;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 20)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}