using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public abstract class AbstractMenuState : IMenuState
    {
        protected int ButtonIndex { get; set; } = 0;
        protected List<IMenuButton> ButtonList { get; set; } = new List<IMenuButton>();

        public virtual void Up()
        {
            ButtonList[ButtonIndex].IsSelected = false;
            ButtonIndex = (((ButtonIndex - 1) % ButtonList.Count) + ButtonList.Count) % ButtonList.Count; //Mod that works for negative numbers
            ButtonList[ButtonIndex].IsSelected = true;
        }

        public virtual void Down()
        {
            ButtonList[ButtonIndex].IsSelected = false;
            ButtonIndex = (ButtonIndex + 1) % ButtonList.Count;
            ButtonList[ButtonIndex].IsSelected = true;
        }

        public virtual void Left()
        {
            ButtonList[ButtonIndex].Left();
        }

        public virtual void Right()
        {
            ButtonList[ButtonIndex].Right();
        }

        public virtual void PressButton()
        {
            ButtonList[ButtonIndex].Press();
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void ExitMenu();
    }
}
