using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class SeismicCore : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "Horse").Type;

        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.StoneBlock, 100)
            .AddIngredient(ItemID.SoulofLight, 10)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}