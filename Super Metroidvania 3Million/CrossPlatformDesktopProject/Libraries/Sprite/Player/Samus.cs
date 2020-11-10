using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class Samus : IPlayer
    {
        public IPlayerState State;
        public PlayerInventory Inventory { get; set; }
        public int health;
        public Rectangle space { get; set; }
        public Rectangle PlayerHitBox {get; set; }
        private Game1 game;
        private bool isDead;
        public int missile;
        public GameTime gameTime;
        public PlayerPhysics Physics { get; private set; }
        public bool Jumping { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float missileSpeed {get; private set;}
        public Vector2 HealthPosition {get; private set;}
        private SpriteFont healthFont;
        private int spriteHeight = 64;
        private int rightIdleOffset = 13;
        private int rightIdleWidth = 40;

        public Samus(Vector2 l, Game1 g, GameTime g2)
		{
            gameTime = g2;
            game = g;
            health = 100;
            isDead = false;
            x = l.X;
            y = l.Y;
            space = new Rectangle((int) x, (int) y, 64, 64);
            PlayerHitBox = new Rectangle(space.X + rightIdleOffset, space.Y, rightIdleWidth, spriteHeight);
            missile = 0;
            Inventory = new PlayerInventory(30);
            Physics = new PlayerPhysics(this);
			State = new RightIdleSamusState(this);
            Jumping = false;
            HealthPosition = new Vector2(32.0f, 64.0f);
			healthFont = PlayerSpriteFactory.Instance.HealthFont();
        }

        public void Attack()
        {
            State.Attack();
        }
        public void CycleBeamMissile()
        {
            if (missile == 2)
            {
                missile = 0;
            }else
            {
                missile++;
            }
        }
        public void Jump()
        {
            State.Jump();
        }
        public void Morph()
        {
            State.Morph();
        }
        public void MoveRight()
        {
            State.MoveRight();
        }
        public void MoveLeft()
        {
            State.MoveLeft();
        }
        public void AimUp()
        {
            State.AimUp();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                isDead = true;
            }
        }
        public void Upgrade(IItem item)
        {
            item.GiveToPlayer(Inventory);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            Physics.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
			spriteBatch.DrawString(healthFont, Inventory.getHealth().ToString(), HealthPosition, Color.White);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Idle() { 
            State.Idle();
        }

        public void Kill()
        {
            isDead = true;
        }

        public Rectangle SpaceRectangle()
        {
            return space;
        }

        public void UpdateLocation(Vector2 l)
        {
            x = l.X;
            y = l.Y;
            space = new Rectangle((int)x, (int)y, 64, 64);
        }
    }
}
