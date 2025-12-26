using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using Microsoft.Build.Evaluation;

namespace UsefulMod.Summons.Vanilla
{
    public class RitualCircle : SummonTemplate
    {
        public override int SummonedNPCType => NPC.downedGolemBoss ? NPCID.DD2DarkMageT3: NPCID.DD2DarkMageT1;
        public override int ItemCost => Item.buyPrice(gold: 1);
        public override bool? UseItem(Player player) {

            float x_spawn_cord = player.position.X + (Main.rand.NextBool() ? Main.rand.Next(-800, -301) : Main.rand.Next(300, 801));
            float y_spawn_cord = player.position.Y - 5;
            if (player.whoAmI == Main.myPlayer)
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient) {
                    LocalizedText text = Language.GetText("Announcement.HasAwoken");
                    int n = NPC.NewNPC(player.GetSource_ItemUse(Item), (int)x_spawn_cord, (int)y_spawn_cord, SummonedNPCType);
                    String npcName = Lang.GetNPCNameValue(SummonedNPCType);
                    ChatHelper.BroadcastChatMessage(text.ToNetworkText(npcName), new Color(175, 75, 255));
                } else {
                    LocalizedText text = Language.GetText("Announcement.HasAwoken");
                    int n = NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)x_spawn_cord, (int)y_spawn_cord, SummonedNPCType);
                    String npcName = Lang.GetNPCNameValue(SummonedNPCType);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);
                        ChatHelper.BroadcastChatMessage(text.ToNetworkText(npcName), new Color(175, 75, 255));
                        // Sends Has awoken message in chat for multuplayer
                }
            return true;
        }
        public override void AddRecipes() {  
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 10)
                .AddIngredient(ItemID.ShadowScale, 3)
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
            
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddIngredient(ItemID.TissueSample, 3)
                .AddIngredient(ItemID.DD2ElderCrystal)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}