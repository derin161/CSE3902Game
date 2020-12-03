using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.Camera
{
    //Author: Tristan Roman
    internal class HorizontalCamera : Camera
    {
        public HorizontalCamera(Viewport viewport) : base(viewport)
        {
        }

        override
        public void Update(GameTime gameTime)
        {
            while (Focus.SpaceRectangle().X <= CameraCenter.X && !LockedLeft)
                Transform(-Vector2.UnitX);
            while (Focus.SpaceRectangle().X >= CameraCenter.X && !LockedRight)
                Transform(Vector2.UnitX);
            base.Update(gameTime);
        }
    }
}
