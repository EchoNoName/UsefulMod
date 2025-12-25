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
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 100)
                .AddIngredient(ItemID.SoulofSight)
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 100)
                .AddIngredient(ItemID.SoulofMight)
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}