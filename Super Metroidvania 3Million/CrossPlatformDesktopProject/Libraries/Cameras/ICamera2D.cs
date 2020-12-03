using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Cameras
{
    //Author: Tristan Roman
    public interface ICamera2D
    {
        /// <summary>
        /// Gets or sets the position of the camera
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the move speed of the camera.
        /// The camera will tween to its destination.
        /// </summary>
        float MoveSpeed { get; set; }

        /// <summary>
        /// Gets or sets the rotation of the camera.
        /// </summary>
        float Rotation { get; set; }

        /// <summary>
        /// Gets the origin of the viewport (accounts for Scale)
        /// </summary>        
        Vector2 Origin { get; }

        /// <summary>
        /// Gets or sets the scale of the Camera
        /// </summary>
        float Scale { get; set; }

        /// <summary>
        /// Gets the screen center (does not account for Scale)
        /// </summary>
        Vector2 ScreenCenter { get; }

        /// <summary>
        /// Gets the transform that can be applied to 
        /// the SpriteBatch Class.
        /// </summary>
        Matrix Transform { get; }

        /// <summary>
        /// Gets or sets the focus of the Camera.
        /// </summary>
        IFocusable Focus { get; set; }

        /// <summary>
        /// Determines whether the target is in view given the specified position.
        /// This can be used to increase performance by not drawing objects
        /// directly in the viewport
        /// </summary>
        bool IsInView(Vector2 position, Texture2D texture);
    }
}
