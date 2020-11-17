using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
	//Author: Nyigel Spann
	public class EnergyTankSprite : ISprite
	{
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }
		private Rectangle sourceRectangle;
		private Rectangle destRectangle;

		public EnergyTankSprite(Texture2D text, Vector2 pos, Rectangle srcRec)
		{
			Texture = text;
			Position = pos;
			sourceRectangle = srcRec;
			destRectangle = new Rectangle((int)pos.X, (int)pos.Y, 16, 16);
		}

		public void Update(GameTime gameTime)
		{
			//Nothing needs to be updated
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, destRectangle, sourceRectangle, Color.White);

		}
	}
}
