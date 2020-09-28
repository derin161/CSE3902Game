using CrossPlatformDesktopProject.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    public class PowerBeam : IProjectile
    {
        public Texture2D Texture { get; set; }
        public Vector2 RelativePosition { get; set; }
        public Vector2 Direction { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        private int totalFrames;
        private int currentFrame = 0;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 50;

        public AnimatedMovingSprite(Texture2D texture);
        {
            Texture = texture;
            RelativePosition = new Vector2(0, 0);
            Direction = direction;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 initialLocation)
        {
            //Determine the single frame width and height and the row and position of the current frame.
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            //Create source and destination and draw the sprite
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(initialLocation.X + RelativePosition.X), (int)(initialLocation.Y + RelativePosition.Y), width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Only update the frames after each has been displayed for millisecondsPerFrame milliseconds.
            //Idea from https://stackoverflow.com/questions/15594691/xna-slow-down-animation
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;

                //Advance the current frame and reset back to the first if at the final frame.
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }

            //If the Sprite has moved too far from its original position reverse the direction.
            if (RelativePosition.Y > 100 || RelativePosition.Y < -100)
            {
                Direction = Vector2.Multiply(Direction, new Vector2(1, -1));
            }
            if (RelativePosition.X > 200 || RelativePosition.X < -200)
            {
                Direction = Vector2.Multiply(Direction, new Vector2(-1, 1));
            }
            RelativePosition = Vector2.Add(RelativePosition, Direction);
        }
    }
}
