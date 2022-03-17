using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria;
using Microsoft.Xna.Framework;

namespace BeginerItem.Buffs
{
	
	public class SlimeBoostPotionBuff : ModBuff
	{
		public override void SetDefaults()
        {
			DisplayName.SetDefault("SlimeBoostUp");
			Description.SetDefault("Grant a bit of speed and regen!");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
        }
		public override void Update(Player player,ref int buffIndex)
        {
			player.lifeRegen += 30;
			player.moveSpeed += 30;
		}
	}
}