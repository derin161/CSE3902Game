using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author: Will Floyd
    public class GameWinState : IGameState
    {

        public void Update(GameTime gameTime)
        {
            SoundManager.Instance.Songs.PlayDarudeSandstorm();
            SoundManager.Instance.Songs.Controls.Loop();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            SpriteFont font = MenuSpriteFactory.Instance.DefaultFont;
            spriteBatch.DrawString(font, "You Win!!!", new Vector2(100, 200), Color.White);
            spriteBatch.DrawString(font, "Press 'r' To Restart", new Vector2(75, 300), Color.White);
        }

    }
}
