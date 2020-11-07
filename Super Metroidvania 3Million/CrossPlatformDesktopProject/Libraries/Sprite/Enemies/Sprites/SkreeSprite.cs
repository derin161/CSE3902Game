﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class SkreeSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int count;
        private Skree skree;

        public SkreeSprite(Texture2D texture, Skree s)
        {
            Texture = texture;
            Rows = 2;
            Columns = 3;
            currentFrame = 1;
            totalFrames = Rows * Columns;
            count = 0;
            skree = s;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts while skree is falling
            if (skree.fallen && !skree.collision && count == 4)
            {
                count = 0;
                currentFrame++;
                if (currentFrame == 3)
                {
                    currentFrame = 0;
                }
            }
            count = (count + 1) % 5;

            
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            if (skree.damaged)
            {
                spriteBatch.Draw(Texture, skree.Space, sourceRectangle, Color.Transparent);
                skree.damaged = false;
            }
            else
            {
                spriteBatch.Draw(Texture, skree.Space, sourceRectangle, Color.White);
            }
        }
        public Boolean IsDead()
        {
            return false;
        }

    }
}
