using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace BeginerItem.Items.Accessory
{
	public class VinhGift : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("You defeat him,You are Worthy enough for this.This Give you...just equip it and you will know");
		}

		public override void SetDefaults() 
		{
			
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.value = 100;
			item.rare = 11;
			item.accessory = true;


		}
		public override void UpdateAccessory(Player player,bool hideVisual)
        {
			player.accFlipper = true;
			player.accMerman = true;
			player.findTreasure = true;
			player.lifeRegen += 300;
			player.lifeRegenCount = 2;
			player.meleeSpeed += 3.0f;
			player.meleeDamage += 40f;
			player.maxMinions += 4;
			player.magicDamage += 30f;
			player.magicCrit += 30;
			player.detectCreature = true;

		}

		
	}
}