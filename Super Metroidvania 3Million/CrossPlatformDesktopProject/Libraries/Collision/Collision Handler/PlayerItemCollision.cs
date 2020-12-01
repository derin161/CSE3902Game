using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Command;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class PlayerItemCollision
    {
        public PlayerItemCollision()
        {

        }

        public void HandleCollision(IPlayer player, IItem item)
        {
            new PlayerGiveItemCommand(item, player).Execute();
            item.Kill();
        }

    }
}