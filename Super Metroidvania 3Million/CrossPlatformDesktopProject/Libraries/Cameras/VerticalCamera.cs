using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.Camera
{
    internal class VerticalCamera : Camera
    {
        public VerticalCamera(Viewport viewport) : base(viewport)
        {
        }

        override
        public void Update()
        {
            while (Focus.SpaceRectangle().Y <= CameraCenter.Y && !LockedUp)
                Transform(-Vector2.UnitY);
            while (Focus.SpaceRectangle().Y >= CameraCenter.Y && !LockedDown)
                Transform(Vector2.UnitY);
            base.Update();
        }
    }
}
