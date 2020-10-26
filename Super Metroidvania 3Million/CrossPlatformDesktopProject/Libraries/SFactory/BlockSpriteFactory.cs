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
		private Texture2D bushBlockSilver;
		private Texture2D dualHorizontalBlockStone;
		private Texture2D leftStartingPlatformBlock;
		private Texture2D redDoorBottomLeftBlock;
		private Texture2D redDoorBottomRightBlock;
		private Texture2D redDoorMiddleBlock;
		private Texture2D redDoorMiddleLeftBlock;
		private Texture2D redDoorMiddleRightBlock;
		private Texture2D redDoorTopLeftBlock;
		private Texture2D redDoorTopRightBlock;
		private Texture2D rightStartingPlatformBlock;
		private Texture2D stockBlockStone;
		private Texture2D stoneBlockWithEyes;
		private Texture2D verticalTubeStoneBlock;


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

			bushBlockSilver = content.Load<Texture2D>("BlockSprites/BushSilverBlock");
			dualHorizontalBlockStone = content.Load<Texture2D>("BlockSprites/DualHorizontalStoneBlock");
			leftStartingPlatformBlock = content.Load<Texture2D>("BlockSprites/LeftStartingPlatform");
			redDoorBottomLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorBottomLeft");
			redDoorBottomRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorBottomRight");
			redDoorMiddleBlock = content.Load<Texture2D>("BlockSprites/RedDoorMiddle");
			redDoorMiddleLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorMiddleLeft");
			redDoorMiddleRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorMiddleRight");
			redDoorTopLeftBlock = content.Load<Texture2D>("BlockSprites/RedDoorTopLeft");
			redDoorTopRightBlock = content.Load<Texture2D>("BlockSprites/RedDoorTopRight");
			rightStartingPlatformBlock = content.Load<Texture2D>("BlockSprites/RightStartingPlatform");
			stockBlockStone = content.Load<Texture2D>("BlockSprites/StockStoneBlock");
			stoneBlockWithEyes = content.Load<Texture2D>("BlockSprites/StoneBlockWithEyes");
			verticalTubeStoneBlock = content.Load<Texture2D>("BlockSprites/VerticalTubeStoneBlock");
		}
		
		//This method will probably be dropped and replaced by many more methods when the block sprites and game objects are separated.
		public List<ISprite> CreateBlockSpriteList(Vector2 location)
		{
			List<ISprite> blockList = new List<ISprite>();


			/*blockList.Add(new BlockSprite(BushBlockBlue, location));
			blockList.Add(new BlockSprite(bushBlockBlue, location));
			blockList.Add(new BlockSprite(swirlBlockBlue, location));
			blockList.Add(new BlockSprite(tubeBlockBlue, location));
			blockList.Add(new BlockSprite(stockBlockOrange, location));
			blockList.Add(new BlockSprite(bushBlockOrange, location));
			blockList.Add(new BlockSprite(swirlBlockOrange, location));
			blockList.Add(new BlockSprite(tubeBlockOrange, location));*/

			return blockList;
		}

		public ISprite CreateStockBlockBlueSprite(StockBlockBlue block)
        {
			return new StockBlockBlueSprite(stockBlockBlue, block);
        }

		public ISprite CreateSwirlBlockBlueSprite(SwirlBlockBlue block)
		{
			return new SwirlBlockBlueSprite(swirlBlockBlue, block);
		}

		public ISprite CreateBushBlockBlueSprite(BushBlockBlue block)
		{
			return new BushBlockBlueSprite(bushBlockBlue, block);
		}

		public ISprite CreateBushBlockSilverSprite(BushBlockSilver block)
		{
			return new BushBlockSilverSprite(bushBlockSilver, block);
		}

		public ISprite CreateDualHorizontalBlockStoneSprite(DualHorizontalBlockStone block)
        {
			return new DualHorizontalBlockStoneSprite(dualHorizontalBlockStone, block);
		}

		public ISprite CreateLeftStartingPlatformBlockSprite(LeftStartingPlatformBlock block)
		{
			return new LeftStartingPlatformBlockSprite(leftStartingPlatformBlock, block);
		}

		public ISprite CreateRightStartingPlatformBlockSprite(RightStartingPlatformBlock block)
		{
			return new RightStartingPlatformBlockSprite(rightStartingPlatformBlock, block);
		}

		public ISprite CreateRedDoorBottomLeftBlockSprite(RedDoorBottomLeftBlock block)
		{
			return new RedDoorBottomLeftBlockSprite(redDoorBottomLeftBlock, block);
		}

		public ISprite CreateRedDoorBottomRightBlockSprite(RedDoorBottomRightBlock block)
		{
			return new RedDoorBottomRightBlockSprite(redDoorBottomRightBlock, block);
		}
		public ISprite CreateRedDoorMiddleBlockSprite(RedDoorMiddleBlock block)
		{
			return new RedDoorMiddleBlockSprite(redDoorMiddleBlock, block);
		}

		public ISprite CreateRedDoorMiddleLeftBlockSprite(RedDoorMiddeLeftBlock block)
		{
			return new RedDoorMiddeLeftBlockSprite(redDoorMiddleLeftBlock, block);
		}

		public ISprite CreateRedDoorMiddleRightBlockSprite(RedDoorMiddleRightBlock block)
		{
			return new RedDoorMiddleRightBlockSprite(redDoorMiddleRightBlock, block);
		}

		public ISprite CreateRedDoorTopLeftBlockSprite(RedDoorTopLeftBlock block)
		{
			return new RedDoorTopLeftBlockSprite(redDoorTopLeftBlock, block);
		}

		public ISprite CreateRedDoorTopRightBlockSprite(RedDoorTopRightBlock block)
		{
			return new RedDoorTopRightBlockSprite(redDoorTopRightBlock, block);
		}

		public ISprite CreateStockBlockStoneSprite(StockBlockStone block)
        {
			return new StockBlockStoneSprite(stockBlockStone, block);
        }

		public ISprite CreateTubeBlockBlueSprite(TubeBlockBlue block)
        {
			return new TubeBlockBlueSprite(tubeBlockBlue, block);
        }

		public ISprite CreateStoneBlockWithEyesSprite(StoneBlockWithEyes block)
        {
			return new StoneBlockWithEyesSprite(stoneBlockWithEyes, block);
        }

		public ISprite CreateVerticalTubeStoneBlockSprite(VerticalTubeStoneBlock block)
        {
			return new VerticalTubeStoneBlockSprite(verticalTubeStoneBlock, block);
        }








	}
}
