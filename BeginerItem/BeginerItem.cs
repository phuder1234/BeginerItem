using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using System;
using BeginerItem;
using System.Collections.Generic;
using System.IO;

namespace BeginerItem
{
	public class BeginerItem : Mod
	{
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "Tian", 15.5f, (Func<bool>)(() => BeginerItemWorld.downedTian), "Use a [i:" + ModContent.ItemType<Items.BossSummon.CallTheJoy>() + "] at any time");
                new List<int> { ModContent.ItemType<Items.Accessory.TianGift>() }; 
                bossChecklist.Call("AddBossWithInfo", "Vinh", 15.5f, (Func<bool>)(() => BeginerItemWorld.downedVinh), "Use a [i:" + ModContent.ItemType<Items.BossSummon.CallTheDespair>() + "] at any time");
                new List<int> { ModContent.ItemType<Items.Accessory.VinhGift>() };
            }
        }
    }
}