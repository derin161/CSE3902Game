using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    //Author: Nyigel Spann
    public interface IItem : IGameObject
    {
        public void GiveToPlayer(PlayerInventory pInventory);
    }
}
