using BeginerItem.Items;
using BeginerItem.Npcs;
using BeginerItem.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace BeginerItem
{
	public class BeginerItemWorld : ModWorld
	{
		public static bool downedTian;
		public static bool downedVinh;
		public const int VolcanoProjectiles = 30;
		public const float VolcanoAngleSpread = 170;
		public const int DefaultVolcanoTremorTime = 200; // ~ 3 seconds
		public const int DefaultVolcanoCountdown = 300; // 5 seconds
		public const int DefaultVolcanoCooldown = 10000; // At least 3 min of daytime between volcanoes
		public const int VolcanoChance = 10000; // Chance each tick of Volcano if cooldown exhausted.
		public int VolcanoCountdown;
		public int VolcanoCooldown = DefaultVolcanoCooldown;
		public int VolcanoTremorTime;
		public static int exampleTiles;

		public override void Initialize()
		{
			downedTian = false;
			downedTian = false;
			VolcanoCountdown = 0;
			VolcanoTremorTime = 0;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedTian)
			{
				downed.Add("Tian");
			}

			if (downedVinh)
			{
				downed.Add("Vinh");
			}
			return new TagCompound
			{
				["downed"] = downed,
			};

		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedTian = flags[0];
				downedVinh = flags[1];
			}
			else
			{
				mod.Logger.WarnFormat("BeginerItemMod: Unknown loadVersion: {0}", loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedTian;
			flags[1] = downedVinh;
			writer.Write(flags);

		}
	}
}