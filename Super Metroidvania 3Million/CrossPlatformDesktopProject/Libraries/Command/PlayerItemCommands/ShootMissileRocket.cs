using CrossPlatformDesktopProject.Command;
using CrossPlatformDesktopProject.Sprite.Player_Sprites;
using CrossPlatformDesktopProject.SpriteFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerItemCommands
{
    //Author: Nyigel Spann
    class ShootMissileRocket : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private float speed = 1;

        public ShootMissileRocket(PlayerSprite player, IFactory factory) {
            samus = player;
            this.factory = factory;
        }
        public void Execute()
        {
            Vector2 direction = new Vector2(speed, 0);
            if (!samus.facingRight)
            {
                direction = new Vector2(-speed, 0);
            }
            Vector2 location = new Vector2(samus.Location.X, samus.Location.Y);
            
            
            
            
        }
    }
}
