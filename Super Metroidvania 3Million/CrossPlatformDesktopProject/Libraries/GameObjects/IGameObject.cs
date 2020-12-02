using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million
{
    public interface IGameObject
    {
        public void Kill();
        public bool IsDead();
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public Rectangle SpaceRectangle();
    }
}
