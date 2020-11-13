using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Nyigel Spann
    public class EnemyStateMachine
    {

        public bool frozen;
        public int horizSpeed, vertSpeed;
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
        public void StopMoving()
        {
            vertSpeed = 0;
            horizSpeed = 0;
        }
        public void Freeze()
        {
            frozen = true;
        }
        public void Kill()
        {
            //Drop an item where the enemy died
            if (new Random().Next(0, 2) == 0)
            {
                GameObjectContainer.Instance.Add(new RocketDropItem(new Vector2(x, y)));
            }
            else
            {
                GameObjectContainer.Instance.Add(new EnergyDropItem(new Vector2(x, y)));
            }
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
