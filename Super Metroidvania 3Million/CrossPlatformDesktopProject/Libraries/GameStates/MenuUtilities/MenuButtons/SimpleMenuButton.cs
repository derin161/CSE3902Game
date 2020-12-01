using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SimpleMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;

        private ISprite sprite;
        private ICommand pressCommand;

        public SimpleMenuButton(String buttonText, Rectangle space, ICommand pressCommand)
        {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            this.pressCommand = pressCommand;
        }

        public SimpleMenuButton(String buttonText, Vector2 point, ICommand pressCommand)
        {
            Space = new Rectangle(point.ToPoint(), MenuSpriteFactory.Instance.LargeDefaultFont.MeasureString(buttonText).ToPoint());
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            this.pressCommand = pressCommand;
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            pressCommand.Execute();
        }

        public void Right()
        {
            //Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
