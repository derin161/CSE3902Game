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
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	/*Author: Shyamal Shah*/
	public class MorphDoneAnimationSamusSprite : ISprite
	{
		public Texture2D texture { get; set; }
		private MorphSamusState state;
		private int rows;
		private int columns;
		private Samus samus;
		private int currentFrame;
		private int totalFrames;
		private bool moving;
		private bool movingRight;
		private bool movingLeft;
		private bool facingRight;
		private bool jumping;
		private int interval;
		private int timer;

		public MorphDoneAnimationSamusSprite(Texture2D text, Samus sus, bool facingRight)
        {
			texture = text;
			samus = sus;
			rows = 1;
			columns = 4;
			movingRight = false;
			movingLeft = false;
			jumping = false;
			this.facingRight = facingRight;
			timer = 0;
			currentFrame = 0;
			totalFrames = 3;
			interval = 50;

		}

		public void Update(GameTime gameTime)
        {
			timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
			if (timer > interval)
			{
				if (facingRight){
					currentFrame = (currentFrame + 1) % totalFrames;
					//setNonMoving();
				}else{
					if (--currentFrame == -1)
                    {
						currentFrame = 3;
                    }
					//setNonMoving();
				}
				timer = 0;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
        {
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = currentFrame * width;

			Rectangle sourceRectangle = new Rectangle(column, row, width, height);
			samus.space = new Rectangle(samus.space.X, samus.space.Y, width, height);
			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
			samus.space = new Rectangle(samus.space.X, samus.space.Y, 64, 64);
		}

		public void setDirection(bool facingRight)
        {
			this.facingRight = facingRight;
        }
	}
}
