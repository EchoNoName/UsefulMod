using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ShortStatue : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Gnome;
        public override int ItemCost => Item.buyPrice(gold: 1);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 150)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}