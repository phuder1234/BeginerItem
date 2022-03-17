using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BeginerItem.Items.Weapon
{
	public class SithDanger : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This danger can ruin your enemy day");
		}

		public override void SetDefaults() 
		{
			item.damage = 39;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 2;
			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 10);
			recipe.AddIngredient(ItemID.Cobweb, 99);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}