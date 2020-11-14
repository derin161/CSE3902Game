using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            while (Focus.SpaceRectangle().X <= CameraCenterPoint.X - DampingDistance && !LockedLeft)
                Transform(-Vector2.UnitX);
            while (Focus.SpaceRectangle().X >= CameraCenterPoint.X + DampingDistance && !LockedRight)
                Transform(Vector2.UnitX);
            base.Update();
        }
    }
}
