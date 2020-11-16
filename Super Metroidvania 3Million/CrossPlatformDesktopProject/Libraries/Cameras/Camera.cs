using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;


namespace CrossPlatformDesktopProject.Libraries.Camera
{
    public class Camera
    {
        private Vector2 focusVector = GameObjectContainer.Instance.PlayerPosition();
        private Vector2 currentPos;
        private Vector2 originalPos;
        private Vector2 destinationPos;
        private float lerpProgress;

        protected Camera(Viewport viewport)
        {
            Viewport = viewport;
            //DampingDistance = 64;
        }

        protected Vector2 CameraCenter => new Vector2(currentPos.X + focusVector.X + Viewport.Width / (Zoom * 2), currentPos.Y + focusVector.Y + Viewport.Height / (Zoom * 2));
       
        public bool LockedRight { get; set; }
        public bool LockedLeft { get; set; }
        public bool LockedUp { get; set; }
        public bool LockedDown { get; set; }

        public Viewport Viewport { get; set; }
        public bool Transitioning { get; set; }
        public float Zoom { get; set; }
        protected float DampingDistance { get; }   
        public IGameObject Focus { get; set; }

        public Vector2 CameraPosition
        {
            get
            {
                return currentPos;
            }

            set
            {
                currentPos = value;
            }
        }

        /*public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-CameraPosition, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Vector2.Zero, 0.0f)) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Vector2.Zero, 0.0f));
        }*/

        public virtual void Update()
        {
            if (Transitioning)
            {
                float lerpedX = MathHelper.Lerp(originalPos.X, destinationPos.X, lerpProgress);
                float lerpedY = MathHelper.Lerp(originalPos.Y, destinationPos.Y, lerpProgress);
                CameraPosition = new Vector2(lerpedX, lerpedY);
                lerpProgress += 0.025f;
            }
            if ((destinationPos - CameraPosition).Length() < 1)
            {
                Transitioning = false;
                if (destinationPos.X > originalPos.X)
                {
                    LockedRight = false;
                }
                else
                {
                    LockedLeft = false;
                }
            }
        }

        protected void Transform(Vector2 change)
        {
            if (LockedRight && change.X > 0)
                change.X = 0;
            if (LockedLeft && change.X < 0)
                change.X = 0;
            if (LockedUp && change.Y < 0)
                change.Y = 0;
            if (LockedDown && change.Y > 0)
                change.Y = 0;
            CameraPosition += change;
        }

        public bool IsRendered(IGameObject gameObject)
        {
            bool inFromLeft = gameObject.SpaceRectangle().Right > CameraPosition.X;
            bool inFromRight = gameObject.SpaceRectangle().Left < CameraPosition.X + Viewport.Width / Zoom;
            bool inFromTop = gameObject.SpaceRectangle().Bottom > CameraPosition.Y;
            bool inFromBottom = gameObject.SpaceRectangle().Top < CameraPosition.Y + Viewport.Height / Zoom;
            return inFromBottom && inFromTop && inFromLeft && inFromRight;
        }

        public bool IsRendered(IGameObject gameObject, int leniance)
        {
            bool inFromLeft = gameObject.SpaceRectangle().Right > CameraPosition.X - leniance;
            bool inFromRight = gameObject.SpaceRectangle().Left < CameraPosition.X + leniance + Viewport.Width / Zoom;
            bool inFromTop = gameObject.SpaceRectangle().Bottom > CameraPosition.Y - leniance;
            bool inFromBottom = gameObject.SpaceRectangle().Top < CameraPosition.Y + leniance + Viewport.Height / Zoom;
            return inFromBottom && inFromTop && inFromLeft && inFromRight;
        }
        
        public void DoTransition(Vector2 newPosition)
        {
            originalPos = CameraPosition;
            Transitioning = true;
            destinationPos = newPosition;
            lerpProgress = 0;
        }
    }
}
