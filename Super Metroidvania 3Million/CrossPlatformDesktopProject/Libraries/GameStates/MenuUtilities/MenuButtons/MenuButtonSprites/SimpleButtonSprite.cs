using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SimpleButtonSprite : ISprite
    {
        private IMenuButton button;
        private String text;
        private SpriteFont defaultFont;
        private Vector2 defaultDrawPos;
        private SpriteFont selectedFont;
        private Vector2 selectedDrawPos;


        public SimpleButtonSprite(IMenuButton menuButton, String buttonText, SpriteFont defaultSpriteFont, SpriteFont selectedSpriteFont)
        {
            button = menuButton;
            text = buttonText;

            defaultFont = defaultSpriteFont;
            float xPos = button.Space.Center.X - defaultFont.MeasureString(text).X / 2;
            float yPos = button.Space.Center.Y - defaultFont.MeasureString(text).Y / 2;
            defaultDrawPos = new Vector2(xPos, yPos);

            selectedFont = selectedSpriteFont;
            xPos = button.Space.Center.X - selectedFont.MeasureString(text).X / 2;
            yPos = button.Space.Center.Y - selectedFont.MeasureString(text).Y / 2;
            selectedDrawPos = new Vector2(xPos, yPos);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (button.IsSelected) //Draw illuminated
            {
                spriteBatch.DrawString(selectedFont, text, selectedDrawPos, Color.White);
            }
            else
            { //Button is not selected
                spriteBatch.DrawString(defaultFont, text, defaultDrawPos, Color.Blue);
            }
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do
        }
    }
}
