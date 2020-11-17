using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameOverState : IGameState
    {
        private void LoadTexture()
        {

        }

        public void Update(GameTime gameTime)
        {
            //Do nothing since screen will transition to blank with words game over
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch
        }
    }
}
