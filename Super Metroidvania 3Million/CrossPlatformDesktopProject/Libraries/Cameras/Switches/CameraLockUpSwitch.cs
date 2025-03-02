﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Camera.Switches
{
    public class CameraLockUpSwitch : ISwitch
    {
        public CameraLockUpSwitch(int height, Vector2 pos)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, 1, height);
            DoCollisions = true;
            NoOutwardCollisions = true;
        }

        public Rectangle BoundingBox { get; set; }

        public bool DoCollisions { get; set; }

        public bool NoOutwardCollisions { get; set; }

        public bool OnGround { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 PositionOld { get; set; }

        private Game1 currentGame;

        public void ActivateSwitch()
        {
            currentGame.GetCamera().LockedUp = true;
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

