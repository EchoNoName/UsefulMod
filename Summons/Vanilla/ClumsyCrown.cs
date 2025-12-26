using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class ClumsyCrown : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BoundTownSlimePurple;

        public override int ItemCost => Item.buyPrice(gold: 5);
        public override bool CanUseItem(Player player)
        {
            return player.ZoneSkyHeight;
        }

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.WoodenArrow)
                .AddIngredient(ItemID.Gel, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}