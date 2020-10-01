using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    interface IEnemy
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
