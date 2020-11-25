using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public interface IMenuButton
    {
        public Rectangle Space { get; }
        public void Press();
        public void Left();
        public void Right();
        public void Draw(SpriteBatch spriteBatch);
    }
}
