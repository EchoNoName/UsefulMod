using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class SlimyChest : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.BoundTownSlimeOld;
        public override int ItemCost => Item.buyPrice(gold: 5);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Chest)
                .AddIngredient(ItemID.Gel, 10)
                .AddIngredient(ItemID.Bone, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}