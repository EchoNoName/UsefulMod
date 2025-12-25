using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class MassiveClub : SummonTemplate
    {
        public override int SummonedNPCType => NPC.downedGolemBoss ? NPCID.DD2OgreT3: NPCID.DD2OgreT2;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 100)
                .AddIngredient(ItemID.SoulofFright)
                .AddTile(TileID.DemonAltar)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 100)
                .AddIngredient(ItemID.SoulofSight)
                .AddTile(TileID.DemonAltar)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 100)
                .AddIngredient(ItemID.SoulofMight)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}