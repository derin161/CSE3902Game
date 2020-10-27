using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Nyigel Spann
    public class EnemyStateMachine
    {

        public bool movingLeft, movingUp, frozen;
        public float x, y;
        public EnemyStateMachine(Vector2 location)
        {
            x = location.X;
            y = location.Y;
            movingLeft = true;
            movingUp = true;
            frozen = false;
        }
        public void MoveLeft()
        {
            movingLeft = true;
        }
        public void MoveRight()
        {
            movingLeft = false;
        }
        public void MoveUp()
        {
            movingUp = true;
        }
        public void MoveDown()
        {
            movingUp = false;
        }
        public void changeDirection()
        {
            //All enemies go only horizontal or vertical so changing both in one method should be fine
            movingLeft = !movingLeft;
            movingUp = !movingUp;
        }
        public void Freeze()
        {
            frozen = true;
        }
        public void Update(int horizSpeed, int vertSpeed)
        {
            if (!frozen)
            {
                if (movingLeft)
                {
                    x -= horizSpeed;
                }
                else
                {
                    x += horizSpeed;
                }

                if (movingUp)
                {
                    y -= vertSpeed;
                }
                else
                {
                    y += vertSpeed;
                }

            }

        }
    }
}
