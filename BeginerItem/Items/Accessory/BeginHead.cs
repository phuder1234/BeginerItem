using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace BeginerItem.Items.Accessory
{
	[AutoloadEquip(EquipType.Head)]
	public class BeginHead : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("this helmet make you feel stronger");
		}

		public override void SetDefaults() 
		{
			
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.value = 100;
			item.rare = 11;
			item.defense = 10;


		}
		public override void UpdateEquip(Player player)
        {
			player.meleeDamage += 5;

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
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
			return body.type == mod.ItemType("blazebornchestplate") && legs.type == mod.ItemType("blazeborngreaves");
        }
        public override void UpdateArmorSet(Player player)
        {
			player.meleeDamage += 15;
			player.findTreasure = true;
        }


    }
}