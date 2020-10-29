using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Nyigel Spann
    public class EnemyStateMachine
    {

        public bool frozen;
        private int horizSpeed, vertSpeed;
        public float x, y;
        public EnemyStateMachine(Vector2 location)
        {
            x = location.X;
            y = location.Y;
            frozen = false;
        }
        public void MoveLeft(int speed)
        {
            horizSpeed = -speed;
        }
        public void MoveRight(int speed)
        {
            horizSpeed = speed;
        }
        public void MoveUp(int speed)
        {
            vertSpeed = -speed;
        }
        public void MoveDown(int speed)
        {
            vertSpeed = speed;
        }
        public void changeDirection()
        {
            //All enemies go only horizontal or vertical so changing both in one method should be fine
            horizSpeed = horizSpeed * -1;
            vertSpeed = vertSpeed * -1;
        }
        public void Freeze()
        {
            frozen = true;
        }
        public void Update()
        {
            if (!frozen)
            {
                x += horizSpeed;
                y += vertSpeed;
            }

        }
    }
}
