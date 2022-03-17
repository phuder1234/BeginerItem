using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BeginerItem.Npcs.BossNpc
{
	[AutoloadBossHead]
	public class Vinh : ModNPC
    {
		private int ai;
		private int attackTimer;
		private bool fastSpeed = false;
		private bool stunned;
		private int stunnedTimer;
		private int frame = 0;
		private double counting;

		public override void SetStaticDefaults()
        {
			
			Main.npcFrameCount[npc.type] = 6;
        }
		public override void SetDefaults()
        {
			npc.boss = true;
			npc.npcSlots = 5f;
			npc.width = 32;
			npc.height = 64;
			npc.aiStyle = -1;
			npc.damage = 190;
			npc.defense = 30;
			npc.lifeMax = 1500000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCHit1;
			npc.knockBackResist = 0f;
			npc.value = Item.buyPrice(gold: 99);
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			music = MusicID.Boss5;
		}
		public override void ScaleExpertStats(int numPlayer,float bossLifeScale)
        {
			npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
			npc.damage = (int)(npc.damage * 1.3f);
		}
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
			npc.rotation = 0.0f;
			npc.netAlways = true;
			npc.TargetClosest(true);
			if (npc.life >= npc.lifeMax)
				npc.life = npc.lifeMax;
			if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
			{
				npc.TargetClosest(false);
				npc.direction = 1;
				npc.velocity.Y = npc.velocity.Y - 0.1f;
				if (npc.timeLeft > 20)
				{
					npc.timeLeft = 20;
					return;

				}

			}
			if (stunned)
			{
				npc.velocity.X = 0.1f;
				npc.velocity.Y = 0.1f;
				stunnedTimer++;
				if (stunnedTimer >= 60)
				{
					stunned = false;
					stunnedTimer = 0;

				}

			}
			ai++;
			npc.ai[0] = (float)ai * 1f;
			int distance = (int)Vector2.Distance(target, npc.Center);
			if ((double)npc.ai[0] < 300)
			{
				frame = 0;
				MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
				npc.netUpdate = true;

			}
			else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450.0)
			{
				stunned = true;
				frame = 1;
				npc.defense = 3000;
				npc.damage = 3000;
				MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
				npc.netUpdate = true;

			}
			else if ((double)npc.ai[0] >= 450.0)
			{
				frame = 0;
				stunned = false;
				npc.defense = 300;
				npc.damage = 300;
				if (!fastSpeed)
				{
					fastSpeed = true;
				}
				else
				{
					if ((double)npc.ai[0] % 50 == 0)
					{
						float speed = 18f;
						Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						float x = player.position.X + (float)(player.width / 2) - vector.X;
						float y = player.position.Y + (float)(player.height / 2) - vector.Y;
						float distance2 = (float)Math.Sqrt(x * x + y * y);
						float factor = speed / distance2;
						npc.velocity.X = x * factor;
						npc.velocity.Y = y * factor;

					}
				}
				npc.netUpdate = true;
			}
			if ((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 00 && !stunned && !fastSpeed)
			{
				attackTimer++;
				if (attackTimer < 2)
				{
					frame = 2;
					npc.velocity.X = 0.1f;
					npc.velocity.Y = 0.1f;
					Vector2 shootPos = npc.Center;
					float accuracy = 10f * (npc.life / npc.lifeMax);
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
					shootVel.Normalize();
					shootVel *= 15f;
					for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
					{
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 45), shootVel.X, shootVel.Y, ProjectileID.FrostBeam, npc.damage / 1, 50f);


					}


				}
				else if (attackTimer >= 2 && attackTimer < 4)
				{
					frame = 2;
					npc.velocity.X = 0.1f;
					npc.velocity.Y = 0.1f;
					Vector2 shootPos = npc.Center;
					float accuracy = 10f * (npc.life / npc.lifeMax);
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
					shootVel.Normalize();
					shootVel *= 15f;
					for (int i = 0; i < (Main.expertMode ? 10 : 3); i++)
					{
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-80, 80), shootPos.Y - (float)Main.rand.Next(-70, 65), shootVel.X, shootVel.Y, ProjectileID.FrostWave, npc.damage * 10, 100f);


					}
				}
				else if (attackTimer >= 4 && attackTimer < 6)
				{
					frame = 2;
					npc.velocity.X = 0.1f;
					npc.velocity.Y = 0.1f;
					Vector2 shootPos = npc.Center;
					float accuracy = 10f * (npc.life / npc.lifeMax);
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
					shootVel.Normalize();
					shootVel *= 15f;
					for (int i = 0; i < (Main.expertMode ? 10 : 3); i++)
					{
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-20, 21), shootPos.Y - (float)Main.rand.Next(-30, 31), shootVel.X, shootVel.Y, ProjectileID.SniperBullet, npc.damage / 3, 50f);


					}
				}
				else if (attackTimer >= 6 && attackTimer < 8)
				{
					frame = 2;
					npc.velocity.X = 0.1f;
					npc.velocity.Y = 0.1f;
					Vector2 shootPos = npc.Center;
					float accuracy = 10f * (npc.life / npc.lifeMax);
					Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
					shootVel.Normalize();
					shootVel *= 15f;
					for (int i = 0; i < (Main.expertMode ? 10 : 3); i++)
					{
						Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-100, 100), shootPos.Y - (float)Main.rand.Next(-90, 80), shootVel.X, shootVel.Y, ProjectileID.Sharknado, npc.damage * 4, 100f);


					}
				}
				else
				{
					attackTimer = 0;
				}
			}
			if ((double)npc.ai[0] >= 650)
			{
				ai = 0;
				npc.alpha = 0;
				npc.ai[2] = 0;
				fastSpeed = false;

			}
			if (npc.life < npc.lifeMax / 2 && !stunned && !fastSpeed )
			{
				frame = 2;
				npc.velocity.X = 0.1f;
				npc.velocity.Y = 0.1f;
				Vector2 shootPos = npc.Center;
				float accuracy = 10f * (npc.life / npc.lifeMax);
				Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
				shootVel.Normalize();
				shootVel *= 15f;
				for (int i = 0; i < (Main.expertMode ? 10 : 3); i++)
				{
					Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-10, 10), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, ProjectileID.EyeLaser, npc.damage / 2, 50f);


				}
			}
			
			if (npc.life < npc.lifeMax / 5)
            {
				npc.defense += 3000;
            }
			if (npc.life < npc.lifeMax / 10 && !NPC.AnyNPCs(NPCID.QueenBee))
            {
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.QueenBee);
			}
			else
            {
				npc.defense *= 2;
            }
		}
		public override void FindFrame(int frameHeight)
        {
			if (frame == 0)
            {
				counting += 1.0;
				if (counting < 8.0)
                {
					npc.frame.Y = 0;

				}
				else if (counting < 16)
                {
					npc.frame.Y = frameHeight;

				}
				else if (counting < 24)
                {
					npc.frame.Y = frameHeight * 2;

				}
				else if (counting < 32)
                {
					npc.frame.Y = frameHeight * 3;
				}
                else
                {
					counting = 0.0;
                }

			}
			else if (frame == 1)
            {
				npc.frame.Y = frameHeight * 4;

			}
			else
            {
				npc.frame.Y = frameHeight * 5;

			}
        }
		public override void BossLoot(ref string name,ref int potionType)
        {
			potionType = ItemID.HealingPotion;
        }
		private void MoveTowards(NPC npc,Vector2 playerTarget,float speed,float turnResistance)
        {
			var move = playerTarget - npc.Center;
			float length = move.Length();
			if (length > speed)
            {
				move *= speed / length;
            }
			move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
			length = move.Length();
			if (length > speed)
            {
				move *= speed / length;
            }
			npc.velocity = move;

		}
		public override void NPCLoot()
        {
			if (Main.expertMode)
				npc.DropItemInstanced(npc.position, npc.Size, mod.ItemType("VinhGift"), 1, true);
			else
				npc.DropItemInstanced(npc.position, npc.Size, ItemID.Picksaw, 1, true);
		}
		
	}
			
		   
	
}