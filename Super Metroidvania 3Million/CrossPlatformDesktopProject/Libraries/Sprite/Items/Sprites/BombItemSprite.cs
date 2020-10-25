using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class BombItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private BombItem bombItem;

        public BombItemSprite(Texture2D texture, BombItem b)
        {
            Texture = texture;
            bombItem = b;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, bombItem.Space, Color.White);
        }
        
        public bool IsDead()
        {
            return false;
        }
    }
}
