using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    /*Author: Shyamal Shah*/
    public class MorphAnimationSamusSprite : IPlayerSprite
    {
        public Color Color { get; set; }
        public Texture2D texture { get; set; }
        private MorphSamusState state;
        private int rows;
        private int columns;
        private Samus samus;
        private int currentFrameRight;
        private int currentFrameLeft;
        private int totalFrames;
        private bool facingRight;
        private int interval;
        private int timer;

        public MorphAnimationSamusSprite(Texture2D text, Samus sus, bool facingRight, MorphSamusState currentState)
        {
            texture = text;
            samus = sus;
            rows = 1;
            columns = 3;
            this.facingRight = facingRight;
            timer = 0;
            currentFrameRight = 1;
            currentFrameLeft = 1;
            totalFrames = 3;
            interval = 50;
            state = currentState;
            Color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                if (facingRight && currentFrameRight++ >= 2)
                {
                    currentFrameRight = 2;
                    state.setDoneMorph();
                }
                else if (!facingRight && currentFrameLeft-- <= 0)
                {
                    currentFrameLeft = 0;
                    state.setDoneMorph();
                }
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = 0;
            int column = 0;
            if (facingRight)
            {
                column = currentFrameRight * width;
            }
            else
            {
                column = currentFrameLeft * width;
            }

            Rectangle sourceRectangle = new Rectangle(column, row, width, height);
            samus.space = new Rectangle(samus.space.X, samus.space.Y, width, height);
            spriteBatch.Draw(texture, samus.space, sourceRectangle, Color);
            samus.space = new Rectangle(samus.space.X, samus.space.Y, 64, 64);
        }

        public bool animationDone()
        {
            bool done = false;
            if (facingRight && currentFrameRight == 2)
            {
                done = true;
            }
            else if (!facingRight && currentFrameLeft == 0)
            {
                done = true;
            }
            return done;
        }
    }
}
