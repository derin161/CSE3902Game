using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public abstract class AbstractMenu : IMenuState
    {
        protected int ButtonIndex { get; set; } = 0;
        protected List<IMenuButton> ButtonList { get; private set; } = new List<IMenuButton>();

        public void Up()
        {
            ButtonIndex = (((ButtonIndex - 1) % ButtonList.Count) + ButtonList.Count) % ButtonList.Count; //Mod that works for negative numbers
        }

        public void Down()
        {
            ButtonIndex = (ButtonIndex + 1) % ButtonList.Count;
        }

        public void Left()
        {
            ButtonList[ButtonIndex].Left();
        }

        public void Right()
        {
            ButtonList[ButtonIndex].Right();
        }

        public void PressButton()
        {
            ButtonList[ButtonIndex].Press();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void ExitMenu();
    }
}
