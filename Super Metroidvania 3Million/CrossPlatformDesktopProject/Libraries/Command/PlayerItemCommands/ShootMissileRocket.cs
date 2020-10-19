using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ShootMissileRocket : ICommand
    {
        private PlayerSprite samus;
        private IFactory factory;
        private float speed = 7;
        Game1 game;

        public ShootMissileRocket(Game1 game, PlayerSprite player) {
            this.game = game;
            samus = player;
            this.factory = game.Factory;
        }
        public void Execute()
        {
            if (samus.TotalRockets > 0) //If she got rockets
            {
                Vector2 direction = new Vector2(speed, 0);
                Vector2 location = new Vector2(samus.Location.X + 46, samus.Location.Y + 18);

                if (!samus.facingRight)
                {
                    direction = new Vector2(-speed, 0);
                    location = new Vector2(samus.Location.X + 12, samus.Location.Y + 18);
                }


                //if(samus.TotalRockets > 0)
                game.AddSprite(factory.CreateMissileRocket(location, direction));
                samus.TotalRockets--;
            }
        }
    }
}
