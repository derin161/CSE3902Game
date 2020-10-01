using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerItemCommands
{
    //Author: Nyigel Spann
    class DropBomb : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private float speed = 1;
        Game1 game;

        public DropBomb(Game1 game, PlayerSprite player, IFactory factory) {
            this.game = game;
            samus = player;
            this.factory = factory;
        }
        public void Execute()
        {
            Vector2 location = new Vector2(samus.Location.X, samus.Location.Y);

            //if(samus is in morph form)
            game.AddSprite(factory.CreateBomb(location));

        }
    }
}
