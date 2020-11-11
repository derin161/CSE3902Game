using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Camera
{
    public interface ICamera
    {
        Viewport Viewport { get; set; }
        Vector2 Position { get; set; }
        float Zoom { get; set; }
        Vector2 Origin { get; set; }
    }
}
