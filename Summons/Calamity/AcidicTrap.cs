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

        public override int ItemCost => Item.buyPrice(silver: 75);
        public override int SummonedNPCType => ModContent.Find<ModNPC>("CalamityMod", "CragmawMire").Type;

        public override bool CanUseItem(Player player)
        {
            bool inSulphurSea = false;
            bool scourgeDowned = false;
            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
                inSulphurSea = (bool)calamity.Call("GetInZone", player, "sulfur");
                scourgeDowned = (bool)calamity.Call("GetBossDowned", "aquaticscourge");
            }
            return inSulphurSea && scourgeDowned;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ModContent.Find<ModItem>("CalamityMod", "Acidwood"), 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}