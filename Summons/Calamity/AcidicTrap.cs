using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class AcidicTrap : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "CragmawMire").Type;

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
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "Acidwood"), 20)
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "BleachedAnglingKit"))
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}