using Terraria;
using Terraria.ID;

namespace UsefulMod.Summons.Vanilla
{
    public class PileOfFruits : SummonTemplate
    {
        public override int SummonedNPCType => Main.LocalPlayer.ZoneSnow ? NPCID.CyanBeetle : Main.LocalPlayer.ZoneJungle ? NPCID.LacBeetle : NPCID.CochinealBeetle;

        public override bool CanUseItem(Player player)
        {
            return player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddRecipeGroup("Fruit", 30)
                .Register();
        }
    }
}