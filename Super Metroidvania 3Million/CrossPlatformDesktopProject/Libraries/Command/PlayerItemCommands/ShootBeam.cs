using CrossPlatformDesktopProject.Command;
using CrossPlatformDesktopProject.Sprite.Player_Sprites;
using CrossPlatformDesktopProject.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerItemCommands
{
    //Author: Nyigel Spann
    class ShootBeam : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        public ShootBeam(PlayerSprite player, IFactory factory) {
            samus = player;
            this.factory = factory;
        }
        public void Execute()
        {
            if (samus.wave)
            {
                factory.CreateWaveBeam();
            }
            else { 
            
            }
        }
    }
}
