using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class JumpLeftSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		public int xChange;
		private int rows;
		private int columns;
		private Samus samus;
		public int currentFrame { get; private set; }
		private int totalFrames;
		private int yChange;
		private int interval;
		private int timer;
		private int origY { get; private set; }

		public JumpLeftSamusSprite(Texture2D text, Samus sus, bool left, int frame, int y)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 1;
			currentFrame = frame;
			totalFrames = 5;
			yChange = 10;
			xChange = 0;
			if (left)
            {
				xChange = 10;
            }
			interval = 50;
			timer = 0;
			origY = y;
			if (currentFrame == 0)
            {
				samus.y += yChange;
				samus.x += xChange;
			}

        }

		public void Update(GameTime gameTime)
        {
			timer += gameTime.ElapsedGameTime.TotalMilliseconds;
			if (timer > interval)
            {
				if (currentFrame == 1 || currentFrame == 2)
                {
					samus.x -= xChange;
					samus.y += yChange;
                }else if (currentFrame == 3 || currentFrame == 4)
				{
					samus.x -= xChange;
					samus.y -= yChange;
				}
				else if (currentFrame == 5)
				{
					samus.x -= xChange;
					samus.y = origY;
					samus.state = new RightIdleSamusState(samus);
				}
				samus.space = new Rectangle((int)x, (int)y, 64, 64);
				timer -= gameTime.ElapsedGameTime.TotalMilliseconds;
			}

		}

		public void Draw(SpriteBatch spriteBatch)
        {
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = 0;

			Rectangle sourceRectangle = new Rectangle(column, row, width, height);

			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
			currentFrame++;
		}
	}
}
