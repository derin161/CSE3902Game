using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Geega : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite spriteLeft, spriteRight, currentSprite;
        private bool isDead, isRight;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health, respawnTimer;
        private float x, y;
        private int initialPlayerX;

        public Geega(Vector2 location)
        {
            spriteLeft = EnemySpriteFactory.Instance.GeegaSprite(this);
            spriteRight = EnemySpriteFactory.Instance.GeegaSpriteRight(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = 0;
            vertSpeed = 4;
            health = 100;
            x = location.X;
            y = location.Y;
            initialPlayerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            isRight = false;
            currentSprite = spriteLeft;
            respawnTimer = 0;


        }
        private void Attack()
        {
            //Move Geega up until they reach the height of the player. Then move over
            int playerY = GameObjectContainer.Instance.Player.SpaceRectangle().Y;

            //Determine the direction of the sprite
            if (initialPlayerX < x)
            {
                currentSprite = spriteLeft;
                isRight = false;
            }
            else
            {
                currentSprite = spriteRight;
                isRight = true;
            }

            MoveUp();

            //Fly sideways when attacking the player
            if (stateMachine.y <= playerY)
            {
                vertSpeed = 0;
                horizSpeed = 3;
                if (!isRight)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }

            if (stateMachine.x < 0 || stateMachine.x > 800)
            {
                Kill();
            }
            
        }
        public void Update(GameTime gameTime)
        {
            Attack();
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, 32,32);
            currentSprite.Update(gameTime);
            if (isDead)
            {
                respawnTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (respawnTimer > 1000)
                {
                    respawnTimer = 0;
                    isDead = false;
                    vertSpeed = 4;
                }
            }
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch);
        }

        public Boolean IsDead()
        {
            return false; //Should never die because they always respawn
        }

        public void Kill()
        {
            isDead = true;

            //set back to initial position
            horizSpeed = 0;
            vertSpeed = 0;
            MoveLeft();
            MoveUp();
            stateMachine.x = x;
            stateMachine.y = y;
            initialPlayerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            health = 100;

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
        public void ChangeDirection()
        {
            stateMachine.changeDirection();
        }
        public void StopMoving()
        {
            stateMachine.StopMoving();
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
                Kill();
            }
        }
    }
}
