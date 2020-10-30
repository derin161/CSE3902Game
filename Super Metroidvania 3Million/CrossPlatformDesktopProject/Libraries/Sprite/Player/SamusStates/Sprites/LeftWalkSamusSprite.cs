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

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class LeftWalkSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		private int rows;
		private int columns;
		private Samus samus;
		private int currentFrame;
		private int totalFrames = 4;
		private int interval;
		private int timer;

		public LeftWalkSamusSprite(Texture2D text, Samus sus)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 4;
			currentFrame = 0;
			interval = 50;
			timer = 0;

        }

		public void Update(GameTime gameTime)
        {
			timer += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
			if (timer > interval)
            {
				currentFrame = (currentFrame + 1) % totalFrames;
				timer = 0;			
			}

		}

		public void Draw(SpriteBatch spriteBatch)
        {
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = (3 - currentFrame) * width;

			Rectangle sourceRectangle = new Rectangle(column, row, width, height);
			samus.space = new Rectangle(samus.space.X, samus.space.Y, width, height);
			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
		}
	}
}
