using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class DragonEgg : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DD2Betsy;
        
        public override int ItemCost => Item.buyPrice(gold: 50);
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.BeetleHusk, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}