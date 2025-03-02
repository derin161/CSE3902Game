﻿using SuperMetroidvania5Million.Libraries.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Container
{
    //Author: Will Floyd
    public class PlayingState : IGameState
    {
        public void Update(GameTime gameTime)
        {
            GameObjectContainer.Instance.Update(gameTime);
            CollisionDetector.Instance.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GameObjectContainer.Instance.Draw(spriteBatch);
        }
    }
}
