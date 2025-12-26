using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class LunarRelic : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "Eidolist").Type;

        public override int ItemCost => Item.buyPrice(gold: 50);
        public override bool CanUseItem(Player player)
        {
            bool inAbyss3rd = false;
            bool inAbyss4th = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inAbyss3rd = (bool)calamity.Call("GetInZone", player, "abyss3");
                inAbyss4th = (bool)calamity.Call("GetInZone", player, "abyss4");
            }
            return !NPC.AnyNPCs(SummonedNPCType) && (inAbyss3rd || inAbyss4th);
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "AstralMonolith"), 25)
            .AddIngredient(ItemID.SoulofNight, 15)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}