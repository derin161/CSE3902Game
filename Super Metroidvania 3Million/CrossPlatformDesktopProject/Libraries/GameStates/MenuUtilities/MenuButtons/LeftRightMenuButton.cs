using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class LeftRightMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;
        public int LRTextIndex { get; private set; } = 0;
        public List<String> LRTextList { get; private set; }

        private ISprite sprite;
        private ICommand leftCommand;
        private ICommand rightCommand;

        public LeftRightMenuButton(String buttonLabel, Rectangle space, ICommand leftCommand, ICommand rightCommand, List<String> leftRightTexts)
        {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateLeftRightButtonSprite(this, buttonLabel);
            LRTextList = leftRightTexts;
            this.leftCommand = leftCommand;
            this.rightCommand = rightCommand;
        }

        public LeftRightMenuButton(String buttonLabel, Rectangle space, ICommand leftCommand, ICommand rightCommand, List<String> leftRightTexts, int textStartingIndex)
        {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateLeftRightButtonSprite(this, buttonLabel);
            LRTextList = leftRightTexts;
            this.leftCommand = leftCommand;
            this.rightCommand = rightCommand;

            LRTextIndex = textStartingIndex;
        }

        public void Left()
        {

            LRTextIndex--;
            if (LRTextIndex < 0)
            {
                LRTextIndex = 0;
            }
            else //Don't execute any command since we're at the end.
            {
                leftCommand.Execute();
            }
        }

        public void Press()
        {
            //Do nothing.
        }

        public void Right()
        {
            LRTextIndex++;
            if (LRTextIndex >= LRTextList.Count)//Don't execute any command since we're at the end.
            {
                LRTextIndex = LRTextList.Count - 1;
            }
            else
            {
                rightCommand.Execute();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
