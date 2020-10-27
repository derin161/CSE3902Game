using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class Samus : IPlayer
    {
        public IPlayerState state;
        public PlayerInventory inventory;
        public int health;
        public Rectangle space;
        private Game1 game;
        public float x, y;
        private bool isDead;
        public int missile;
        public GameTime gameTime;

        public Samus(Vector2 l, Game1 g, GameTime g2)
		{
            gameTime = g2;
            game = g;
            x = l.X;
            y = l.Y;
			state = new RightIdleSamusState(this);
            health = 100;
            isDead = false;
            space = new Rectangle((int) x, (int) y, 64, 64);
            missile = 0;
            inventory = new PlayerInventory(30);
        }

        public void Attack()
        {
            state.Attack();
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
            state.Jump();
        }
        public void Morph()
        {
            state.Morph();
        }
        public void MoveRight()
        {
            state.MoveRight();
        }
        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void AimUp()
        {
            state.AimUp();
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
            inventory.GiveItem(item);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public Rectangle SpaceRectangle()
        {
            return space;
        }
    }
}
