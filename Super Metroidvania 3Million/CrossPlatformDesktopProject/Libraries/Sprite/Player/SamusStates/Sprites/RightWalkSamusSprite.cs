using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Controller;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class RightWalkSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		private int rows;
		private int columns;
		private Samus samus;
		private int currentFrame;
		private int totalFrames;
		private float xChange;
		private int interval;
		private int timer;

		public RightWalkSamusSprite(Texture2D text, Samus sus)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 4;
			currentFrame = 1;
			totalFrames = 3;
			xChange = 8.0f;
			interval = 100;
			timer = 0;

        }

		public void Update(GameTime gameTime)
        {
			timer += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
			if (timer > interval)
            {
				currentFrame = (currentFrame + 1) % totalFrames;
				timer -= (int) gameTime.ElapsedGameTime.TotalMilliseconds;
			}

		}

		public void Draw(SpriteBatch spriteBatch)
        {
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = currentFrame * width;

			Rectangle sourceRectangle = new Rectangle(column, row, width, height);

			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
		}
	}
}
