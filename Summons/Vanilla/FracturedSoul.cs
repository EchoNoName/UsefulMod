using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
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
                .AddIngredient(ItemID.SoulofNight, 2)
                .AddIngredient(ItemID.SoulofLight, 2)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}   