using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PileOfTombstones : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.Necromancer;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Bone, 20)
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}