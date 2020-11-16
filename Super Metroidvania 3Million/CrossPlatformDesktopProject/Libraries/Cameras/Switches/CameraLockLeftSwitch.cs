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
    class CameraLockLeftSwitch : Game1, ISwitch
    {
        public CameraLockLeftSwitch(int height, Vector2 pos)
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

        public void ActivateSwitch()
        {
            GetCamera().LockedLeft = true;
        }

        public void Update()
        {

        }
    }
}
