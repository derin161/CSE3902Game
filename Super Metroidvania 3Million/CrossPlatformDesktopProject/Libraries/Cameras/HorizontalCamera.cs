using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Camera
{
    internal class HorizontalCamera : Camera
    {
        public HorizontalCamera(Viewport viewport) : base(viewport)
        {
        }

        override
        public void Update()
        {
            while (Focus.SpaceRectangle().X <= CameraCenter.X && !LockedLeft)
                Transform(-Vector2.UnitX);
            while (Focus.SpaceRectangle().X >= CameraCenter.X && !LockedRight)
                Transform(Vector2.UnitX);
            base.Update();
        }
    }
}
