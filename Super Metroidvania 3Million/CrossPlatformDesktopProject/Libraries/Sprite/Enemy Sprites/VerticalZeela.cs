﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    class VerticalZeela : IEnemy
    {
        //Author: Will Floyd
        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialY;
        private int count;
        private int direction;

        public VerticalZeela(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 2;
            Columns = 4;
            currentFrame = 2;
            totalFrames = Rows * Columns;
            x = location.X;
            initialY = location.Y;
            y = location.Y;
            count = 0;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            if (count == 10)
            {
                count = 0;
                currentFrame++;
                if (currentFrame == 4)
                {
                    currentFrame = 2;
                }
            }
            count++;

            y += direction;
            if (Math.Abs(y - initialY) > 100)
            {
                direction *= -1;
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
        
    }
}