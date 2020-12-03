using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.SFactory;
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
            SpriteFont font = MenuSpriteFactory.Instance.LargeDefaultFont;
            spriteBatch.DrawString(font, "You Lose!!!", new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(font, "Press 'r' To Restart", new Vector2(75, 300), Color.White);
        }
    }
}
