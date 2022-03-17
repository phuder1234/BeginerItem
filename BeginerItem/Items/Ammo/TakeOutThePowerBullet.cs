using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BeginerItem.Items.Ammo
{
	public class TakeYourPowerBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This thing doesn't seem powerful,Or is it?");
		}

		public override void SetDefaults() 
		{
			item.consumable = true;
			item.damage = 40;
			item.width = 10;
			item.height = 10;
			item.maxStack = 999;
			item.ranged = true;
			item.rare = ItemRarityID.Pink;
			item.shoot = mod.ProjectileType("TakeOutThePowerProjectile");
			item.value = 10;
			item.ammo = AmmoID.Bullet;
			item.shootSpeed = 15f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBullet, 1);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}