using CrossPlatformDesktopProject.Libraries.Collision;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author: Will Floyd
    public class PlayingState : IGameState
    {
        public void Update(GameTime gameTime)
        {
            GameObjectContainer.Instance.Update(gameTime);
            CollisionDetector.Instance.Update();
        }

    }
}
