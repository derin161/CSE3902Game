using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMetroidvania5Million.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Memu : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;




        public Memu(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.MemuSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = EnemyUtilities.MemuHorizSpeed;
            vertSpeed = EnemyUtilities.MemuVertSpeed;
            health = EnemyUtilities.EnemyHealth;

        }

        private void Attack()
        {
            int playerX = GameObjectContainer.Instance.Player.SpaceRectangle().X;
            int playerY = GameObjectContainer.Instance.Player.SpaceRectangle().Y;

            //Move left-right toward player
            if (playerX < stateMachine.x)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }

            //Move up-down toward player
            if (playerY < stateMachine.y)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
        public void Update(GameTime gameTime)
        {
            Attack();
            stateMachine.Update();
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, EnemyUtilities.MemuWidth, EnemyUtilities.MemuHeight);
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
