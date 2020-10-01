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
    class ShootBeam : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private Game1 game;
        private float speed = 7;

        public ShootBeam(Game1 game, PlayerSprite player) {
            samus = player;
            this.game = game;
            this.factory = game.Factory;
        }
        public void Execute()
        {
            Vector2 direction = new Vector2(speed, 0);
            samus.currentState = PlayerSprite.State.Attack;
            samus.currentFrame = 0;
            if (!samus.facingRight)
            {
                direction = new Vector2(-speed, 0);
            }
            Vector2 location = new Vector2(samus.Location.X, samus.Location.Y);
            if (samus.wave)
            {
                game.AddSprite(factory.CreateWaveBeam(location, direction, samus.elong, samus.ice));
            }
            else if (samus.ice)
            {
                game.AddSprite(factory.CreateIceBeam(location, direction, samus.elong));
            }
            else { //Power beam
                game.AddSprite(factory.CreatePowerBeam(location, direction, samus.elong));
            } 
        }
    }
}
