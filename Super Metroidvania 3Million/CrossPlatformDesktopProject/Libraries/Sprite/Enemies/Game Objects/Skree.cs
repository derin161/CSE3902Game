using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Skree : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        public bool fallen, collision;
        private EnemyStateMachine stateMachine;
        private int health, vertSpeed, horizSpeed, maxAccel, timer;
        private float x, y;
        public bool damaged, frozen;



        public Skree(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.SkreeSprite(this);
            stateMachine = new EnemyStateMachine(location);
            health = 100;
            x = location.X;
            y = location.Y;
            fallen = false;
            collision = false;
            vertSpeed = 0;
            horizSpeed = 0;
            maxAccel = 8;
            timer = 0;
            damaged = false;
            frozen = false;

        }

        private void Attack()
        {
            //Move Skree down if player walks within certain x distance
            int playerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            if (playerX < x + 30 && playerX > x - 30 && (stateMachine.vertSpeed > 0 || !fallen))
            {
                fallen = true;

                //Move skree vertically
                if (vertSpeed < maxAccel)
                {
                    vertSpeed = vertSpeed + 1;
                }
                MoveDown();

                //Move skree horizontally
                horizSpeed = 1;
                if (playerX < x)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }


            }

            //Set a timer to kill the sprite if it has fallen
            if (stateMachine.vertSpeed == 0 && fallen)
            {
                collision = true;
                if (timer > 1500)
                {
                    Kill();
                }
            }

        }
        public void Update(GameTime gameTime)
        {

            Attack();
            if (collision)
            {
                timer += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, 32, 48);
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
            stateMachine.Kill();
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
            frozen = true;
            stateMachine.Freeze();
        }
        public int GetDamage()
        {
            return EnemyUtilities.enemyDamage;
        }
        public void TakeDamage(int damage)
        {
            health = health - damage;
            damaged = true;
            if (health <= 0)
            {
                this.Kill();
            }
        }
    }
}
