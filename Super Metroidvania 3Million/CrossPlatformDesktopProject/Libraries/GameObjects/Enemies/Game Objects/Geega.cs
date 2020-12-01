using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
        public bool damaged, frozen;

        public Geega(Vector2 location)
        {
            spriteLeft = EnemySpriteFactory.Instance.GeegaSprite(this);
            spriteRight = EnemySpriteFactory.Instance.GeegaSpriteRight(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.GeegaInitialHorizSpeed;
            vertSpeed = EnemyUtilities.GeegaInitialVertSpeed;
            health = EnemyUtilities.EnemyHealth;
            x = location.X;
            y = location.Y;
            initialPlayerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            isRight = false;
            currentSprite = spriteLeft;
            respawnTimer = 0;
            damaged = false;
            frozen = false;


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
                vertSpeed = EnemyUtilities.GeegaAttackVertSpeed;
                horizSpeed = EnemyUtilities.GeegaAttackHorizSpeed;
                if (!isRight)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }

            if (stateMachine.x < EnemyUtilities.OffScreenLeft || stateMachine.x > EnemyUtilities.OffScreenRight)
            {
                Kill();
            }

        }
        public void Update(GameTime gameTime)
        {
            Attack();
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.GeegaWidth, EnemyUtilities.GeegaHeight);
            currentSprite.Update(gameTime);
            if (isDead)
            {
                respawnTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (respawnTimer > EnemyUtilities.GeegaRespawnDelay)
                {
                    respawnTimer = 0;
                    isDead = false;
                    vertSpeed = EnemyUtilities.GeegaInitialVertSpeed;
                }
            }
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
        public Rectangle BoundingBox()
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
            stateMachine.Kill();

            //set back to initial position
            horizSpeed = 0;
            vertSpeed = 0;
            stateMachine.frozen = false;
            frozen = false;
            MoveLeft();
            MoveUp();
            stateMachine.x = x;
            stateMachine.y = y;
            initialPlayerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            health = EnemyUtilities.EnemyHealth;

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
            frozen = true;
            stateMachine.Freeze();
        }
        public int GetDamage()
        {
            return EnemyUtilities.EnemyDamage;
        }
        public void TakeDamage(int damage)
        {
            health = health - damage;
            damaged = true;
            if (health <= 0)
            {
                Kill();
            }
        }
    }
}
