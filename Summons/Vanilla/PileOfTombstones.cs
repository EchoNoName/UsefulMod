using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PileOfTombstones : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Necromancer;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Bone, 5)
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddIngredient(ItemID.Ectoplasm, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}