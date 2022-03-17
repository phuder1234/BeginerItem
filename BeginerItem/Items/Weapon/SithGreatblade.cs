using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace BeginerItem.Items.Weapon
{
	public class SithGreatBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This Blade....Bonk your enemy");
		}

		public override void SetDefaults() 
		{
			item.damage = 45;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Sith_Dagger"), 1);
			recipe.AddIngredient(ItemID.GoldBar, 20);
			recipe.AddIngredient(ItemID.Cobweb, 50);
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