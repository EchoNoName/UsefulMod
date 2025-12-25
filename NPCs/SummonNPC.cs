using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using UsefulMod.Summons.Vanilla;
using UsefulMod.Summons.Calamity;


namespace UsefulMod.NPCs
{
	// [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class SummonNPC : ModNPC
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
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			NPC.dontTakeDamage = true;

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
				"Q"
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
        private const string ShopName1 = "Rare Enemies";
		private const string ShopName2 = "Event Enemies";
		private static int shopNum = 1;
        public override void SetChatButtons(ref string button, ref string button2)
        {
			button2 = "Cycle Shop";
			shopNum = 1;
            switch (shopNum)
            {
                case 1:
                    button = "Rare Enemies";
                    break;

                case 2:
                    button = "Event Enemies";
                    break;

                default:
                    button = "Rare Enemies";
                    break;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton) {
                switch (shopNum)
                {
                    case 1:
                        shop = ShopName1;
                        break;
                    case 2:
                        shop = ShopName2;
                        break;
                    default:
                        shop = ShopName1;
                        break;
                }
            } else {
				shopNum++;
				if (shopNum > 2) {
					shopNum = 1;
				}
			}
        }

        public override void AddShops()
        {
            // Register the empty shop (so the name is valid when we fill it later)
            var rareEnemyShop = new NPCShop(Type, ShopName1);
			var eventEnemyShop = new NPCShop(Type, ShopName2);

			Player player = Main.LocalPlayer;
			
			rareEnemyShop.Add(new Item(ModContent.ItemType<ClumsyCrown>()) {shopCustomPrice = 1});
			rareEnemyShop.Add(new Item(ModContent.ItemType<MagicalDust>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyChest>()) {shopCustomPrice = 1}, Condition.DownedSkeletron);  
			rareEnemyShop.Add(new Item(ModContent.ItemType<PinkyCrown>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeadMansPick>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<LoveLetter>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<WeddingRing>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FossilizedSkeleton>()) {shopCustomPrice = 1});
			rareEnemyShop.Add(new Item(ModContent.ItemType<ValentineChocolate>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<VeryGoldCrown>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<TimsHat>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeclarationofWar>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<ShortStatue>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfFruits>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<Algae>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FakeJellyfish>()) {shopCustomPrice = 1}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<GuidesSoul>()) {shopCustomPrice = 1});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyScale>()) {shopCustomPrice = 1});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEye>()) {shopCustomPrice = 1});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyShark>()) {shopCustomPrice = 1}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEel>()) {shopCustomPrice = 1}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyMollusk>()) {shopCustomPrice = 1}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<RitualCircle>()) {shopCustomPrice = 1}, Condition.DownedEyeOfCthulhu);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MassiveClub>()) {shopCustomPrice = 1}, Condition.DownedMechBossAny);
			eventEnemyShop.Add(new Item(ModContent.ItemType<DragonEgg>()) {shopCustomPrice = 1}, Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MartianCommunicationDevice>()) {shopCustomPrice = 1}, Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<ThePlank>()) {shopCustomPrice = 1}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<PlunderedGoods>()) {shopCustomPrice = 1}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<CoreflameOfShadows>()) {shopCustomPrice = 1}, Condition.Hardmode);
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosSouls)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()) {shopCustomPrice = 1}, Condition.Hardmode); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1});
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1}, Condition.DownedSkeletron);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1}, Condition.DownedGolem);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()) {shopCustomPrice = 1}, Condition.DownedGolem);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()) {shopCustomPrice = 1}, Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1}, Condition.DownedSkeletron);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1}, Condition.Hardmode); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1}, Condition.Hardmode); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				rareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1}, Condition.DownedGolem);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()) {shopCustomPrice = 1}, Condition.DownedGolem);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()) {shopCustomPrice = 1}, Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()) {shopCustomPrice = 1}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargos)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1});
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1}, Condition.DownedSkeletron);
				rareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1}, Condition.DownedGolem);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
			} else {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1}, Condition.DownedSkeletron); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1}, Condition.Hardmode); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1}, Condition.Hardmode); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				rareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1}, Condition.DownedPlantera);
			}
            rareEnemyShop.Register();
			eventEnemyShop.Register();
        }
	}
}