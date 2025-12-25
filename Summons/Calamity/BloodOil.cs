using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class BloodOil : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "OldDuke").Type;

        public override bool IsBoss => true;

        public override bool CanUseItem(Player player)
        {
            bool inSulphurSea = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inSulphurSea = (bool)calamity.Call("GetInZone", player, "sulfur");
            }
            return !NPC.AnyNPCs(SummonedNPCType) && inSulphurSea;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "BloodwormItem").Type)
                .AddTile(TileID.CookingPots)
                .Register();
        }
    }
}