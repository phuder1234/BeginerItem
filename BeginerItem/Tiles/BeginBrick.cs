using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace BeginerItem.Tiles
{
	public class BeginBrick : ModTile
	{
		public override void SetDefaults()
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("BeginBrick");
			dustType = DustID.Grass;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("BeginBrick");
			AddMapEntry(new Color(100,125,150),name);
			minPick = 1;
        }
		public override void ModifyLight(int i,int j,ref float r,ref float g,ref float b)
        {
			r = 0.5f;
			g = 0.75f;
			b = 1f;
        }
		public override void NumDust(int i,int j,bool fail,ref int num)
        {
			num = fail ? 1 : 3;
        }
	}
}