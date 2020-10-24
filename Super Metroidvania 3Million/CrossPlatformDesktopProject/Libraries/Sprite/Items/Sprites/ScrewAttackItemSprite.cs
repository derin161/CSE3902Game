using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class ScrewAttackItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private ScrewAttackItem screwAttack;

        public ScrewAttackItemSprite(Texture2D texture, ScrewAttackItem s)
        {
            Texture = texture;
            screwAttack = s;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, screwAttack.Space, Color.White);
    }

        public bool IsDead()
        {
            return false;
        }
    }
}
