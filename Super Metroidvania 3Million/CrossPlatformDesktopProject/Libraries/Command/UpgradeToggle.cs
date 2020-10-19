using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class UpgradeToggle : ICommand
    {

        private PlayerSprite.UpgradeType type;
        private PlayerSprite samus;
        public UpgradeToggle(PlayerSprite.UpgradeType type, PlayerSprite samus) {
            this.type = type;
            this.samus = samus;
        }
        public void Execute()
        {
            samus.Upgrade(type);
        }
    }
}
