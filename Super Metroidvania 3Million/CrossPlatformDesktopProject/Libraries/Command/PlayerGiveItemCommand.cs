using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class PlayerGiveItemCommand : ICommand
    {

        private IItem item;
        private IPlayer player;
        public PlayerGiveItemCommand(IItem item, IPlayer player) {
            this.item = item;
            this.player = player;
        }
        public void Execute()
        {
            player.Upgrade(item);
        }
    }
}
