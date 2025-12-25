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


namespace UsefulMod.NPCs
{
	// [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class PermNPC : ModNPC
	{
		public const string ShopName = "Shop";
		public int NumberOfTimesTalkedTo = 0;

		private static Profiles.StackedNPCProfile NPCProfile;


		public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = 25; // The total amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.


			// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
			NPC.Happiness
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
				.SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate) // Hates living near the demolitionist.
			; // < Mind the semicolon!

			ContentSamples.NpcBestiaryRarityStars[Type] = 3; // We can override the default bestiary star count calculation by setting this.

		}

		public override void SetDefaults() {
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = NPCAIStyleID.Passive;
			NPC.defense = 1000;
			NPC.lifeMax = 500000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;

			AnimationType = NPCID.Guide;
		}


		// The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
		// Returning false will allow you to manually draw your NPC
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			// This code slowly rotates the NPC in the bestiary
			// (simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers)) {
				drawModifiers.Rotation += 0.001f;

				// Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}

			return true;
		}


		public override bool CanTownNPCSpawn(int numTownNPCs) { 
			return true;
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

			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.StandardDialogue1"));
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.StandardDialogue2"));
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.StandardDialogue3"));
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.StandardDialogue4"));
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.CommonDialogue"), 5.0);
			chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.RareDialogue"), 0.1);

			string chosenChat = chat; // chat is implicitly cast to a string. This is where the random choice is made.
			return chosenChat;
		}
        private const string ShopName1 = "Perma Upgrades";
        public override void SetChatButtons(ref string button, ref string button2)
        {
            // The text of the two chat buttons
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
            // Register the empty shop (so the name is valid when we fill it later)
            var npcShop = new NPCShop(Type, ShopName1);

			Player player = Main.LocalPlayer;

			npcShop.Add(new Item(ItemID.LifeCrystal) {shopCustomPrice = 1}); 
			npcShop.Add(new Item(ItemID.AegisCrystal) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.ManaCrystal) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.ArcaneCrystal) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.GalaxyPearl) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.GummyWorm) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.Ambrosia) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.PeddlersSatchel) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.TorchGodsFavor) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.CombatBook) {shopCustomPrice = 1});
			npcShop.Add(new Item(ItemID.CombatBookVolumeTwo) {shopCustomPrice = 1}, Condition.Hardmode);
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) {
				npcShop.Add(new Item(ItemID.LifeFruit) {shopCustomPrice = 1}, Condition.Hardmode);
				npcShop.Add(new Item(ItemID.AegisFruit) {shopCustomPrice = 1}, Condition.Hardmode);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("CometShard").Type) { shopCustomPrice = 1 }, Condition.Hardmode);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("BloodOrange").Type) { shopCustomPrice = 1 }, Condition.DownedMechBossAll);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("MiracleFruit").Type) { shopCustomPrice = 1 }, Condition.DownedGolem);
				npcShop.Add(new Item(calamityMod.Find<ModItem>("EtherealCore").Type) { shopCustomPrice = 1 }, new Condition("Mods.allPurposeNPC.DownedNebulaTower", () => NPC.downedTowerNebula));
				npcShop.Add(new Item(calamityMod.Find<ModItem>("PhantomHeart").Type) { shopCustomPrice = 1 }, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				npcShop.Add(new Item(calamityMod.Find<ModItem>("Elderberry").Type) { shopCustomPrice = 1 }, new Condition("Mods.allPurposeNPC.DownedProvidence", () => (bool)calamityMod.Call("GetBossDowned", "providence"))); 
				npcShop.Add(new Item(calamityMod.Find<ModItem>("Dragonfruit").Type) { shopCustomPrice = 1 }, new Condition("Mods.allPurposeNPC.DownedYharon", () => (bool)calamityMod.Call("GetBossDowned", "yharon")));
			} else {
				npcShop.Add(new Item(ItemID.LifeFruit) {shopCustomPrice = 1}, Condition.DownedMechBossAny);
				npcShop.Add(new Item(ItemID.AegisFruit) {shopCustomPrice = 1}, Condition.DownedMechBossAny);
			}
            npcShop.Register();
        }
	}
}