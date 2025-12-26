using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Vanilla
{
    public class MartianCommunicationDevice : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.MartianSaucerCore;
        public override int ItemCost => Item.buyPrice(gold: 42);
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Wire, 50)
                .AddRecipeGroup("IronBar", 20)
                .AddIngredient(ItemID.BeetleHusk, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}