using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BeginerItem.Items.Tool
{
	public class FreakPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Now you don't need to worry about your pickaxe and axe anymore,until hardmode");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 5;
			
			item.autoReuse = true;
			item.pick = 100;
			item.axe = 50;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddIngredient(ItemID.AshBlock, 999);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}