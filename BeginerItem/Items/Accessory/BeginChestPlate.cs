using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace BeginerItem.Items.Accessory
{
	[AutoloadEquip(EquipType.Body)]
	public class BeginChestPlate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("make you swing your sword faster");
		}

		public override void SetDefaults() 
		{
			
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.value = 100;
			item.rare = 2;
			item.defense = 10;


		}
		public override void UpdateEquip(Player player)
        {
			player.meleeSpeed += 2f;
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