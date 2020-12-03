using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Camera.Switches
{
    class CameraFocusSwitch : ISwitch
    {
        private Game1 currentGame;
        string cameraType;
        bool transitionRight;
        public CameraFocusSwitch(int width, int height, Vector2 initialLocation, string cameraTypeInput, bool transitionRightInput)
        {
            Position = initialLocation;
            BoundingBox = new Rectangle((int)initialLocation.X, (int)initialLocation.Y, width, height);
            transitionRight = transitionRightInput;
            cameraType = cameraTypeInput;
        }

        public Rectangle BoundingBox { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 PositionOld { get; set; }

        public void ActivateSwitch()
        {
            Camera oldCamera = currentGame.GetCamera();
            if (oldCamera.Transitioning) return;
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
            currentGame.Camera = newCamera;
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
