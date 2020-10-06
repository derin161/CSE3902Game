using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class SideHopper : IEnemy
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialY;
        private int count;
        private int direction;

        public SideHopper(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 2;
            Columns = 6;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            y = location.Y;
            initialY = location.Y;
            direction = 3;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 20 counts
            if (count == 20)
            {
                count = 0;
                direction *= -1;
                currentFrame++;
                if (currentFrame == 3)
                {
                    currentFrame = 0;
                }
            }

            //Jump while on frame 2
            if (currentFrame == 2)
            {
                y = (count * count) - 20 * count + initialY;
                x += direction;
            }
            count++;

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width * 2, height * 2);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public Boolean IsDead()
        {
            return false;
        }

        private void Jump()
        {

        }

    }
}
