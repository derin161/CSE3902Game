using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class IdleSamusSprite : ISprite
    {
		public Texture2D texture { get; set; }
		private int rows;
		private int columns;
		private Samus samus;

		public IdleSamusSprite(Texture2D text, Samus sus)
		{
			texture = text;
			samus = sus;
			rows = 1;
			columns = 1;
		}

		public void Update(GameTime gameTime)
		{
			//Nothing needs to be updated
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			int width = texture.Width / columns;
			int height = texture.Height / rows;
			int row = 0;
			int column = 0;

			Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
			spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);

		}
	}
}
