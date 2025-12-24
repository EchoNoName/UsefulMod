using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace UsefulMod.Core
{
	public class UsefulPlayer : ModPlayer
	{
		public bool LuckGod;
        
        public override void PostUpdate() {
            if (LuckGod) {
                Player.luck = 1f;
            }
        }
	}
}