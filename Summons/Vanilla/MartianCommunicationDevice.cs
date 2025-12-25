using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Vanilla
{
    public class MartianCommunicationDevice : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.MartianSaucer;


        public override bool CanUseItem(Player player)
        {
            return player.ZoneDesert;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Wire, 50)
                .AddRecipeGroup("IronBar", 20)
                .AddIngredient(ItemID.BeetleHusk, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}