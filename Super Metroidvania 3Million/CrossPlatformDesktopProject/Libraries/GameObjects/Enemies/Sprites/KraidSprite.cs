﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMetroidvania5Million.Libraries.Container;


namespace SuperMetroidvania5Million.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class KraidSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int counter;
        private Kraid Kraid;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;


        public KraidSprite(Texture2D texture, Kraid k)
        {
            Texture = texture;
            Rows = EnemyUtilities.KraidSpriteRows;
            Columns = EnemyUtilities.KraidSpriteColumns;
            currentFrame = 0;
            counter = 0;
            Kraid = k;

        }

        public void Update(GameTime gameTime)
        {

            //change the frame after 10 counts
            if (counter == EnemyUtilities.KraidSpriteFrameSpeed)
            {
                counter = 0;
                currentFrame++;
                if (currentFrame == EnemyUtilities.KraidSpriteFrameReset)
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

            if (Kraid.damaged)
            {
                spriteBatch.Draw(Texture, Kraid.Space, sourceRectangle, Color.Transparent);
                Kraid.damaged = false;
            }
            else
            {
                spriteBatch.Draw(Texture, Kraid.Space, sourceRectangle, Color.White);
            }
        }

        public Boolean IsDead()
        {
            return false;
        }



    }
}