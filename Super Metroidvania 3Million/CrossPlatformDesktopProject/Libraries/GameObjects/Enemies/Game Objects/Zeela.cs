using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CrossPlatformDesktopProject.Libraries.Container;


namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Zeela : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead, movingRight;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;
        private float initialX, initialY;
        public bool damaged, frozen;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;



        public Zeela(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ZeelaSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.ZeelaHorizSpeed;
            vertSpeed = EnemyUtilities.ZeelaVertSpeed;
            health = EnemyUtilities.EnemyHealth;
            initialX = location.X;
            initialY = location.Y;
            movingRight = false;
            damaged = false;
            frozen = false;
            

        }
        private void Attack()
        {
            //Should move around the blocks CounterClockwise, temporarily making it move back and forth
            
            //Move left until it gets 2 blocks away
            if (initialX - stateMachine.x < EnemyUtilities.ZeelaHorizDistance && !movingRight)
            {
                MoveLeft();
            }
            else if (initialX - stateMachine.x > 0)
            {
                movingRight = true;
                MoveRight();
            }
            else
            {
                movingRight = false;
            }
            
        }
        public void Update(GameTime gameTime)
        {
            Attack();
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.ZeelaWidth, EnemyUtilities.ZeelaHeight);
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
            return EnemyUtilities.EnemyDamage;
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
