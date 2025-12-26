using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class NuclearWaste : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "NuclearTerror").Type;

        public override int ItemCost => Item.buyPrice(gold: 60);
        public override bool CanUseItem(Player player)
        {
            bool inSulphurSea = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inSulphurSea = (bool)calamity.Call("GetInZone", player, "sulfur");
            }
            return inSulphurSea;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "SulphuricScale"), 20)
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "Acidwood"), 15)
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "PlagueCellCanister"), 10)
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "RuinousSoul"))
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}