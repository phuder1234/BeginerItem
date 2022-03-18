using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace BeginerItem.Items.Accessory
{
	[AutoloadEquip(EquipType.Legs)]
	public class BeginSandals : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("make you....uh,run faster i guess");
		}

		public override void SetDefaults() 
		{
			
			item.width = 18;
			item.height = 18;
			item.value = 100;
			item.rare = 11;
			item.defense = 9;


		}
		public override void UpdateEquip(Player player)
        {
			player.moveSpeed += 100;

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}



	}
}