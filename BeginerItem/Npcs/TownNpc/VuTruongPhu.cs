using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;

namespace BeginerItem.Npcs.TownNpc
{
	[AutoloadHead]
	public class VuTruongPhu : ModNPC
	{
		public override string Texture
        {
			get { return "BeginerItem/Npcs/TownNpc/VuTruongPhu"; }
        }
		
		public override bool Autoload(ref string name)
        {
			name = "BeginerHelper";
			return mod.Properties.Autoload;
        }
		public override void SetStaticDefaults()
        {
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 3000;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 1;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults()
        {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 300;
			npc.defense = 3000;
			npc.lifeMax = 40000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCHit1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == ItemID.Wood)
					{
						return true;
					}
				}
			}
			return false;
		}
		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Tim";
				case 1:
					return "John";
				case 2:
					return "Rock";
				default:
					return "phu";
			}
		}
		public override string GetChat()
		{
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
			}
			switch (Main.rand.Next(8))
			{
				case 0:
					return "fresh airrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
				case 1:
					return "What's your favorite color? My favorite colors are red and blue.";
				case 2:
					{
						
						
						return "this world is amazing";
					}
				case 3: return "Wanna trade with me?";
				case 4: return "i wonder if there is a boss hiding somewhere";
				case 5: return "Do you think skeleton strong enough to defeat me?";
				case 6: return "i miss Scal,she really pretty";
				case 7: return " do you know there is a boss called Vinh? you can craft Call the despair to call it";
				default:
					return "i feel sleepy";
			}
		}
		public override void SetChatButtons(ref string button,ref string button2)
        {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Buff";
        }
		public override void OnChatButtonClicked(bool firstButton,ref bool shop)
        {
            if (firstButton)
            {
				shop = true;
            }
			else
            {
				Player player = new Player();
				player.AddBuff(mod.BuffType("SlimeBoostPotionBuff"), 3000); 
            }
        }
		public override void SetupShop(Chest shop,ref int nextSlot)
        {

			shop.item[nextSlot].SetDefaults(ItemID.Gel);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ThornHook);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Wood);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Chest);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.HermesBoots);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ShinyRedBalloon);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.WaterBolt);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.WaterBucket);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.PhoenixBlaster);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.DivingHelmet);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GoldCrown);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SilverBullet);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.RegenerationPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SwiftnessPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IronskinPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ManaRegenerationPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ShinePotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ArcheryPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SpelunkerPotion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Lens);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TheBreaker);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.WaterCandle);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Muramasa);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ObsidianSkull);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Stinger);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.BlackLens);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ObsidianSkinPotion);
			nextSlot++;
		}
		public override void TownNPCAttackStrength(ref int damage,ref float knockback)
        {
			damage = 190;
			knockback = 5f;
        }
		public override void TownNPCAttackCooldown(ref int cooldown,ref int randExtraCooldown)
        {
			cooldown = 1;
			randExtraCooldown = 1;
        }
		public override void TownNPCAttackProj(ref int projType,ref int attackDelay)
        {
			projType = ProjectileID.BulletHighVelocity;
			attackDelay = 1;

		}
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 18f;
			randomOffset = 2f;
		}




	}
			
		   
	
}