using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Kraid : IEnemy
    {

        private ISprite spriteRight, spriteLeft, currentSprite;
        private int msBetweenAttack = EnemyUtilities.KraidAttackDelay;
        private int msUntilAttack = EnemyUtilities.KraidAttackDelay;
        public Rectangle Space;
        private bool isDead, facingRight;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;
        public bool damaged;

        public Kraid(Vector2 location)
        {
            spriteRight = EnemySpriteFactory.Instance.KraidSprite(this);
            spriteLeft = EnemySpriteFactory.Instance.KraidSpriteLeft(this);
            currentSprite = spriteLeft;
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.KraidInitialHorizSpeed;
            vertSpeed = EnemyUtilities.KraidInitialVertSpeed;
            health = EnemyUtilities.EnemyHealth;
            damaged = false;
        }

        private void Attack()
        {
            //Move toward player
            Rectangle playerSpace = GameObjectContainer.Instance.Player.SpaceRectangle();
            if (playerSpace.X + EnemyUtilities.KraidDistanceBuffer < stateMachine.x)
            {
                MoveLeft();
            }
            else if (playerSpace.X -EnemyUtilities.KraidDistanceBuffer > stateMachine.x)
            {
                MoveRight();
            }
            else
            {
                //Face the direction of the player and move away
                if (playerSpace.X < stateMachine.x)
                {
                    currentSprite = spriteLeft;
                    facingRight = false;
                    MoveRight();
                }
                else if (playerSpace.X > stateMachine.x)
                {
                    facingRight = true;
                    currentSprite = spriteRight;
                    MoveLeft();
                }
            }
            //Perform attacks
            if (msUntilAttack < 0)
            {
                if (new Random().Next(0, 2) == 0)
                {
                    throwHorns();
                }
                else
                {
                    shootMissiles();
                }
                ChangeDirection();
                msUntilAttack = msBetweenAttack;
            }
        }
        public void Update(GameTime gameTime)
        {
            msUntilAttack -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            Attack();
            stateMachine.Update();
            currentSprite.Update(gameTime);
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.KraidWidth, EnemyUtilities.KraidHeight);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public Boolean IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
            //Initiate game over sequence
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
        private void throwHorns()
        {
            GameObjectContainer.Instance.Add(new KraidHorn(new Vector2(stateMachine.x, stateMachine.y), facingRight));
        }

        private void shootMissiles()
        {
            int speed = EnemyUtilities.KraidMissileSpeed;
            float missileStartX = stateMachine.x + EnemyUtilities.KraidMissileXOffset;
            float missileStartY = stateMachine.y + EnemyUtilities.KraidMissileYOffset;
            if (!facingRight)
            {
                speed *= -1;
            }
            GameObjectContainer.Instance.Add(new KraidMissile(new Vector2(missileStartX, missileStartY), new Vector2(speed, 0)));
        }

        public void Freeze()
        {
            //Do nothing, Kraid cannot be frozen
        }
        public int GetDamage()
        {
            return EnemyUtilities.KraidDamage;
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
