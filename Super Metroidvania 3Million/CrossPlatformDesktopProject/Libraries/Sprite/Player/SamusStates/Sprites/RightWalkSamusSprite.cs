using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite;

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
		private int xChange;
		private int interval;
		private int timer;

		public RightWalkSamusSprite(Texture2D text, Samus sus)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 4;
			currentFrame = 0;
			totalFrames = 3;
			xChange = 8;
			interval = 100;
			timer = 0;

        }

		public void Update(GameTime gameTime)
        {
			timer += gameTime.ElapsedGameTime.TotalMilliseconds;
			if (timer > interval)
            {
				if (currentFrame == 3)
                {
					currentFrame = 0;
                }else
                {
					currentFrame++;
                }
				samus.x += xChange;
				samus.space = new Rectangle((int)x, (int)y, 64, 64);
				timer -= gameTime.ElapsedGameTime.TotalMilliseconds;
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
