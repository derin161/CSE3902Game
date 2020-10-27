using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Blocks
{
    class GreenFenceBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        ISprite sprite;
        private Vector2 initialLocation;
        private bool isDead = false;


        public GreenFenceBlock(Vector2 initialLocation, bool isMovingRight)
        {
            this.initialLocation = initialLocation;
            Location = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 32, 32);
            sprite = BlockSpriteFactory.Instance.CreateGreenFenceBlockSprite(this);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {

            //Update position and space
            Location = new Vector2(); //Until we implement the map and figure out how location is being updated
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);
            sprite.Update(gameTime);
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }
    }
}
