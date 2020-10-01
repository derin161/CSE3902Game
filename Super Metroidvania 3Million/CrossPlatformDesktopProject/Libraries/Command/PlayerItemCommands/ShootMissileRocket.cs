using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ShootMissileRocket : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private float speed = 1;
        Game1 game;

        public ShootMissileRocket(Game1 game, PlayerSprite player, IFactory factory) {
            this.game = game;
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

            //if(samus.TotalRockets > 0)
            game.AddSprite(factory.CreateMissileRocket(location));

        }
    }
}
