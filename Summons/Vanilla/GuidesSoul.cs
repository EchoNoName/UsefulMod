using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class GuidesSoul : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.VoodooDemon;
        public override int ItemCost => Item.buyPrice(silver: 25);
        public override bool CanUseItem(Player player)
        {
            return player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}