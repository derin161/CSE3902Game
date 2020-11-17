using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.Container;
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
            GameObjectContainer.Instance.Draw(spriteBatch);
        }

    }
}
