using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UsefulMod.Summons.Vanilla
{
    public class InfectedChest : SummonTemplate
    {

        private bool SpecialJungleAllowed() {
            // Celebration / GetFixedBoi worlds
            if (Main.getGoodWorld || Main.zenithWorld)
                return true;

            // Fargo's Souls Eternity/Masochist Mode
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls))
            {
                // ModCall returns object → cast to bool
                if (fargoSouls.Call("Emode") is bool eternity && eternity || fargoSouls.Call("Masomode") is bool maso && maso)
                    return true;
            }

            return false;
        }
        
        public override bool CanUseItem(Player player)
        {
            return player.ZoneCorrupt || player.ZoneCrimson || player.ZoneHallow || (player.ZoneJungle && SpecialJungleAllowed());
        }
        public override int SummonedNPCType => 
            Main.LocalPlayer.ZoneCorrupt ? NPCID.BigMimicCorruption : 
            Main.LocalPlayer.ZoneCrimson ? NPCID.BigMimicCrimson : 
            Main.LocalPlayer.ZoneHallow ? NPCID.BigMimicHallow : 
            Main.LocalPlayer.ZoneJungle && SpecialJungleAllowed() ? NPCID.BigMimicJungle : 
            NPCID.Mimic;

        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.Chest)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddIngredient(ItemID.JungleSpores, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}