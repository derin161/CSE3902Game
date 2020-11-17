using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Camera
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
