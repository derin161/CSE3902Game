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
    class PlayerSprite : ISprite
    {

        private int index;
        private int length;
        private int state; //determines the action state the player is in (i.e. jumping, crouching, etc) and will default to standing when certain parameters are met
        public Texture2D[] Texture;

        public PlayerSprite(Texture2D[] texture)
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
            //Player sprite changes based on user actions
            
            //Keyboard/mouse controller necessary*****

            switch (state)
            {
                case 1:     //Attack
                    
                    break;
                case 2:     //Special
                    
                    break;
                case 3:     //Jump
                    
                    break;
                case 4:     //Crouch
                    
                    break;
                case 5:     //RunRight
                    
                    break;
                case 6:     //RunLeft
                    
                    break;
                default:
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture[index].Width;
            int height = Texture[index].Height;

            Rectangle sourceRectangle = new Rectangle(width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(0, 0, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture[index], destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

    }
}
