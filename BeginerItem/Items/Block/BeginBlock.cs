using Terraria.ID;
using Terraria.ModLoader;

namespace BeginerItem.Items.Block
{
	public class BeginBlock : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			Tooltip.SetDefault("Tile...That look really weird,but you can easily craft it,so....");
		}

		public override void SetDefaults() 
		{
			item.consumable = true;
			item.maxStack = 999;
			item.width = 8;
			item.height = 8;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.value = 1;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.createTile = mod.TileType("BeginBrick");
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock ,1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}