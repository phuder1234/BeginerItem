using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace BeginerItem.Items.Accessory
{
	public class TianGift : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("I don't know how you can defeat that thing. Take this and equip it, it is your now");
		}

		public override void SetDefaults() 
		{
			
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.value = 100;
			item.rare = 12;
			item.accessory = true;


		}
		public override void UpdateAccessory(Player player,bool hideVisual)
        {
			player.accFlipper = true;
			player.accMerman = true;
			player.findTreasure = true;
			player.lifeRegen += 300;
			player.lifeRegenCount *= 2;
			player.maxMinions += 15;
			player.detectCreature = true;
			player.moveSpeed += 100;
			player.rangedCrit += 50;
			player.rangedDamage *= 6;
			player.minionDamage *= 6;

		}

		
	}
}