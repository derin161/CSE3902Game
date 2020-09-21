using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class EnemySprite : ISprite
    {

        private int index;
        private int length;
        public Texture2D[] Texture;

        public EnemySprite(Texture2D[] texture)
        { 
            length = texture.Length;
            index = 0;
            for (int i = 0; i < length; i++)
            {
                Texture[i] = texture[i];
            }
        }

        public void Update(GameTime gameTime)
        {
            //Cycle through enemy sprites using o and p keys

            if (/*o key is pressed*/){      //Need to wait for keyboard and mouse controller classes
                //switch to previous sprite
                if (index == 0)
                {
                    index = length-1;
                }
                else
                {
                    index -= 1;
                }
            }
            if (/*p key is pressed*/){      //Need to wait for keyboard and mouse controller classes
                //switch to next sprite
                if (index == length-1)
                {
                    index = 0;
                }
                else
                {
                    index += 1;
                }
            }
                        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture[index].Width;
            int height = Texture[index].Height;

            Rectangle sourceRectangle = new Rectangle(width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(0,0, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture[index], destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

    }
}
