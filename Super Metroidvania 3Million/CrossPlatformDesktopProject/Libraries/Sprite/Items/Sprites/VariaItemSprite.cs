using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class VariaItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private VariaItem variaItem;

        public VariaItemSprite(Texture2D texture, VariaItem v)
        {
            Texture = texture;
            variaItem = v;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, variaItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}
