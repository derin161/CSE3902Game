using SuperMetroidvania5Million.Libraries.Sprite.Items;
using SuperMetroidvania5Million.Libraries.Sprite.Player;

namespace SuperMetroidvania5Million.Libraries.Command
{
    public class PlayerGiveItemCommand : ICommand
    {

        private IItem item;
        private IPlayer player;
        public PlayerGiveItemCommand(IItem item, IPlayer player)
        {
            this.item = item;
            this.player = player;
        }
        public void Execute()
        {
            player.Upgrade(item);
        }
    }
}
