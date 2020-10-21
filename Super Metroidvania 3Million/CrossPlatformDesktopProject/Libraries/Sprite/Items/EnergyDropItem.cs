using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class EnergyDropItem : IItems
    {
        private Texture2D texture;
        private int xLoc = 0;
        private int yLoc = 0;
        private bool isDead = false;

        public EnergyDropItem(Texture2D texture, Vector2 initialLocation)
        {
            this.texture = texture;
            this.xLoc = (int)initialLocation.X;
            this.yLoc = (int)initialLocation.Y;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Vector2(this.xLoc, this.yLoc), Color.White);
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}
