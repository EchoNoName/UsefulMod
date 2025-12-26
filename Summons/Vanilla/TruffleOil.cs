using Terraria;
using Terraria.ID;
using Terraria.Audio;

namespace UsefulMod.Summons.Vanilla
{
    public class TruffleOil : SummonTemplate
    {
        public override int SummonedNPCType => NPCID.DukeFishron;

        public override int ItemCost => Item.buyPrice(gold: 25);
        public override bool CanUseItem(Player player) => !NPC.AnyNPCs(NPCID.DukeFishron) && player.ZoneBeach;
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.TruffleWorm, 1)
                .AddTile(TileID.CookingPots)
                .Register();
        }

        public override bool? UseItem(Player player) { // For some reason, Duke Fishron doesn't spawn with NPC.SpawnOnPlayer
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient) {
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                // random number from -1200 to -1000 or 1000 to 1200
                int x_off_set = Main.rand.NextBool() ? Main.rand.Next(1000, 1201) : Main.rand.Next(-1200, -999);
                int y_off_set = Main.rand.Next(-800, 801); // random number from -800 to 800
                int n = NPC.NewNPC(player.GetSource_ItemUse(Item), (int)(player.position.X + x_off_set), (int)(player.position.Y - y_off_set), NPCID.DukeFishron);
            }
            else {
                int x_off_set = Main.rand.NextBool() ? Main.rand.Next(1000, 1201) : Main.rand.Next(-1200, -999);
                int y_off_set = Main.rand.Next(-800, 801); // random number from -800 to 800
                int n = NPC.NewNPC(player.GetSource_ItemUse(Item), (int)(player.position.X + x_off_set), (int)(player.position.Y - y_off_set), NPCID.DukeFishron);
                if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.SyncNPC, number: n);
            }
            return true;
        }
    }
}