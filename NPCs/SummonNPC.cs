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
using UsefulMod.Configs;


namespace UsefulMod.NPCs
{
	[AutoloadHead]
	public class SummonNPC : ModNPC
	{
		public const string ShopName = "Shop";
		public int NumberOfTimesTalkedTo = 0;

		private static Profiles.StackedNPCProfile NPCProfile;

		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<UsefulModConfig>().EnableCollector;
		}
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
			NPC.defense = 1000;
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
			
			rareEnemyShop.Add(new Item(ModContent.ItemType<ClumsyCrown>()));
			rareEnemyShop.Add(new Item(ModContent.ItemType<MagicalDust>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyChest>()), Condition.DownedSkeletron);  
			rareEnemyShop.Add(new Item(ModContent.ItemType<PinkyCrown>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeadMansPick>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<LoveLetter>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<WeddingRing>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FossilizedSkeleton>()));
			rareEnemyShop.Add(new Item(ModContent.ItemType<ValentineChocolate>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<VeryGoldCrown>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<TimsHat>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<DeclarationofWar>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<ShortStatue>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<PileOfFruits>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<Algae>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<FakeJellyfish>())); 
			rareEnemyShop.Add(new Item(ModContent.ItemType<GuidesSoul>()));
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyScale>()));
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEye>()));
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyShark>()), Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyEel>()), Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<BloodyMollusk>()), Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<RitualCircle>()), Condition.DownedEyeOfCthulhu);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MassiveClub>()), Condition.DownedMechBossAny);
			eventEnemyShop.Add(new Item(ModContent.ItemType<DragonEgg>()), Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<MartianCommunicationDevice>()), Condition.DownedGolem);
			eventEnemyShop.Add(new Item(ModContent.ItemType<ThePlank>()), Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<PlunderedGoods>()), Condition.Hardmode);
			eventEnemyShop.Add(new Item(ModContent.ItemType<CoreflameOfShadows>()), Condition.Hardmode);
			if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && ModLoader.TryGetMod("FargowiltasSouls", out Mod fargosSouls)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>())); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>())); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>())); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()), Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()), Condition.Hardmode);
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()));
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()), Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()), new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()), new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()), Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()), Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()), Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()), Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()), new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("CalamityMod", out Mod calamity)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<TrojanHorse>())); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()), Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()), Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()), Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainstormCore>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SeismicCore>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FrigidIce>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedStone>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ColossalBait>()), new Condition("Mods.allPurposeNPC.DownedAnahita", () => (bool)calamityMod.Call("GetBossDowned", "anahita")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LunarRelic>()), new Condition("Mods.allPurposeNPC.DownedCalCloneOrWof", () => Main.hardMode || (bool)calamityMod.Call("GetBossDowned", "calamitasclone")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<TankOfBlood>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()), Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ToxicBeehive>()), Condition.DownedGolem);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ChaoticEnergy>()), Condition.DownedMoonLord);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()), Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<AcidicTrap>()), new Condition("Mods.allPurposeNPC.DownedAquaticScourge", () => (bool)calamityMod.Call("GetBossDowned", "aquaticscourge")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReactiveBait>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
				eventEnemyShop.Add(new Item(ModContent.ItemType<NuclearWaste>()), new Condition("Mods.allPurposeNPC.DownedPolterghast", () => (bool)calamityMod.Call("GetBossDowned", "polterghast")));
			} else if (ModLoader.TryGetMod("FargowiltasSouls", out Mod fargos)) {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>())); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>())); 
				rareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()));
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()), Condition.DownedSkeletron);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HyjackedSignal>()), Condition.DownedGolem);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()), Condition.DownedPlantera);
			} else {
				rareEnemyShop.Add(new Item(ModContent.ItemType<SlimyKey>()), Condition.DownedSkeletron); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SuspiciousChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<SandstormCore>()), Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PermafrostCore>()), Condition.Hardmode); 
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<ClownForHire>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AncientRunes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<LitLantern>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RainbowCrown>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurntEye>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfectedChest>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HeadOfSnakes>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<FracturedSoul>()), Condition.Hardmode);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<AssaultVest>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HitmansMark>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<BurningGoggles>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<HolyShield>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<MastersBelt>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<RaggedCloak>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<PileOfTombstones>()), Condition.DownedPlantera);
				HMrareEnemyShop.Add(new Item(ModContent.ItemType<InfernalRitual>()), Condition.DownedPlantera);
				eventEnemyShop.Add(new Item(ModContent.ItemType<ReallyBigLamp>()), Condition.DownedPlantera);
			}
            rareEnemyShop.Register();
			HMrareEnemyShop.Register();
			eventEnemyShop.Register();
        }
	}
}