using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace BeginerItem.Items.Weapon
{
	public class SithTazeSaber : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This Saber can end your enemy fate");
		}

		public override void SetDefaults() 
		{
			item.damage = 75;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 3;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileID.GreenLaser;
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Sith_Dagger_Up"), 1);
			recipe.AddIngredient(ItemID.GoldBar, 20);
			recipe.AddIngredient(ItemID.MythrilBar, 5);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player,NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 5000);
		}
	}  
}