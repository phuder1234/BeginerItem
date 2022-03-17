using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace BeginerItem.Items.Weapon
{
	public class Sith_Dagger : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This dagger can ruin your enemy day");
		}

		public override void SetDefaults() 
		{
			item.damage = 25;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 3;
			item.knockBack = 10;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Ruby, 15);
			recipe.AddIngredient(ItemID.Hellstone, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player,NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 3000);
		}
	}  
}