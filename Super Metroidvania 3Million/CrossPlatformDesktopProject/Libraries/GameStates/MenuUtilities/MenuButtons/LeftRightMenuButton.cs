using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class LeftRightMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;
        public int LRCommandIndex { get; private set; } = 0;
        public int LRTextIndex { get; private set; } = 0;
        public List<String> LRTextList { get; private set; }
        public List<ICommand> LRCommandList { get; private set; }

        private ISprite sprite;
        

        public LeftRightMenuButton(String buttonLabel, Rectangle space, ICommand leftCommand, ICommand rightCommand, List<String> leftRightTexts) {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateLeftRightButtonSprite(this, buttonLabel);
            LRTextList = leftRightTexts;
            LRCommandList = new List<ICommand>
            {
                leftCommand,
                rightCommand
            };
        }

        public void Left()
        {
            LRCommandIndex--;
            if (LRCommandIndex < 0) //Don't execute any command since we're at the start.
            {
                LRCommandIndex = 0;
            }
            else {
                LRCommandList[LRCommandIndex].Execute();
            }

            LRTextIndex--;
            if (LRTextIndex < 0)
            {
                LRTextIndex = 0;
            }
        }

        public void Press()
        {
            //Do nothing.
        }

        public void Right()
        {
            LRCommandIndex++;
            if (LRCommandIndex >= LRCommandList.Count) //Don't execute any command since we're at the end.
            {
                LRCommandIndex = LRCommandList.Count - 1;
            }
            else
            {
                LRCommandList[LRCommandIndex].Execute();
            }

            LRTextIndex++;
            if (LRTextIndex >= LRTextList.Count)
            {
                LRTextIndex = LRTextList.Count - 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
