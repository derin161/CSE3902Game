﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Container
{
    //Author: Will Floyd
    public interface IGameState
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
