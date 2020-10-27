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
	public class JumpLeftSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		public float xChange;
		private int rows;
		private int columns;
		private Samus samus;
		public int currentFrame { get; set; }
		private int totalFrames;
		private float yChange;
		private int interval;
		private int timer;
		public float origY { get; set; }

		public JumpLeftSamusSprite(Texture2D text, Samus sus, bool left, int frame, float y)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 1;
			currentFrame = frame;
			totalFrames = 5;
			yChange = 10f;
			xChange = 0f;
			if (left)
            {
				xChange = 10.0f;
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
			timer += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
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
				samus.space = new Rectangle((int)samus.x, (int)samus.y, 64, 64);
				timer -= (int) gameTime.ElapsedGameTime.TotalMilliseconds;
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
