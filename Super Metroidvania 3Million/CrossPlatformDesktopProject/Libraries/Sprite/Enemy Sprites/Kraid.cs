using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Kraid : IEnemy
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y;
        private int counter;
        private int msBetweenAttack = 500;
        private int msUntilAttack = 500;
        private Game1 game;
        private bool isMovingRight = false;

        public Kraid(Texture2D texture, Vector2 location, Game1 game)
        {
            Texture = texture;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            y = location.Y;
            counter = 0;
            this.game = game;
            
        }

        public void Update(GameTime gameTime)
        {
            //Wait between attacks
            msUntilAttack -= (int) gameTime.ElapsedGameTime.TotalMilliseconds;

            //Perform attacks
            if (msUntilAttack < 0) {
                if (new Random().Next(0, 2) == 0)
                {
                    throwHorns();
                }
                else {
                    shootMissiles();
                }
                msUntilAttack = msBetweenAttack;
            }

            //change the frame after 10 counts
            if (counter == 10)
            {
                counter = 0;
                currentFrame++;
                if (currentFrame == 2)
                    currentFrame = 0;
            }
            counter++;
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width*2, height*2);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Boolean IsDead()
        {
            return false;
        }

        private void throwHorns() {
            game.AddSprite(game.Factory.CreateKraidHorn(new Vector2(x,y), !isMovingRight));
        }

        private void shootMissiles() {
            int speed = 7;
            game.AddSprite(game.Factory.CreateKraidMissile(new Vector2(x+23, y+38), new Vector2(speed,0)));
        }

    }
}
