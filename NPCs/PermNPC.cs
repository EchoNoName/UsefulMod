using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using UsefulMod.Configs;


namespace UsefulMod.NPCs
{
	[AutoloadHead]
	public class PermNPC : ModNPC
	{
		public const string ShopName = "Shop";
		public int NumberOfTimesTalkedTo = 0;

		private static Profiles.StackedNPCProfile NPCProfile;

		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<UsefulModConfig>().EnableAnomaly;
		}
		public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = 25; 

			NPCID.Sets.ExtraFramesCount[Type] = 9; 


			NPC.Happiness
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Like) 
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) 
				.SetNPCAffection(ModContent.NPCType<SummonNPC>(), AffectionLevel.Love) 
				.SetNPCAffection(NPCID.Truffle, AffectionLevel.Like) 
				.SetNPCAffection(NPCID.Nurse, AffectionLevel.Dislike) 
				.SetNPCAffection(NPCID.Angler, AffectionLevel.Hate); 

			ContentSamples.NpcBestiaryRarityStars[Type] = 3; 

		}

		public override void SetDefaults() {
			NPC.townNPC = true; 
			NPC.friendly = true; 
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = NPCAIStyleID.Passive;
			NPC.defense = 0;
			NPC.lifeMax = 500000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;

			AnimationType = NPCID.Guide;
		}

        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {
            modifiers.SetMaxDamage(1);
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

				new FlavorTextBestiaryInfoElement("Mods.UsefulMod.Bestiary.PermNPC"),
				new FlavorTextBestiaryInfoElement("Mods.UsefulMod.Bestiary.PermNPC2"),

			]);
		}

		public override bool CanTownNPCSpawn(int numTownNPCs) { 
			return Main.LocalPlayer.statLifeMax2 > 100;
		}

		public override ITownNPCProfile TownNPCProfile() {
			return NPCProfile;
		}

		public override List<string> SetNPCNameList() {
			return new List<string>() {
				"P"
			};
		}


		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();

			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.PermNPC.StandardDialogue1"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.PermNPC.StandardDialogue2"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.PermNPC.StandardDialogue3"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.PermNPC.StandardDialogue4"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.PermNPC.RareDialogue"), 0.1);

			string chosenChat = chat; 
			return chosenChat;
		}
        private const string ShopName1 = "Perma Upgrades";
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Perma Upgrades"; // This opens the shop
            button2 = "Goodbye"; // This just closes the chat
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName1;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName1);

			Player player = Main.LocalPlayer;

			npcShop.Add(new Item(ItemID.LifeCrystal) {shopCustomPrice = 22500}); 
			npcShop.Add(new Item(ItemID.AegisCrystal) {shopCustomPrice = 22500});
			npcShop.Add(new Item(ItemID.ManaCrystal) {shopCustomPrice = 12500});
			npcShop.Add(new Item(ItemID.ArcaneCrystal) {shopCustomPrice = 15000});
			npcShop.Add(new Item(ItemID.GalaxyPearl) {shopCustomPrice = 1000000});
			npcShop.Add(new Item(ItemID.GummyWorm) {shopCustomPrice = 500000});
			npcShop.Add(new Item(ItemID.Ambrosia) {shopCustomPrice = 5000});
			npcShop.Add(new Item(ItemID.PeddlersSatchel) {shopCustomPrice = 100000});
			npcShop.Add(new Item(ItemID.TorchGodsFavor) {shopCustomPrice = 500000});
			npcShop.Add(new Item(ItemID.CombatBook) {shopCustomPrice = 100000});
			npcShop.Add(new Item(ItemID.CombatBookVolumeTwo) {shopCustomPrice = 125000}, Condition.Hardmode);
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) {
				npcShop.Add(new Item(ItemID.LifeFruit) {shopCustomPrice = 45000}, Condition.Hardmode);
				npcShop.Add(new Item(ItemID.AegisFruit) {shopCustomPrice = 45000}, Condition.Hardmode);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("CometShard").Type) {shopCustomPrice = 50000}, Condition.Hardmode);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("BloodOrange").Type) {shopCustomPrice = 1000000}, Condition.DownedMechBossAll);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("MiracleFruit").Type) {shopCustomPrice = 2000000}, Condition.DownedGolem);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("EtherealCore").Type) {shopCustomPrice = 3000000}, new Condition("Mods.allPurposeNPC.DownedNebulaTower", () => NPC.downedTowerNebula));
				npcShop.Add(new Item(calamityMod.Find<ModItem>("PhantomHeart").Type) {shopCustomPrice = 5000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				npcShop.Add(new Item(calamityMod.Find<ModItem>("Elderberry").Type) {shopCustomPrice = 7500000}, new Condition("Mods.allPurposeNPC.DownedProvidence", () => (bool)calamityMod.Call("GetBossDowned", "providence"))); 
				npcShop.Add(new Item(calamityMod.Find<ModItem>("Dragonfruit").Type) {shopCustomPrice = 10000000}, new Condition("Mods.allPurposeNPC.DownedYharon", () => (bool)calamityMod.Call("GetBossDowned", "yharon")));
			} else {
				npcShop.Add(new Item(ItemID.LifeFruit) {shopCustomPrice = 65000}, Condition.DownedMechBossAny);
				npcShop.Add(new Item(ItemID.AegisFruit) {shopCustomPrice = 65000}, Condition.DownedMechBossAny);
			}
            npcShop.Register();
        }
	}
}