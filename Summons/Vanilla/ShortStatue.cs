using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ShortStatue : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Gnome;

        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 100)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}