using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class GuidesSoul : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.VoodooDemon;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Book, 20)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}