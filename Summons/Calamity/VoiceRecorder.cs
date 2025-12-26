using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class VoiceRecorder : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "Anahita").Type;

        public override bool IsBoss => true;

        public override bool CanUseItem(Player player)
        {
            bool inSulphurSea = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inSulphurSea = (bool)calamity.Call("GetInZone", player, "sulfur");
            }
            return !NPC.AnyNPCs(SummonedNPCType) && player.ZoneBeach && !inSulphurSea;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Seashell, 5)
                .AddRecipeGroup("IronBar", 10)
                .Register();
        }
    }
}