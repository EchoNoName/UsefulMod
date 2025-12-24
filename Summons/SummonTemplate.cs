using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace UsefulMod.Summons
{
	public abstract class SummonTemplate : ModItem
	{

        /// <summary>
        /// The NPC type this item summons.
        /// Use NPCID.X or ModContent.NPCType&lt;T&gt;()
        /// </summary>
        public abstract int SummonedNPCType { get; }

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
            if (player.whoAmI == Main.myPlayer) {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient) {
                    NPC.SpawnOnPlayer(player.whoAmI, SummonedNPCType);
                }
                else {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: SummonedNPCType);
                }
            }
            return true;
        }
	}
}