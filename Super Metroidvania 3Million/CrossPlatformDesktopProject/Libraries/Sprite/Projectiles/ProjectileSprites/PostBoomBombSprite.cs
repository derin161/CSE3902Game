using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    class PostBoomBombSprite : ISprite
    {
        private Bomb bomb;
        private int time = 0;
        private Texture2D texture;

        public PostBoomBombSprite(Texture2D texture, Bomb b) {
            bomb = b;
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int msPerFrame = 50;
            int boomFrame = time / msPerFrame;

            //Boom Animation 1
            Rectangle srcRec = new Rectangle(18, 8, 16, 16);
            Rectangle destRec = new Rectangle((int)bomb.Location.X, (int)bomb.Location.Y, 16, 16);

            if (boomFrame / msPerFrame == 1) //Boom Animation 2
            {
                srcRec = new Rectangle(35, 8, 16, 16);
            }
            else if (boomFrame / msPerFrame == 2) //Boom Animation 3
            {
                srcRec = new Rectangle(52, 0, 32, 32);
                destRec = new Rectangle((int)bomb.Location.X, (int)bomb.Location.Y, 32, 32);
            }
            if (boomFrame < 3)
            {
                spriteBatch.Draw(texture, destRec, srcRec, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
