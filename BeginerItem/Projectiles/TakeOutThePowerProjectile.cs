using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BeginerItem.Projectiles
{
	public class TakeOutThePowerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Take your power");
        }
		public override void SetDefaults()
        {
			projectile.width = 8;
			projectile.height = 12;
			projectile.aiStyle = 14;
			projectile.friendly = true;
			projectile.penetrate = 20;
			projectile.ranged = true;
			projectile.noDropItem = true;

        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("TakeOutThePowerBuff"), 3000);
		}
	}
}