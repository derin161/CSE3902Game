using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class LeftRightButtonSprite : ISprite
    {
        private LeftRightMenuButton lRButton;
        private String label;
        private SpriteFont defaultFont;
        private Vector2 defaultLabelDrawPos;
        private SpriteFont selectedFont;
        private Vector2 selectedLabelDrawPos;


        public LeftRightButtonSprite(LeftRightMenuButton lRMenuButton, String buttonLabel, SpriteFont defaultSpriteFont, SpriteFont selectedSpriteFont) {
            lRButton = lRMenuButton;
            label = buttonLabel;

            defaultFont = defaultSpriteFont;
            float xPos = lRButton.Space.Center.X - defaultFont.MeasureString(label).X / 2;
            float yPos = lRButton.Space.Center.Y - defaultFont.MeasureString(label).Y / 2 - 20;
            defaultLabelDrawPos = new Vector2(xPos, yPos);

            selectedFont = selectedSpriteFont;
            xPos = lRButton.Space.Center.X - selectedFont.MeasureString(label).X / 2;
            yPos = lRButton.Space.Center.Y - selectedFont.MeasureString(label).Y / 2 - 20;
            selectedLabelDrawPos = new Vector2(xPos, yPos);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.Blue;
            SpriteFont font = defaultFont;
            Vector2 pos = defaultLabelDrawPos;

            String activeLRText = lRButton.LRTextList[lRButton.LRTextIndex];

            float xPos = lRButton.Space.Center.X - defaultFont.MeasureString(activeLRText).X / 2;
            float yPos = lRButton.Space.Center.Y - defaultFont.MeasureString(activeLRText).Y / 2;
            Vector2 activeLRTextPos = new Vector2(xPos, yPos);

            

            if (lRButton.IsSelected) //Draw illuminated
            {
                color = Color.White;
                font = selectedFont;
                pos = selectedLabelDrawPos;

                xPos = lRButton.Space.Center.X - selectedFont.MeasureString(activeLRText).X / 2;
                yPos = lRButton.Space.Center.Y - selectedFont.MeasureString(activeLRText).Y / 2;
                activeLRTextPos = new Vector2(xPos, yPos);
            }

            spriteBatch.DrawString(font, label, pos, color); //Button Label

            Vector2 leftArrowPos = new Vector2(xPos - 10, yPos);
            if (lRButton.LRTextIndex == 0)
            {
                spriteBatch.DrawString(font, "<", leftArrowPos, Color.Gray);
            }
            else {
                spriteBatch.DrawString(font, "<", leftArrowPos, color);
            }

            spriteBatch.DrawString(font, activeLRText, activeLRTextPos, color); //Button Label

            Vector2 rightArrowPos = new Vector2(xPos + selectedFont.MeasureString(activeLRText).X + 10, yPos);
            if (lRButton.LRTextIndex == lRButton.LRTextList.Count - 1)
            {
                spriteBatch.DrawString(font, ">", rightArrowPos, Color.Gray);
            }
            else
            {
                spriteBatch.DrawString(font, ">", rightArrowPos, color);
            }
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do
        }
    }
}
