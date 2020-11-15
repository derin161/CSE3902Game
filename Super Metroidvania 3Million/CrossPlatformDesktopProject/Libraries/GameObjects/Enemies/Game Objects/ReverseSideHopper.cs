using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ReverseSideHopper : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;
        private float initialY;
        public bool damaged;
        public bool frozen;

        public ReverseSideHopper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ReverseSideHopperSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.sidehopperInitialHorizSpeed;
            vertSpeed = EnemyUtilities.sidehopperInitialVertSpeed;
            health = EnemyUtilities.enemyHealth;
            initialY = location.Y;
            damaged = false;
            frozen = false;
        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.sidehopperWidth, EnemyUtilities.sidehopperHeight);
            sprite.Update(gameTime);
        }
        public void Jump(float count, int direction)
        {
            float a = EnemyUtilities.sidehopperJumpA;
            float b = EnemyUtilities.sidehopperJumpB;
            float c = EnemyUtilities.sidehopperJumpC;

            stateMachine.y = - a * (count*count) + b * count + initialY - c;
            stateMachine.x += direction;
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
        public void ChangeDirection()
        {
            stateMachine.changeDirection();
        }
        public void Freeze()
        {
            frozen = true;
            stateMachine.Freeze();
        }
        public void StopMoving()
        {
            stateMachine.StopMoving();
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
