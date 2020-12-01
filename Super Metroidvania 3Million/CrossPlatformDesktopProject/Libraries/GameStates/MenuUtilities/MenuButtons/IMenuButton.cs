using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Nyigel Spann
    public interface IMenuButton
    {
        public bool IsSelected { get; set; }
        public Rectangle Space { get; }
        public void Press();
        public void Left();
        public void Right();
        public void Draw(SpriteBatch spriteBatch);
    }
}
