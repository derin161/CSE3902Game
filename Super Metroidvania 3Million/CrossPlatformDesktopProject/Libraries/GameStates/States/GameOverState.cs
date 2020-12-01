using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Container
{
    public class GameOverState : IGameState
    {
        public void Update(GameTime gameTime)
        {
            //Do nothing since screen will transition to blank with words game over
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            //Draw gameover png    
        }
    }
}
