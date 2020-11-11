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
    class CameraFocusSwitch : Game1, ISwitch
    {
        string cameraType;
        bool transitionRight;
        public CameraFocusSwitch(int width, int height, Vector2 pos, string cameraTypeInput, bool transitionRightInput)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, width, height);
            //DoCollisions = true;
            //NoOutwardCollisions = true;
            transitionRight = transitionRightInput;
            cameraType = cameraTypeInput;
        }

        public Rectangle BoundingBox { get; set; }

        //public bool DoCollisions { get; set; }

        //public bool NoOutwardCollisions { get; set; }

        //public bool OnGround { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 PositionOld { get; set; }

        public void ActivateSwitch()
        {
            Camera oldCamera = GetCamera();
            //if (oldCamera.Transitioning) return;
            Camera newCamera;
            Vector2 newPosition;
            if (transitionRight)
                newPosition = new Vector2(oldCamera.CameraPosition.X + 320, oldCamera.CameraPosition.Y);
            else
                newPosition = new Vector2(oldCamera.CameraPosition.X - 320, oldCamera.CameraPosition.Y);



            if (cameraType.Equals("horizontal"))
                newCamera = new HorizontalCamera(oldCamera.Viewport);
            else if (cameraType.Equals("vertical"))
                newCamera = new VerticalCamera(oldCamera.Viewport);
            else
                newCamera = new HorizontalCamera(oldCamera.Viewport);
            newCamera.CameraPosition = oldCamera.CameraPosition;
            newCamera.Focus = oldCamera.Focus;
            newCamera.Zoom = oldCamera.Zoom;
            newCamera.LockedLeft = true;
            newCamera.LockedRight = true;
            newCamera.DoTransition(newPosition);
            SetCamera(newCamera);
        }

        public void Update() { }
    }
}
