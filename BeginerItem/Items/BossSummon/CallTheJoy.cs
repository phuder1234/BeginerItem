using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;

namespace BeginerItem.Items.BossSummon
{
	public class CallTheJoy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Are you sure about this? Well,becareful in the first 30s of the boss fight,and after you take his health down to 50%");
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
			item.UseSound = SoundID.Item15;
			item.autoReuse = false;
			item.useStyle = 4;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player)
        {
			return !NPC.AnyNPCs(mod.NPCType("Tian"));
        }
		public override bool UseItem(Player player)
        {
			Main.PlaySound(SoundID.Roar, player.position);
			if (Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Tian"));
            }
			return true;
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Tombstone, 1);
			recipe.AddIngredient(ItemID.Piano, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}