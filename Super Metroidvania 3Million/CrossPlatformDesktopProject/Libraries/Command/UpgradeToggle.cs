using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
