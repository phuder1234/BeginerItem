using Terraria.ID;
using Terraria.ModLoader;

namespace BeginerItem.Items.Weapon
{
	public class Pitsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Starter sword,Can be easily Obtain by dirt and wood");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item2;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}