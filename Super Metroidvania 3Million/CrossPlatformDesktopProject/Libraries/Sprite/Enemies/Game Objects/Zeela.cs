﻿using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Zeela : IEnemy
    {
        public Rectangle Space { get; set; }
        private ISprite sprite;
        private bool isDead;
        private EnemyStateMachine stateMachine;
        private int horizSpeed, vertSpeed;
        private int health;



        public Zeela(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ZeelaSprite(this);
            stateMachine = new EnemyStateMachine(location);
            horizSpeed = 3;
            vertSpeed = 0;
            health = 100;

        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update(horizSpeed, vertSpeed);
            Space = new Rectangle((int)stateMachine.x, (int)stateMachine.y, 32, 32);
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
            stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            stateMachine.MoveRight();
        }
        public void MoveUp()
        {
            stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            stateMachine.MoveDown();
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
