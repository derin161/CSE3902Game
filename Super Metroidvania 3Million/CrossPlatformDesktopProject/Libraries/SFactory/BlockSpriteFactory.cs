using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;

namespace CrossPlatformDesktopProject.Libraries.SFactory
{
    class BlockSpriteFactory
    {
		//Blocks
		private Texture2D stockBlockBlue;
		private Texture2D bushBlockBlue;
		private Texture2D tubeBlockBlue;
		private Texture2D swirlBlockBlue;
		private Texture2D stockBlockOrange;
		private Texture2D bushBlockOrange;
		private Texture2D tubeBlockOrange;
		private Texture2D swirlBlockOrange;

		private static BlockSpriteFactory instance = new BlockSpriteFactory();
		public static BlockSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private BlockSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			//Blocks
			stockBlockBlue = content.Load<Texture2D>("BlockSprites/StockBlueBlock");
			bushBlockBlue = content.Load<Texture2D>("BlockSprites/BushBlueBlock");
			tubeBlockBlue = content.Load<Texture2D>("BlockSprites/TubeBlueBlock");
			swirlBlockBlue = content.Load<Texture2D>("BlockSprites/SwirlBlueBlock");
			stockBlockOrange = content.Load<Texture2D>("BlockSprites/StockOrangeBlock");
			bushBlockOrange = content.Load<Texture2D>("BlockSprites/BushOrangeBlock");
			tubeBlockOrange = content.Load<Texture2D>("BlockSprites/TubeOrangeBlock");
			swirlBlockOrange = content.Load<Texture2D>("BlockSprites/SwirlOrangeBlock");
		}

		public List<IGameObject> CreateBlockSpriteList(Vector2 location)
		{
			List<IGameObject> blockList = new List<IGameObject>();
			blockList.Add(new BlockSprite(stockBlockBlue, location));
			blockList.Add(new BlockSprite(bushBlockBlue, location));
			blockList.Add(new BlockSprite(swirlBlockBlue, location));
			blockList.Add(new BlockSprite(tubeBlockBlue, location));
			blockList.Add(new BlockSprite(stockBlockOrange, location));
			blockList.Add(new BlockSprite(bushBlockOrange, location));
			blockList.Add(new BlockSprite(swirlBlockOrange, location));
			blockList.Add(new BlockSprite(tubeBlockOrange, location));

			return blockList;
		}
	}
}
