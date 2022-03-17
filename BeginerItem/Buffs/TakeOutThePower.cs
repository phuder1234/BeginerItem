using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria;
using Microsoft.Xna.Framework;

namespace BeginerItem.Buffs
{
	
	public class TakeOutThePowerBuff : ModBuff
	{
		public override void SetDefaults()
        {
			DisplayName.SetDefault("TakeOutThePowerBuff");
			Description.SetDefault("just like my name!");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
        }
		public override void Update(NPC npc,ref int buffIndex)
        {
			npc.defense -= 200;
			npc.damage -= 200;
			npc.life -= 20;
			
		}
	}
}