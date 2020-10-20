using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class KraidSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialX;
        private int counter;
        private Game1 Game;
        public KraidSprite(Texture2D texture, Vector2 location, Game1 game)
        {
            Texture = texture;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            initialX = location.X;
            y = location.Y;
            counter = 0;
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts
            if (counter == 10)
            {
                counter = 0;
                currentFrame++;
                if (currentFrame == 2)
                    currentFrame = 0;
            }
            counter++;

            //Fly horizontally across the screen and reset to initial position
            x -= 3;
            if (initialX - x > 300)
            {
                x = initialX;
            }
            

            
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

        private void throwHorns()
        {
            Game.AddSprite(Game.Factory.CreateKraidHorn(new Vector2(x, y), false));
        }

        private void shootMissiles()
        {
            int speed = 7;
            Game.AddSprite(Game.Factory.CreateKraidMissile(new Vector2(x + 23, y + 38), new Vector2(speed, 0)));
        }
    }
}
