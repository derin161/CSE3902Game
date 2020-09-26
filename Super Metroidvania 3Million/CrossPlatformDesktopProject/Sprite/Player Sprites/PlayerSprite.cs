using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Sprite.Player_Sprites
{
    class PlayerSprite : PlayerInterface
    {
        private int state;
        private int x;
        private int y;


        public Texture2D Texture;

        public PlayerSprite(Texture2D texture)
        {
            x = 0;
            y = 0;
            Texture = texture;
        }

        public void UpdateState(int keyboardstate) 
        {
            state = keyboardstate;
        }

        public void Update(GameTime gameTime)
        {
            //User actions based on switch case of states that change when a new action is selected
            switch(state){
                case 1: // Attack
                    Attack();
                    break;
                case 2: // Item1
                    Item1();
                    break;
                case 3: // Item2
                    Item2();
                    break;
                case 4: // Item3
                    Item3();
                    break;
                case 5: // Move Right
                    MoveRight();
                    break;
                case 6: // Move Left
                    MoveLeft();
                    break;
                case 7: // Jump
                    Jump();
                    break;
                case 8: // Crouch
                    Crouch();
                    break;
                default: // Idle

                    break;
            }


            }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(0, 0, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Attack() 
        {

            state = 0;  // Resets back to Idle when the function completes
        }

        public void Item1()
        {

            state = 0;
        }

        public void Item2()
        {

            state = 0;
        }
        public void Item3()
        {

            state = 0;
        }

        public void MoveLeft()
        {
            x -= 2;
            if (x < -16) x = 816; // Run to opposite side of the screen ***change to global variables***

            state = 0;
        }

        public void MoveRight()
        {
            x += 2;
            if(x > 816) x = -16;

            state = 0;
        }

        public void Crouch()
        {

            state = 0;
        }

        public void Jump()
        {

            state = 0;
        }
    }
    }
}
