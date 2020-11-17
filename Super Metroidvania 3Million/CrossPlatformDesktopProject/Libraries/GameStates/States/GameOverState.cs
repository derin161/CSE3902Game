using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameWinState : IGameState
    {
        private SpriteFont healthFont = content.Load<SpriteFont>("PlayerHealth");
        private SpriteFont GameOver = PlayerSpriteFactory.Instance.HealthFont();
        public void Update()
        {
            //Do nothing since screen will transition to blank with words game over
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
