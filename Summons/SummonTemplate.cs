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

namespace UsefulMod.Summons
{
	public abstract class SummonTemplate : ModItem
	{

        /// <summary>
        /// The NPC type this item summons.
        /// Use NPCID.X or ModContent.NPCType&lt;T&gt;()
        /// </summary>
        public abstract int SummonedNPCType { get; }

        public virtual bool IsBoss { get; } = false;

        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 0;

        }

		public override void SetDefaults() {
			Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
		}
		
		public override bool? UseItem(Player player) {

            float x_spawn_cord = player.position.X + Main.rand.Next(-800, 800);
            float y_spawn_cord = player.position.Y + Main.rand.Next(-800, -300);
            if (player.whoAmI == Main.myPlayer)
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient) {
                    if (IsBoss) {
                        NPC.SpawnOnPlayer(player.whoAmI, SummonedNPCType);
                    }
                    else {
                        LocalizedText text = Language.GetText("Announcement.HasAwoken");
                        int n = NPC.NewNPC(player.GetSource_ItemUse(Item), (int)x_spawn_cord, (int)y_spawn_cord, SummonedNPCType);
                        String npcName = Lang.GetNPCNameValue(SummonedNPCType);
                        ChatHelper.BroadcastChatMessage(text.ToNetworkText(npcName), new Color(175, 75, 255));
                    }
                }
                else {
                    if (IsBoss) {
                        NPC.SpawnOnPlayer(player.whoAmI, SummonedNPCType);
                    } else {
                        LocalizedText text = Language.GetText("Announcement.HasAwoken");
                        int n = NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)x_spawn_cord, (int)y_spawn_cord, SummonedNPCType);
                        String npcName = Lang.GetNPCNameValue(SummonedNPCType);
                        if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.SyncNPC, number: n);
                            ChatHelper.BroadcastChatMessage(text.ToNetworkText(npcName), new Color(175, 75, 255));
                            // Sends Has awoken message in chat for multuplayer
                    }
                }
            return true;
        }
	}
}