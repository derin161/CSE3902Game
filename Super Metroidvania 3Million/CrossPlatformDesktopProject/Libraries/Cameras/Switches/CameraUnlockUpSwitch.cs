using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.CSV;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Camera.Switches
{
    public class CameraUnlockUpSwitch : ISwitch
    {
        public CameraUnlockUpSwitch(int height, Vector2 pos)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, 1, height);
        }

        public Rectangle BoundingBox { get; set; }

        public Vector2 Position { get; set; }

        private Game1 currentGame;

        public void ActivateSwitch()
        {
            currentGame.GetCamera().LockedUp = false;
        }

        public void Kill() { }

        public bool IsDead()
        {
            return false;
        }
        public void Draw(SpriteBatch spriteBatch) { }

        public void Update(GameTime gameTime)
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, BoundingBox.Width, BoundingBox.Height);
        }

        public Rectangle SpaceRectangle()
        {
            return BoundingBox;
        }
    }
}

