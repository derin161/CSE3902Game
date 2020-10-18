using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject
{
    public interface ISprite
    {
        public bool IsDead();
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}
