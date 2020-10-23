using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject
{
    public interface IGameObject
    {
        public bool IsDead();
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public Rectangle SpaceRectangle();
    }
}
