using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CrossPlatformDesktopProject.Libraries.Container;


namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Ripper : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;



        public Ripper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.RipperSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.RipperHorizSpeed;
            vertSpeed = EnemyUtilities.RipperVertSpeed;
            health = EnemyUtilities.EnemyHealth;

        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.RipperWidth, EnemyUtilities.RipperHeight);
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
        public void ChangeDirection()
        {
            stateMachine.changeDirection();
        }
        public void Freeze()
        {
            stateMachine.Freeze();
        }
        public void StopMoving()
        {
            stateMachine.StopMoving();
        }
        public int GetDamage()
        {
            return EnemyUtilities.EnemyDamage;
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
