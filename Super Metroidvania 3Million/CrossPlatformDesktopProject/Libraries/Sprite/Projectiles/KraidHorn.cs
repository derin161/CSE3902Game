using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidHorn : IProjectile
    {
        public Vector2 Location { get; set; }
        public int Damage { get; set; }

        private Texture2D texture;
        private bool isMovingRight;
        private int rows = 1;
        private int columns = 4;
        private int currentFrame = 0;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 50;
        private Vector2 initialLocation;


        public KraidHorn(Texture2D texture, Vector2 initialLocation, bool isMovingRight)
        {
            // Need to set actual damage values at some point
            Damage = 0;
            this.initialLocation = initialLocation;
            this.isMovingRight = isMovingRight;
            this.texture = texture;
            Location = initialLocation;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //Determine the single frame width and height and the row and position of the current frame.
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)((float) currentFrame / (float)columns);
            int column = currentFrame % columns;

            //Create source and destination and draw the sprite
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            Vector2 relativePos = Vector2.Subtract(Location, initialLocation);
            float x = (float) relativePos.X + 1;
            float y = (float)(0.2 * x * x - 10 * x); // 1/5x^2 - 10x. Gives projectile parabolic path to the right.
            

            
            if (!isMovingRight) {
                x = (float) relativePos.X - 1;
                y = (float)(0.2 * x * x + 10 * x); // 1/5x^2 + 10x. Gives projectile parabolic path to the right.
            }

            //Update position
            relativePos = new Vector2(x, y);
            Location = Vector2.Add(initialLocation, relativePos);

            //Only update the frames after each has been displayed for millisecondsPerFrame milliseconds.
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;

                //Advance the current frame and reset back to the first if at the final frame.
                currentFrame++;
                if (currentFrame == rows * columns)
                    currentFrame = 0;
            }

        }
    }
}
