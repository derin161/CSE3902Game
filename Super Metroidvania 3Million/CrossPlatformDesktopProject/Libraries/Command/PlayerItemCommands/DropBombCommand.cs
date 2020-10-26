using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class DropBombCommand : ICommand
    {
        private Player samus;
        Game1 game;

        public DropBombCommand(Game1 game, Player player) {
            this.game = game;
            samus = player;
        }
        public void Execute()
        {
            Vector2 location = new Vector2(samus.Location.X + 30, samus.Location.Y + 50);

            game.AddSprite(ProjectilesGOFactory.Instance.CreateBomb(location));

        }
    }
}
