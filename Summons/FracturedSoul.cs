using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons
{
    public class FracturedSoul : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DemonTaxCollector;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.SoulofLight, 3)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}   