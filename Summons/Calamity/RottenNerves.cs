
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Calamity
{
[ExtendsFromMod("CalamityMod")]
[JITWhenModsEnabled("CalamityMod")]
    public class RottenNerves : SummonTemplate
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("CalamityMod");
        public override int SummonedNPCType => Main.LocalPlayer.ZoneCorrupt ? ModContent.Find<ModNPC>("CalamityMod", "HiveMind").Type : ModContent.Find<ModNPC>("CalamityMod", "PerforatorHive").Type;
        
        public override bool IsBoss => true;

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneCorrupt && !NPC.AnyNPCs(ModContent.Find<ModNPC>("CalamityMod", "HiveMind").Type)) || (player.ZoneCrimson && !NPC.AnyNPCs(ModContent.Find<ModNPC>("CalamityMod", "PerforatorHive").Type));
        }
        public override void AddRecipes() {  
            CreateRecipe()
            .AddIngredient(ItemID.RottenChunk, 10)
            .AddIngredient(ItemID.DemoniteBar, 10)
            .AddTile(TileID.Anvils)
                .Register();
            
            CreateRecipe()
            .AddIngredient(ItemID.Vertebrae, 10)
            .AddIngredient(ItemID.CrimtaneBar, 10)
            .AddTile(TileID.Anvils)
                .Register();
        }
    }
}