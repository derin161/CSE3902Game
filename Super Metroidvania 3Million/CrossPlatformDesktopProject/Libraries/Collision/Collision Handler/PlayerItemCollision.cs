using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.Items;
using SuperMetroidvania5Million.Libraries.Command;

namespace SuperMetroidvania5Million.Libraries.Collision
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