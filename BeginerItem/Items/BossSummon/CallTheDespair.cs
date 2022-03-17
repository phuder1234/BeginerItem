using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace BeginerItem.Items.BossSummon
{
	public class CallTheDespair : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Please don't using this,unless you have solar armor or something better");
		}

		public override void SetDefaults() 
		{
			item.maxStack = 20;
			item.width = 32;
			item.height = 32;
			item.useTime = 45;
			item.useAnimation = 45;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item2;
			item.autoReuse = false;
			item.useStyle = 4;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player)
        {
			return !NPC.AnyNPCs(mod.NPCType("Vinh"));
        }
		public override bool UseItem(Player player)
        {
			Main.PlaySound(SoundID.Roar, player.position);
			if (Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Vinh"));
            }
			return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Gel, 30);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}