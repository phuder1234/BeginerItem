using Terraria.ID;
using Terraria.ModLoader;
using Terraria;


namespace BeginerItem.Items.Potion
{
	public class BeginPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Make you feel faster and healthier");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item4;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useTurn = true;
			item.maxStack = 30;
			item.consumable = true;
			item.buffTime = 6000;
			item.buffType = ModContent.BuffType<Buffs.SlimeBoostPotionBuff>();
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Gel, 10);
			recipe.AddTile(ItemID.Bottle);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
}