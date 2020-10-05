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
    class DropBomb : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        Game1 game;

        public DropBomb(Game1 game, PlayerSprite player) {
            this.game = game;
            samus = player;
            this.factory = game.Factory;
        }
        public void Execute()
        {
            Vector2 location = new Vector2(samus.Location.X + 30, samus.Location.Y + 50);

            //if(samus is in morph form)
            game.AddSprite(factory.CreateBomb(location));

        }
    }
}
