using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Skree : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        public bool fallen;
        private EnemyStateMachine stateMachine;
        private int health, vertSpeed, horizSpeed;
        private float x, y;



        public Skree(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.SkreeSprite(this);
            stateMachine = new EnemyStateMachine(location);
            health = 100;
            x = location.X;
            y = location.Y;
            fallen = false;
            vertSpeed = 0;
            horizSpeed = 0;

        }

        private void Attack()
        {
            int playerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            if (playerX < x + 40 && playerX > x - 40 && (stateMachine.vertSpeed > 0 || !fallen))
            {
                fallen = true;
                vertSpeed = 4;
                horizSpeed = 1;
                MoveDown();

                if (playerX < x)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }


            }
        }
        public void Update(GameTime gameTime)
        {

            Attack();
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, 32, 56);
            sprite.Update(gameTime);
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public Boolean IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }

        public void MoveLeft()
        {
            stateMachine.MoveLeft(horizSpeed);
        }
        public void MoveRight()
        {
            stateMachine.MoveRight(horizSpeed);
        }
        public void MoveUp()
        {
            stateMachine.MoveUp(vertSpeed);
        }
        public void MoveDown()
        {
            stateMachine.MoveDown(vertSpeed);
        }
        public void StopMoving()
        {
            stateMachine.StopMoving();
        }
        public void ChangeDirection()
        {
            stateMachine.changeDirection();
        }
        public void Freeze()
        {
            stateMachine.Freeze();
        }
        public int GetDamage()
        {
            return 25;
        }
        public void TakeDamage(int damage)
        {
            health = health - damage;
            if (health <= 0)
            {
                this.Kill();
            }
        }
    }
}
