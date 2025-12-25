using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class TankOfBlood : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "ReaperShark").Type;

        public override bool CanUseItem(Player player)
        {
            bool inAbyss4th = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inAbyss4th = (bool)calamity.Call("GetInZone", player, "abyss4");
            }
            return inAbyss4th;
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "BloodOrb"), 75)
            .AddIngredient(ItemID.Glass, 20)
            .AddIngredient(ItemID.LunarBar, 10)
                .Register();
        }
    }
}