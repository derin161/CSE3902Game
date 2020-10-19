using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class DropBomb : ICommand
    {
        private PlayerSprite samus;
        private SpriteFactory factory = SpriteFactory.Instance;
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
