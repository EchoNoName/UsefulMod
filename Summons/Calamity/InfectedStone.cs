using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class InfectedStone : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "Atlas").Type;

        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "AstralMonolith"), 20)
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "AstralStone"), 50)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}