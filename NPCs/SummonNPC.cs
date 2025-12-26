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
	[AutoloadHead]
	public class SummonNPC : ModNPC
	{
		public const string ShopName = "Shop";
		public int NumberOfTimesTalkedTo = 0;

		private static Profiles.StackedNPCProfile NPCProfile;


		public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = 25; 

			NPCID.Sets.ExtraFramesCount[Type] = 9; 
			NPC.Happiness
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Like)
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Dislike) 
				.SetNPCAffection(ModContent.NPCType<PermNPC>(), AffectionLevel.Love) 
				.SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like) 
				.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Dislike) 
				.SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate);

			ContentSamples.NpcBestiaryRarityStars[Type] = 3; 

		}

        public override void ResetEffects() {
            NPC.dontTakeDamage = true;
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

				// Sets your NPC's flavor text in the bestiary. (use localization keys)
				new FlavorTextBestiaryInfoElement("Mods.UsefulMod.Bestiary.SummonNPC"),
				new FlavorTextBestiaryInfoElement("Mods.UsefulMod.Bestiary.SummonNPC2"),

			]);
		}
		public override void SetDefaults() {
			NPC.townNPC = true; 
			NPC.friendly = true; 
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = NPCAIStyleID.Passive;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			
			

			AnimationType = NPCID.Guide;
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

			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.SummonNPC.StandardDialogue1"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.SummonNPC.StandardDialogue2"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.SummonNPC.StandardDialogue3"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.SummonNPC.StandardDialogue4"));
			chat.Add(Language.GetTextValue("Mods.UsefulMod.Dialogue.SummonNPC.RareDialogue"), 0.1);

			string chosenChat = chat; 
			return chosenChat;
		}
        private const string ShopName1 = "Rare Enemies";
		private const string ShopName2 = "HM Rare Enemies";
		private const string ShopName3 = "Event Enemies";
		private static int shopNum = 1;
        public override void SetChatButtons(ref string button, ref string button2)
{
			button2 = "Cycle Shop";

			switch (shopNum)
			{
				case 1:
					button = "Rare Enemies";
					break;

				case 2:
					button = "HM Rare Enemies";
					break;

				case 3:
					button = "Event Enemies";
					break;

				default:
					shopNum = 1;
					button = "Rare Enemies";
					break;
			}
		}

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			if (firstButton)
			{
				switch (shopNum)
				{
					case 1:
						shop = ShopName1;
						break;

					case 2:
						shop = ShopName2;
						break;

					case 3:
						shop = ShopName3;
						break;
				}
			}
			else
			{
				shopNum++;

				if (shopNum > 3)
					shopNum = 1;
			}
		}

        public override void AddShops()
        {
            var rareEnemyShop = new NPCShop(Type, ShopName1);
			var HMrareEnemyShop = new NPCShop(Type, ShopName2);
			var eventEnemyShop = new NPCShop(Type, ShopName3);

			Player player = Main.LocalPlayer;
			
			rareEnemyShop.Add(new Item(ModContent.ItemType<ClumsyCrown>()) {shopCustomPrice = 1000000});
			rareEnemyShop.Add(new Item(ModContent.ItemType<MagicalDust>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyChest>()) {shopCustomPrice = 1000000}, Condition.DownedSkeletron);  
			rareEnemyShop.Add(new Item(ModContent.ItemType<PinkyCrown>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeadMansPick>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<LoveLetter>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<WeddingRing>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FossilizedSkeleton>()) {shopCustomPrice = 1000000});
			rareEnemyShop.Add(new Item(ModContent.ItemType<ValentineChocolate>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<VeryGoldCrown>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<TimsHat>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeclarationofWar>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<ShortStatue>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfFruits>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<Algae>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FakeJellyfish>()) {shopCustomPrice = 1000000}); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<GuidesSoul>()) {shopCustomPrice = 1000000});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyScale>()) {shopCustomPrice = 1000000});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEye>()) {shopCustomPrice = 1000000});
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyShark>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEel>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyMollusk>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<RitualCircle>()) {shopCustomPrice = 1000000}, Condition.DownedEyeOfCthulhu);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MassiveClub>()) {shopCustomPrice = 1000000}, Condition.DownedMechBossAny);
			eventEnemyShop.Add(new Item(ModContent.ItemType<DragonEgg>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MartianCommunicationDevice>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<ThePlank>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<PlunderedGoods>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<CoreflameOfShadows>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosSouls)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>()) {shopCustomPrice = 1000000}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1000000}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1000000}); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1000000});
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1000000}, Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()) {shopCustomPrice = 1000000}, Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>()) {shopCustomPrice = 1000000}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1000000}, Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()) {shopCustomPrice = 1000000}, Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()) {shopCustomPrice = 1000000}, new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargos)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1000000}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1000000}); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1000000});
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1000000}, Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()) {shopCustomPrice = 1000000}, Condition.DownedGolem);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
			} else {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()) {shopCustomPrice = 1000000}, Condition.DownedSkeletron); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()) {shopCustomPrice = 1000000}, Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()) {shopCustomPrice = 1000000}, Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()) {shopCustomPrice = 1000000}, Condition.DownedPlantera);
			}
            rareEnemyShop.Register();
			HMrareEnemyShop.Register();
			eventEnemyShop.Register();
        }
	}
}