using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UsefulMod.Summons;

namespace UsefulMod
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class UsefulMod : Mod
	{
		public override void HandlePacket(BinaryReader reader, int whoAmI) {
			byte msgType = reader.ReadByte();

			switch (msgType) {
				case 0:
					int npcType = reader.ReadInt32();
					bool isBoss = reader.ReadBoolean();

					Player player = Main.player[whoAmI];

					if (Main.netMode != NetmodeID.Server)
						return;

					SpawnNPCServer(player, npcType, isBoss);
					break;
				default:
					Logger.WarnFormat("UsefulMod: Unknown Message type: {0}", msgType);
					break;
			}
		}

		private void SpawnNPCServer(Player player, int npcType, bool isBoss) {
			if (isBoss) {
				Vector2 spawnPosition = player.Center;
				int x_off_set = Main.rand.NextBool() ? Main.rand.Next(1000, 1201) : Main.rand.Next(-1200, -999);
				NPC.SpawnBoss((int)(spawnPosition.X + x_off_set), (int)(spawnPosition.Y - 1000f), npcType, player.whoAmI);
			} else {
				float x_spawn_cord = player.position.X + (Main.rand.NextBool() ? Main.rand.Next(-800, -301) : Main.rand.Next(300, 801));
            	float y_spawn_cord = player.position.Y + Main.rand.Next(-800, -300);
				LocalizedText text = Language.GetText("Announcement.HasAwoken");
				int n = NPC.NewNPC(player.GetSource_ItemUse(player.HeldItem), (int)x_spawn_cord, (int)y_spawn_cord, npcType);
				String npcName = Lang.GetNPCNameValue(npcType);
				if (n != Main.maxNPCs) {
					NetMessage.SendData(MessageID.SyncNPC, number: n);
					ChatHelper.BroadcastChatMessage(text.ToNetworkText(npcName), new Color(175, 75, 255));
					// Sends Has awoken message in chat for multuplayer 
				}
			}
		}
	}
}
